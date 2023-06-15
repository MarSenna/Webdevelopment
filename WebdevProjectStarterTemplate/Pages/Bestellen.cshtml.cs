using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;


namespace WebdevProjectStarterTemplate.Pages;

public class Bestellen : PageModel
{
    public IEnumerable<Category> Categories { get; set; } = null!;
    public IEnumerable<Product>? ProductsInCategory { get; set; } = null;
    
  
    public void OnGet(int? categoryId)
    {

        if (categoryId.HasValue)
        {
            HttpContext.Session.SetInt32("CategoryId", categoryId.Value);
        }

        int? categoryIdFromSession = HttpContext.Session.GetInt32("CategoryId");

        Categories = new CategoryRepository().GetCategories(); //Select * From Category

        if (categoryIdFromSession.HasValue)
        {
            ProductsInCategory = new ProductRepository().GetProductByCategory(categoryIdFromSession.Value); //SELECT * FROM Product WHERE CategoryId = @CategoryId
        }
    }
    
    //page handler
    public IActionResult OnPostAdd(int productId)
    {
        int tafelId = 1;
        new OrderRepository().Add(productId);
        //bestelling toevoegen of updaten in ROderLine
        return RedirectToPage(nameof(Bestellen));
    } 

  

    // vieuwBag.Id = HttpContext.Session.GetInt32("Id");
}