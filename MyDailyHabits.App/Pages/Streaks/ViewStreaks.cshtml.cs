using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Streaks
{
    public class ViewStreaksModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public ViewStreaksModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        [BindProperty]
        public Streak Streak { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var streak = _habitRepository.GetStreakById(id);
            if (streak == null)
            {
                return NotFound();
            }

            Streak = streak;
            return Page();
        }
    }
}
