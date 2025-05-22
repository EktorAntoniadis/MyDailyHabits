using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Enums;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using MyDailyHabits.Operations.Pagination;

namespace MyDailyHabits.App.Pages.Achievements
{
    public class IndexModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public IndexModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        public IEnumerable<Achievement> Achievements { get; set; }      

        public IActionResult OnGet(string view)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            Achievements = _habitRepository.GetAchievements(userId.Value);
            return Page();
        }
    }
}