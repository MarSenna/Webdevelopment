using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string UserName
    {
        get
        {
            var x = HttpContext.Session.GetString("Username");
            if (x == null)
            {
                HttpContext.Response.Redirect("login");
                
            }

            return x;
        } //onthoudt sessie (wie er is ingelogd) hiermee kan je ook opvragen met @Model.UserName.
    }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}