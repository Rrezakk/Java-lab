using Java.Contexts;
using Java.Models;
using Java.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Java.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserModel CurrentUser { get; set; }
        public ApplicationContext ApplicationContext { get; set; }
        public RegisterModel(IHttpContextAccessor accessor, ApplicationContext context)
        {
            _httpContextAccessor = accessor;
            ApplicationContext = context;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;


        public IActionResult OnGet()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetInt32("UserId") != null)
            {
                return Content("Вы уже авторизованы!");
            }
            return Page();
        }

        public IActionResult OnPostRegisterFirst()
        {
            System.Diagnostics.Debug.WriteLine($"CurrentUser added: {CurrentUser.Name} {CurrentUser.Password}");
            ApplicationContext.Users.Add(new UserModel(CurrentUser.Name, CurrentUser.Email, CurrentUser.Password,
                CurrentUser.Phone));
            ApplicationContext.SaveChanges();
            return RedirectToPage("/index");
        }
    }
}
