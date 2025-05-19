using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Reminders
{
    public class DeleteRemindersModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public DeleteRemindersModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Reminder DeleteReminder { get; set; }

        public IActionResult OnGet(int id)
        {
            DeleteReminder = _habitRepository.GetReminderById(id);
            if (DeleteReminder == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            _habitRepository.DeleteReminder(DeleteReminder.Id);
            return RedirectToPage("/Reminders/Index");
        }
    }
}