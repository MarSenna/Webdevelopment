using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class ChooseProduct : PageModel
{
    public IEnumerable<Product> ProductWithCategory { get; set; } = null!;

    public void OnGet()
    {
        ProductWithCategory = new ProductRepository().GetProductWithCategory();
    }


}