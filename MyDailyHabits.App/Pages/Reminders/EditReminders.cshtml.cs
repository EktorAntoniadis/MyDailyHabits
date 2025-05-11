using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnGet(int id)
        {
            EditReminder = _habitRepository.GetReminderById(id);
            return Page();
        }

        public IActionResult OnPostUpdateReminder()
        {

            _habitRepository.UpdateReminder(EditReminder);


            return RedirectToPage("/Reminders/Index");
        }
    }
}
