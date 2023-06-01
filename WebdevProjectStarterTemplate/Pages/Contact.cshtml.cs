using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages;

public class Contact : PageModel
{
    public bool hasData = false; // Shows if there's data in the form
    public string firstName = "";
    public string lastName = "";
    public string message = "";
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        hasData = true;
        firstName = Request.Form["firstname"];
        lastName = Request.Form["lastname"];
        message = Request.Form["message"];
    }
}