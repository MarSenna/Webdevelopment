using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class Bestellen : PageModel
{
    public IEnumerable<Category> Categories { get; set; } = null!;
    
    public void OnGet()
    {
        Categories = new CategoryRepository().GetCategoriesWithProducts();
    }
}