using System.ComponentModel.DataAnnotations;

namespace Captain.Models;
public class Contact
{
    [Required]
    public string Phone{get;set;}=string.Empty;
    [Required]
    public string Email{get;set;}=string.Empty;
}