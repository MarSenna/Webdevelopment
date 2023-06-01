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

        succesMessage = "Validation approved";
    }
}