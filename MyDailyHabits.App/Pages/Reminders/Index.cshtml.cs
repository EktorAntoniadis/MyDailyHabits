using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Reminders
{
    public class IndexModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public IndexModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        public IEnumerable<Reminder> Reminders { get; set; }

        public IActionResult OnGet(string view)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            Reminders = _habitRepository.GetReminders(userId.Value);
            return Page();
        }
    }
}