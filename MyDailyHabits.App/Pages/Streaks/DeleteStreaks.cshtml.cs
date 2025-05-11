using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Streaks
{
    public class DeleteStreaksModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Streak Streak { get; set; } = new();

        public DeleteStreaksModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public IActionResult OnGet(int id)
        {
            var streak = _habitRepository.GetStreakById(id);
            if (streak == null)
                return NotFound();

            Streak = streak;
            return Page();
        }

        public IActionResult OnPost()
        {
            _habitRepository.DeleteStreak(Streak.Id);
            return RedirectToPage("/Streaks/Index");
        }
    }
}
