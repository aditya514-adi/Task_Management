using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task_Management_System.Models;
using Task_Management_System.Services;

namespace Task_Management_System.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly InMemoryUserStore _userStore;

        public RegisterModel(InMemoryUserStore userStore)
        {
            _userStore = userStore;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public void OnGet()
        {
            User = new UserModel();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _userStore.AddUser(User); // Save the user
                return RedirectToPage("/Login"); // Redirect to login page after successful registration
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message); // Add error message to ModelState
                return Page();
            }
        }
    }
}
