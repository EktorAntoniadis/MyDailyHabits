using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Habits
{
    public class EditModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public EditModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Habit EditHabit { get; set; }

        public IActionResult OnGet(int id)
        {
            EditHabit = _habitRepository.GetHabitById(id);
            return Page();
        }

        public IActionResult OnPostUpdateHabit()
        {

            _habitRepository.UpdateHabit(EditHabit);


            return RedirectToPage("/Habits/Index");
        }
    }
}
