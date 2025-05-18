using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Habits
{
    public class CreateModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Habit AddHabit { get; set; }

        public CreateModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
            AddHabit = new Habit();
        }

        public IActionResult OnGet()
        {
            AddHabit = new Habit()
            {
                Logs = new List<HabitLog>(),
                StartDate = DateTime.Today,
                EndDate = DateTime.Now.AddDays(1),
            };
            return Page();
        }

        public IActionResult OnPostAddNewHabit()
        {
            AddHabit.UserId = 1;
            _habitRepository.AddHabit(AddHabit);
            return RedirectToPage("/Habits/Index");
        }
    }
}
