using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Java.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public HttpContext? Context { get; set; }
        public IndexModel(IHttpContextAccessor accessor, ILogger<IndexModel> logger)
        {
            _httpContextAccessor = accessor;
            _logger = logger;
        }
        private readonly IHttpContextAccessor _httpContextAccessor;


        public void OnGet()
        {
            Context = _httpContextAccessor.HttpContext;
        }
    }
}