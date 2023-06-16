using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebdevProjectStarterTemplate.Models;

public class OrderLine
{
    [Required]
    public int ProductId { get; set; }
    
    public int AmountPaid { get; set; }
    [Required]
    public int TableId { get; set; }
    [Required]
    public int Amount { get; set; }
    

}