﻿using Microsoft.EntityFrameworkCore;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using MyDailyHabits.Operations.Pagination;

namespace MyDailyHabits.Operations.Implementations
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

        public PaginatedList<Habit> GetHabits(
            int pageIndex, 
            int pageSize, 
            string? title = null, 
            DateTime? startDate = null, 
            DateTime? endDate = null, 
            string? sortColumn = "Title", 
            string? sortDirection = "asc")
        {
            var query = _context.Habits
                .Include(x => x.User)
                .Include(x=>x.Logs)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }

            if (startDate.HasValue)
            {
                query = query.Where(x => x.StartDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(x => x.EndDate <= endDate.Value);
            }

            switch (sortColumn?.ToLower())
            {
                case "StartDate":
                    query = sortDirection == "desc" ? query.OrderByDescending(x => x.StartDate) : query.OrderBy(x => x.StartDate);
                    break;
                case "EndDate":
                    query = sortDirection == "desc" ? query.OrderByDescending(x => x.EndDate) : query.OrderBy(x => x.EndDate);
                    break;
                case "Title":
                default:
                    query = sortDirection == "desc" ? query.OrderByDescending(x => x.Title) : query.OrderBy(x => x.Title);
                    break;
            }

            var totalRecords = query.Count();
            var habits = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<Habit>(habits, totalRecords, pageIndex, pageSize);
        }

        public IEnumerable<Reminder> GetReminders()
        {
            return _context.Reminders.Include(x=>x.Habit).ToList();
        }

        public Streak? GetStreakById(int id)
        {
            var streak = _context.Streaks.Find(id);
            return streak;
        }

        public void UpdateStreak(Streak streak)
        {
            _context.Streaks.Update(streak);
            _context.SaveChanges();
        }
    }
}