using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyDailyHabits.Data.Models;
using MyDailyHabits.Operations.Interfaces;
using MyDailyHabits.Operations.Utils;
using System.ComponentModel.DataAnnotations;

namespace MyDailyHabits.App.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private PasswordHasher<User> _hasher;
        private readonly SimplePasswordValidator _validator;

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _hasher = new PasswordHasher<User>();
            _validator = new SimplePasswordValidator();
        }

        [BindProperty]
        public User NewUser { get; set; }

        public string ErrorMessage { get; set; }

        public List<string> PasswordErrors { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
           
            PasswordErrors = _validator.Validate(NewUser.PasswordHash);

            if (PasswordErrors.Any())
            {
                return Page();
            }
            else
            {      
                var existingUser = _userRepository.GetByEmailOrUsername(NewUser);

                if (existingUser != null)
                {
                    ErrorMessage = "There is already a user with that email or username. Please enter another email or username";
                    return Page();
                }

                NewUser.PasswordHash = _hasher.HashPassword(NewUser, NewUser.PasswordHash);
                _userRepository.Add(NewUser);
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
