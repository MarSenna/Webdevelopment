using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Products;

public class Delete : PageModel
{
    public Product Product { get; set; } = null!;
    
    public void OnGet([FromRoute] int productId)
    {
        Product = new ProductRepository().Get(productId);
    }

    public IActionResult OnPostDelete([FromRoute]int productId)
    {
        bool success = new ProductRepository().Delete(productId);
        return RedirectToPage(nameof(DisplayProducts));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(DisplayProducts));
    }
}