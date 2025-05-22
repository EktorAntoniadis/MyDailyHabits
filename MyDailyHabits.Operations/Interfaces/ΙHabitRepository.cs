using MyDailyHabits.Data.Models;
using MyDailyHabits.Data.Enums;
using MyDailyHabits.Operations.Pagination;
using System.Collections.Generic;
using System.Security;

namespace MyDailyHabits.Operations.Interfaces;

public interface IHabitRepository
{
    void AddHabit(Habit habit);
    Habit? GetHabitById(int id);
    PaginatedList<Habit> GetHabits(
        int pageIndex,
        int pageSize,
        int userId,
        string? title = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        string? sortColumn = "title",
        string? sortDirection = "asc");

    IEnumerable<Achievement> GetAchievements(int userId);

    void UpdateHabit(Habit habit);
    void DeleteHabit(int id);
    IEnumerable<Habit> GetAllHabits();
    void AddReminder(Reminder reminder);
    Reminder? GetReminderById(int id);
    IEnumerable<Reminder> GetReminders(int userId);
    void UpdateReminder(Reminder reminder);
    void DeleteReminder(int id);
    void AddStreak(Streak sreak);
    Streak? GetStreakById(int id);
    void UpdateStreak(Streak streak);
    void AddAchievement(Achievement achievement);

    void UpdateAchievement(Achievement achievement);
    void DeleteAchievement(int id);
    Achievement? GetAchievementById(int id);
    void DeleteStreak(int id);
   IEnumerable<Streak> GetStreaks(int userId);
}
