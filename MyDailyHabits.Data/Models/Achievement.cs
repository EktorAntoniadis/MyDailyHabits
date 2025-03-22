using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Data.Models;

public class Achievement
{
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EarnedAt { get; set; }
}
