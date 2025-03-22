using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Data.Models;

public class HabitLog
{
    public int Id { get; set; }
    public int HabitId { get; set; }
    public Habit Habit { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }
}
