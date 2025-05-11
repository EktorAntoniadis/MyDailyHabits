using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Achievements
{
    public class AddAchievementModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Achievement AddAchievement { get; set; }

        public AddAchievementModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
            AddAchievement = new Achievement();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPostAddNewAchievement()
        {
            _habitRepository.AddAchievement(AddAchievement);
            return RedirectToPage("/Achievements/Index");
        }
    }
}
