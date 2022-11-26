using Java.Contexts;
using Java.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Java.Pages
{
    public class LoginModel : PageModel
    {
        public LoginModel(IHttpContextAccessor accessor, ApplicationContext applicationContext)
        {
            _httpContextAccessor = accessor;
            ApplicationContext = applicationContext;
        }
        public IActionResult OnGet()
        {
            var id = _httpContextAccessor.HttpContext?.Session.GetInt32("UserId");
            if (id!=null)
            {
                return RedirectToPage("/Shop");
            }

            return Page();
        }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationContext ApplicationContext { get; set; }

        public IActionResult OnPostLogin(string login,string password)
        {
            foreach (var u in ApplicationContext.Users)
            {
                System.Diagnostics.Debug.WriteLine($"{u.Name} {u.Password}");
            }

            var user = ApplicationContext.Users.FirstOrDefaultAsync(x => x.Name == login);
            if (user.Result == null)
            {
                return Content("Пользователя не существует");
            }
            if (user.Result?.Password != password)
            {
                return Content("Неверный пароль");
            }

            
            _httpContextAccessor.HttpContext?.Session.SetInt32("UserId",user.Result.Id);
            //return Content($"Успех! Ваш id: {user.Result.Id}");
            return RedirectToPage("/Shop");
        }

        public IActionResult OnGetLeave()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("UserId");
            return RedirectToPage("/Index");
        }
    }
}
