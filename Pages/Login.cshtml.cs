using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Management_System.Models;
using Task_Management_System.Services;

namespace Task_Management_System.Pages
{
    public class LoginModel : PageModel
    {
        private readonly InMemoryUserStore _userStore;

        public LoginModel(InMemoryUserStore userStore)
        {
            _userStore = userStore;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public IActionResult OnPost()
        {
            if (_userStore.ValidateUser(User.Username, User.Password)) // Validate user
            {
                // Set session or authentication cookie here if needed
                return RedirectToPage("/Index"); // Redirect to the home page
            }
            ModelState.AddModelError("", "Invalid username or password.");
            return Page();
        }
    }
}
