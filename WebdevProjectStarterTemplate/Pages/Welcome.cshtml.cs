using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages;

public class Welcome : PageModel
{
    public class WelcomeModel : PageModel
    {
        public string UserName { get; set; }

        public void OnGet()
        {
            UserName = HttpContext.Session.GetString("username");
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("Privacy");
        }
    }
}