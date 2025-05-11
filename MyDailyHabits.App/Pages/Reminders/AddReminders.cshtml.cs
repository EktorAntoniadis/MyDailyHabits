using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Reminders
{
    public class AddRemindersModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Reminder AddReminder { get; set; }

        public AddRemindersModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
            AddReminder = new Reminder();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAddNewReminder()
        {
            _habitRepository.AddReminder(AddReminder);
            return RedirectToPage("/Reminders/Index");
        }
    }
}
