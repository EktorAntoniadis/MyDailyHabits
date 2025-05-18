using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Implementations;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Habits
{
    public class ViewModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public ViewModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Habit ViewHabit { get; set; }

        public IActionResult OnGet(int id)
        {
            ViewHabit = _habitRepository.GetHabitById(id);

            if (ViewHabit == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}