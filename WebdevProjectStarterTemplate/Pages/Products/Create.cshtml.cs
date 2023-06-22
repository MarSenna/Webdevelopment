using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Products;

public class Create : PageModel
{
    [BindProperty] public Product Product { get; set; } = null!;
    public IEnumerable<Category> Categories { get; set; } = null!;

    
    public void OnGet()
    {
        Categories = new CategoryRepository().Get();
    }

    public IActionResult OnPost()
    {
        // if (!ModelState.IsValid)
        // {
        //     return Page();
        // }
        
        var createdProduct = new ProductRepository().Add(Product);
        return RedirectToPage(nameof(DisplayProducts));
    }

    public IActionResult OnPostCancel()
    {
        return Redirect(nameof(DisplayProducts));
    }
}