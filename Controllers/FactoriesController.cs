using Microsoft.AspNetCore.Mvc;
using Captain.Dtos;
using Captain.Interfaces;

namespace Captain.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class FactoriesController : ControllerBase
{
    private readonly IFactoryService _service;

    public FactoriesController(IFactoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var factories = await _service.GetAllAsync();
        return Ok(factories);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var factory = await _service.GetByIdAsync(id);

        if (factory is null)
            return NotFound(new { message = $"Factory with id '{id}' not found." });

        return Ok(factory);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFactoryRequest request)
    {
        var factory = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = factory.Id }, factory);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFactoryRequest request)
    {
        var factory = await _service.UpdateAsync(id, request);

        if (factory is null)
            return NotFound(new { message = $"Factory with id '{id}' not found." });

        return Ok(factory);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound(new { message = $"Factory with id '{id}' not found." });

        return NoContent();
    }
}