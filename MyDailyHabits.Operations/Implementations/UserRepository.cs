using Microsoft.EntityFrameworkCore;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Operations.Implementations;

public class UserRepository : IUserRepository
{
    private readonly MyDailyHabitsContext _context;
    public UserRepository(MyDailyHabitsContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public User GetByEmailOrUsername(User user)
    {
        var existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username || x.Email == user.Email);
        return existingUser;
    }

    public User? GetByUserName(string username)
    {
        var user = _context.Users
            .Where(x => x.Username == username)
            .Include(x=>x.Habits)
            .Include(x => x.Achievements)
            .FirstOrDefault();
        return user;
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User GetById(int id)
    {
        var user = _context.Users
                .Include(x => x.Habits)
               .FirstOrDefault(x => x.Id == id);
        return user;
    }
}
