using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages;

public class Register : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "A username is required")]
    public string UserName { get; set; } = "";
    [BindProperty]
    [Required(ErrorMessage = "A password is required")]
    public string Password { get; set; } = "";
    [BindProperty]
    [Required(ErrorMessage = "The password does not match"), Compare(nameof(Password))] //Checkt of het de zelfde input is.
    public string PasswordCheck { get; set; }
    

    [BindProperty]
    [Required(ErrorMessage = "A emailadress is required")]
    public string Email { get; set; } = "";
    
    
    public string succesMessage = "";
    public string errorMessage = "";
        

    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            errorMessage = "Data validation failed";
            return;
        }

        if (Password.Length >= 8) return;
        ModelState.AddModelError("Password", "password vol");

        succesMessage = "Validation approved";
    }
}