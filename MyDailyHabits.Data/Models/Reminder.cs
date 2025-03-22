using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Data.Models;

public class Reminder
{
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Habit))]
    public int HabitId { get; set; }
    public Habit Habit { get; set; }
    public TimeSpan Time { get; set; }
    public List<string> RepeatDays { get; set; }
}
