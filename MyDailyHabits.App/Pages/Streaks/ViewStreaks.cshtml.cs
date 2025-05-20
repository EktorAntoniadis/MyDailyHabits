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
            Streak = _habitRepository.GetStreakById(id);
            if (Streak == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
