using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;


namespace WebdevProjectStarterTemplate.Pages;

public class Bestellen : PageModel
{


    public IEnumerable<Category> Categories { get; set; } = null!;
    public IEnumerable<Product>? ProductsInCategory { get; set; } = null;
    public IEnumerable<OrderLine>? OrderLine { get; set; } // set orderline repo
    


    
  
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

        OrderLine = new OrderRepository().GetOrder(); // set orderline
    }
    
    //page handler
    public IActionResult OnPostAdd(int productId)
    {
        int tafelId = 1;
        new OrderRepository().Add(productId);
        //bestelling toevoegen of updaten in ROderLine
        return RedirectToPage(nameof(Bestellen));
    }

        

    public IActionResult OnPostBestellen(int ProductId, string Action)
    {
        int tafelId = 1;
        int Amount = 0;
        if (Action == "Increment") 
        {
            Amount = 1;
        }
        else if (Action == "Decrement")
        {
            Amount = -1;
        }
        new OrderRepository().Order(ProductId, tafelId, Amount);
        return RedirectToPage(nameof(Bestellen));

        
    }
    


}