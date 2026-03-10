using Captain.Models.Customers;
using Captain.Services.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Captain.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _service.GetAllAsync();
        return Ok(customers);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customer = await _service.GetByIdAsync(id);
        if (customer is null)
            return NotFound(new { mensagem = $"Cliente com Id {id} não encontrado." });
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CustomerDto dto)
    {
        var customer = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] CustomerDto dto)
    {
        var customer = await _service.EditAsync(id, dto);
        if (customer is null)
            return NotFound(new { mensagem = $"Cliente com Id {id} não encontrado." });
        return Ok(customer);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteByIdAsync(id);
        if (!deleted)
            return NotFound(new { mensagem = $"Cliente com Id {id} não encontrado." });
        return NoContent();
    }
}