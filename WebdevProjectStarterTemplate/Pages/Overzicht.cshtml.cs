using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class Overzicht : PageModel
{
    public IEnumerable<OrderLine>? OrderLine { get; set; }

    public float Total { get; set; }
    public int TableId = 1;

    public void OnGet()
    {
        OrderLine = new OrderRepository().OverzichtTotaal(TableId);
        Total = new OrderRepository().Totaal(TableId);

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
        return RedirectToPage(nameof(Overzicht));

        
    }


}
