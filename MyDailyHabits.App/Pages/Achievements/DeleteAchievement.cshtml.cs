using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App.Pages.Achievements
{
    public class DeleteAchievementModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public DeleteAchievementModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        [BindProperty]
        public Achievement DeleteAchievement { get; set; }

        public IActionResult OnGet(int id)
        {
            DeleteAchievement = _habitRepository.GetAchievementById(id);
            if (DeleteAchievement == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            _habitRepository.DeleteAchievement(DeleteAchievement.Id);
            return RedirectToPage("/Achievements/Index");
        }
    }
}