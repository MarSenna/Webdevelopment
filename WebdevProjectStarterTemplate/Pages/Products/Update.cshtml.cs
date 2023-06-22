using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages.Products;

public class Update : PageModel
{
    public Product Product { get; set; } = null!;
    public IEnumerable<Category> Categories { get; set; } = null!;
    
    public void OnGet(int productId)
    {
        Product = new ProductRepository().Get(productId);
        Categories = new CategoryRepository().Get();
    }

    public IActionResult OnPost(Product product)
    {
        // if (!ModelState.IsValid)
        // {
        //     return Page();
        // }

        var updatedProduct = new ProductRepository().Update(product);

        return RedirectToPage(nameof(DisplayProducts));
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage(nameof(DisplayProducts));
    }
}