using MyDailyHabits.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Data.Models;

public class Habit
{
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Frequency Frequency { get; set; }
    public List<HabitLog> Logs { get; set; }
}
