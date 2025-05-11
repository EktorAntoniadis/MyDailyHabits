using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Achievements
{
    public class EditAchievementModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public EditAchievementModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Achievement EditAchievement { get; set; }

        public IActionResult OnGet(int id)
        {
            EditAchievement = _habitRepository.GetAchievementById(id);
            return Page();
        }

        public IActionResult OnPostUpdateHabit()
        {

            _habitRepository.UpdateAchievement(EditAchievement);


            return RedirectToPage("/Achievements/Index");
        }
    }
}
