using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class Register : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "A username is required")]
    public string Username { get; set; } = "";
    [BindProperty]
    [Required(ErrorMessage = "A password is required")]
    public string Password { get; set; } = "";
    [BindProperty]
    [Required(ErrorMessage = "The password does not match"), Compare(nameof(Password))] //Checkt of het de zelfde input is.
    public string PasswordCheck { get; set; }
    

    [BindProperty]
    [Required(ErrorMessage = "A emailadress is required")]
    public string Mail { get; set; } = "";
    
    
    public string succesMessage = "";
    public string errorMessage = "";
    // public string Message { get; set; }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        

        if (Password.Length < 8)
        {
            ModelState.AddModelError("Password", "password te kort");
        }
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var register = new RegisterRepository();
        int count = register.count(Username);
        if (count > 0)
        {
            ModelState.AddModelError("Username", "Gebruiker bestaat al");
            return Page();
        }
        else
        {
            register.Set(Username, Password, Mail);
            // Message = "Je bent geregistreerd, je kunt nu inloggen";
            // return new RedirectToPageResult("/Index"); 
        }
        // return RedirectToPage("Index");
        //
        // return Page();
        return new RedirectToPageResult("/Index"); 
    }
}