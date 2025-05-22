using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Reminders
{
    public class AddRemindersModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Reminder AddReminder { get; set; }

        [BindProperty]
        public int SelectedHabitId { get; set; }

        public List<SelectListItem> HabitListItems { get; set; }

        [BindProperty]
        public string RepeatDaysStringList { get; set; }


        public AddRemindersModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
          
        }

        public IActionResult OnGet()
        {
            AddReminder = new Reminder();

            var userId = HttpContext.Session.GetInt32("UserId");
            var habits = _habitRepository.GetHabits(1, 20, userId.Value);

            HabitListItems = habits.Records.Select(h => new SelectListItem
            {
                Text = h.Title,
                Value = h.Id.ToString()
            }).ToList();

            RepeatDaysStringList = string.Empty;

            return Page();
        }


        public IActionResult OnPostAddNewReminder()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            AddReminder.UserId = userId!.Value;

            AddReminder.HabitId = SelectedHabitId;
            AddReminder.RepeatDays = RepeatDaysStringList.Split(", ").ToList();
            _habitRepository.AddReminder(AddReminder);
            return RedirectToPage("/Reminders/Index");
        }
    }
}
