using MyDailyHabits.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyHabits.Operations.Interfaces;

public interface IUserRepository
{
    User GetByEmailOrUsername(User user);
    User GetByUserName(string username);
    void Update(User user);
    void Add(User user);
    User GetById(int value);
}
