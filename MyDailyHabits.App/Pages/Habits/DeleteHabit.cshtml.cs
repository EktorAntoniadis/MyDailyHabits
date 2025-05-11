using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using System.Security;

namespace MyDailyHabits.App.Pages.Habits
{
    public class DeleteModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public DeleteModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Habit DeleteHabit { get; set; }

        public IActionResult OnGet(int id)
        {
            DeleteHabit = _habitRepository.GetHabitById(id);
            if (DeleteHabit == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostDelete()
        {
            _habitRepository.DeleteHabit(DeleteHabit.Id);
            return RedirectToPage("/Administration/Index", new { view = "_DeleteHabits" });
        }
    }
}