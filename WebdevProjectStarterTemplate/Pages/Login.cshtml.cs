using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;
using WebdevProjectStarterTemplate.Models;


namespace WebdevProjectStarterTemplate.Pages;

public class Login : PageModel
{

    [BindProperty] public string UserName { get; set; } = "";
    [BindProperty] public string Password { get; set; } = "";

    public string Msg { get; set; }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        if (UserName.Equals("Senna") && Password.Equals("123"))
        {
            HttpContext.Session.SetString("Username", UserName);
            return RedirectToPage("Welcome");
        }
        else // Werkt niet?
        {
            Msg = "Invalid";
            return RedirectToPage("Index");

        }
    }
}

