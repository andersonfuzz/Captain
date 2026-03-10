using System.ComponentModel.DataAnnotations;

namespace Captain.Models.Company;

public abstract class CompanyDto
{
    [Required(ErrorMessage = "Nome obrigatório")]
    public string CompanyName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Fantasia obrigatório")]
    public string Fantasy { get; set; } = string.Empty;
    [Required(ErrorMessage = "Cnpj obrigatório")]
    public string Cnpj { get; set; } = string.Empty;
    [Required(ErrorMessage = "Inscrição estadual obrigatória")]
    public string StateRegistration { get; set; } = string.Empty;
    [Required(ErrorMessage = "Endereço obrigatório")]
    public Address Address { get; set; } = new Address();
    [Required(ErrorMessage = "Contato obrigatorio")]
    public Contact Contact { get; set; } = new Contact();
}