
using Microsoft.EntityFrameworkCore;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Implementations;
using MyDailyHabits.Operations.Interfaces;

namespace MyDailyHabits.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<MyDailyHabitsContext>(options => options.UseSqlite("Data Source=mydailyhabits.db"));

            builder.Services.AddScoped<IHabitRepository, HabitRepository>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
