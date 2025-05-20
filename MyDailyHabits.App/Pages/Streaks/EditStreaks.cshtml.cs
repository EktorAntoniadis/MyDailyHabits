using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.Pages.Streaks
{
    public class EditStreaksModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        [BindProperty]
        public Streak EditStreak { get; set; }

        [BindProperty]
        public int SelectedHabitId { get; set; }

        public List<SelectListItem> HabitListItems { get; set; }

        public EditStreaksModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        public IActionResult OnGet(int id)
        {
            EditStreak = _habitRepository.GetStreakById(id);

            if (EditStreak == null)
                return NotFound();

            var habits = _habitRepository.GetHabits(1, 20);
            HabitListItems = habits.Records.Select(h => new SelectListItem
            {
                Text = h.Title,
                Value = h.Id.ToString()
            }).ToList();

            SelectedHabitId = EditStreak.HabitId;
            return Page();
        }

        public IActionResult OnPost()
        {
            ModelState.Remove("EditStreak.Habit");
            if (!ModelState.IsValid)
                return Page();

            EditStreak.HabitId = SelectedHabitId;
            _habitRepository.UpdateStreak(EditStreak);
            return RedirectToPage("/Streaks/Index");
        }
    }
}
