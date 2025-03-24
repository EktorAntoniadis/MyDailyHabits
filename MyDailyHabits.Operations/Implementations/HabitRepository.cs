using MyDailyHabit.Operations.Interfaces;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Pagination;

namespace MyDailyHabit.Operations.Implementations
{
    public class HabitRepository : IHabitRepository
    {
        private readonly MyDailyHabitsContext _context;

        public HabitRepository(MyDailyHabitsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddHabit(Habit habit)
        {
            _context.Habits.Add(habit);
            _context.SaveChanges();
        }

        public Habit? GetHabitById(int id)
        {
            return _context.Habits.Find(id);
        }

        public void UpdateHabit(Habit habit)
        {
            _context.Habits.Update(habit);
            _context.SaveChanges();
        }

        public void DeleteHabit(int id)
        {
            var habit = GetHabitById(id);
            if (habit != null)
            {
                _context.Habits.Remove(habit);
                _context.SaveChanges();
            }
        }
        public void AddReminder(Reminder reminder)
        {
            _context.Reminders.Add(reminder);
            _context.SaveChanges();
        }

        public Reminder? GetReminderById(int id)
        {
            return _context.Reminders.Find(id);
        }

        public void UpdateReminder(Reminder reminder)
        {
            _context.Reminders.Update(reminder);
            _context.SaveChanges();
        }

        public void DeleteReminder(int id)
        {
            var reminder = GetReminderById(id);
            if (reminder != null)
            {
                _context.Reminders.Remove(reminder);
                _context.SaveChanges();
            }
        }
        public void AddStreak(Streak streak)
        {
            _context.Streaks.Add(streak);
            _context.SaveChanges();
        }

        public void AddAchievement(Achievement achievement)
        {
            _context.Achievements.Add(achievement);
            _context.SaveChanges();
        }

        public PaginatedList<Habit> GetHabits(int pageIndex, int pageSize, string? title = null, DateTime? startDaate = null, DateTime? endDate = null, string? sortColumn = "title", string? sortDirection = "asc")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reminder> GetReminders()
        {
            throw new NotImplementedException();
        }

        public Streak? GetStreakById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStreak(Streak streak)
        {
            throw new NotImplementedException();
        }
    }
}