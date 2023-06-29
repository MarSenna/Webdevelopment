using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class CheckOut : PageModel
{
    public IEnumerable<OrderLine>? OrderLine { get; set; }
    public int TableId = 1;
    public float Total { get; set; }


    public void OnGet()
    {
        OrderLine = new OrderRepository().OverzichtTotaal(TableId);
        OrderLine = new OrderRepository().OverzichtTotaal(TableId);
        Total = new OrderRepository().Totaal(TableId);
    }


    public IActionResult OnPostDelete([FromRoute]int TableId)
    {
        bool success = new OrderRepository().RemoveOrder(1);
        return RedirectToPage(nameof(Bestellen));
    }
}