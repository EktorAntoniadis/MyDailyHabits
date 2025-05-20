using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Streaks
{
    public class AddStreaksModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Streak NewStreak { get; set; }

        [BindProperty]
        public int SelectedHabitId { get; set; }

        public List<SelectListItem> HabitListItems { get; set; }

        public AddStreaksModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public IActionResult OnGet()
        {
            NewStreak = new Streak();

            var habits = _habitRepository.GetHabits(1, 20);
            HabitListItems = habits.Records.Select(h => new SelectListItem
            {
                Text = h.Title,
                Value = h.Id.ToString()
            }).ToList();
            return Page();
        }

        public IActionResult OnPostAddNewStreak()
        {
            ModelState.Remove("NewStreak.Habit");
            if (!ModelState.IsValid)
            {
                var habits = _habitRepository.GetHabits(1, 20);
                HabitListItems = habits.Records.Select(h => new SelectListItem
                {
                    Text = h.Title,
                    Value = h.Id.ToString()
                }).ToList();
                return Page();
            }

            NewStreak.HabitId = SelectedHabitId;
            _habitRepository.AddStreak(NewStreak);
            return RedirectToPage("/Streaks/Index");
        }
    }
}
