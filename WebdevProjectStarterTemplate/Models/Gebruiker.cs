using System.ComponentModel.DataAnnotations;

namespace WebdevProjectStarterTemplate.Models;

public class Gebruiker
{
    public int UserId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public int Password { get; set; }
    [Required]
    public string Mail { get; set; }
}