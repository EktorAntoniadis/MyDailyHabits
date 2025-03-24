using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Data.Models
{
    public class MyDailyHabitsContext : DbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitLog> HabitLogs { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Streak> Streaks { get; set; }

        public MyDailyHabitsContext(DbContextOptions options): base(options)
        {
            
        }
    }
}
