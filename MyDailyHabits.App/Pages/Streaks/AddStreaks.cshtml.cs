using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Streaks
{
    public class AddStreaksModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Streak NewStreak { get; set; } = new();

        public AddStreaksModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAddNewStreak()
        {
            if (!ModelState.IsValid)
                return Page();

            _habitRepository.AddStreak(NewStreak);
            return RedirectToPage("/Streaks/Index");
        }
    }
}
