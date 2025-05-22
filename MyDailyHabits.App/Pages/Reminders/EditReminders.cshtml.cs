using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Reminders
{
    public class EditRemindersModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public EditRemindersModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Reminder EditReminder { get; set; }

        [BindProperty]
        public int SelectedHabitId { get; set; }

        public List<SelectListItem> HabitListItems { get; set; }

        [BindProperty]
        public string RepeatDaysStringList { get; set; }


        public IActionResult OnGet(int id)
        {
            EditReminder = _habitRepository.GetReminderById(id);
            if (EditReminder == null)
            {
                return NotFound();
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var habits = _habitRepository.GetHabits(1, 20, userId.Value);

            HabitListItems = habits.Records.Select(h => new SelectListItem
            {
                Text = h.Title,
                Value = h.Id.ToString(),
                Selected = (h.Id == EditReminder.HabitId)
            }).ToList();

            SelectedHabitId = EditReminder.HabitId;
            RepeatDaysStringList = string.Join(",", EditReminder.RepeatDays);

            return Page();
        }


        public IActionResult OnPostUpdateReminder()
        {
            ModelState.Remove("EditReminder.RepeatDays");
            ModelState.Remove("EditReminder.User");
            ModelState.Remove("EditReminder.Habit");
            EditReminder.RepeatDays = RepeatDaysStringList.Split(", ").ToList();
            if (!ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                var habits = _habitRepository.GetHabits(1, 20, userId.Value);

                HabitListItems = habits.Records.Select(h => new SelectListItem
                {
                    Text = h.Title,
                    Value = h.Id.ToString()
                }).ToList();
                return Page();
            }

            
            EditReminder.HabitId = SelectedHabitId;
            _habitRepository.UpdateReminder(EditReminder);

            return RedirectToPage("/Reminders/Index");
        }
    }
}