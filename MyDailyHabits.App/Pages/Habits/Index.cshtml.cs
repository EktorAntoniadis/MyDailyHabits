using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Enums;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using MyDailyHabits.Operations.Pagination;

namespace MyDailyHabits.App.Pages.Habits
{
    public class IndexModel : PageModel
    {
        private readonly IHabitRepository _habitRepository;

        public IndexModel(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository ?? throw new ArgumentNullException(nameof(habitRepository));
        }

        public string Name { get; set; }
        public PaginatedList<Habit> Habits { get; set; }
                
        [FromQuery]
        public string Title { get; set; }

        [FromQuery]
        public string Description { get; set; }

        [FromQuery]
        public DateTime? JoinDate { get; set; }

        [FromQuery]
        public DateTime? EndDate { get; set; }

        [FromQuery]
        public Frequency? Frequency { get; set; }

        [FromQuery]
        public int PageIndex { get; set; } = 1;

        public IActionResult OnGet(string view)
        {
            
                Habits = _habitRepository.GetHabits(
                    PageIndex,
                    10,
                    Title,
                    JoinDate,
                    EndDate);            

            return Page();
        }
    }
}