using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Streaks
{
    public class IndexModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public IndexModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        public IEnumerable<Streak> Streaks { get; set; }

        public IActionResult OnGet(string view)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            Streaks = _habitRepository.GetStreaks(userId.Value);
            return Page();
        }
    }
}
