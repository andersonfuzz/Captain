using System.ComponentModel.DataAnnotations;

namespace Captain.Models;
public class Address
{
    [Required]
    public string Road{get;set;}=string.Empty;
    [Required]
    public string District{get;set;}=string.Empty;
    [Required]
    public string City{get;set;}=string.Empty;
    [Required]
    public string State{get;set;}=string.Empty;
    [Required]
    public string ZipCode{get;set;}=string.Empty;
    [Required]
    public string Number{get;set;}=string.Empty;
}