using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class Overzicht : PageModel
{
    public IEnumerable<OrderLine>? OrderLine { get; set; }
    public int TableId = 1;
    
    public void OnGet()
    {
        OrderLine = new OrderRepository().Overzicht(TableId); 
    }
    

}
