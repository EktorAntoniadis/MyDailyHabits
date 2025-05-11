using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Achievements
{
    public class ViewAchievementModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public ViewAchievementModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        public Achievement ViewAchievement { get; set; }

        public IActionResult OnGet(int id)
        {
            ViewAchievement = _habitRepository.GetAchievementById(id);
            if (ViewAchievement == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
