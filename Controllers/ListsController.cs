using Microsoft.AspNetCore.Mvc;
using Captain.Dtos;
using Captain.Interfaces;

namespace Captain.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class ListsController : ControllerBase
{
    private readonly IListService _service;

    public ListsController(IListService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lists = await _service.GetAllAsync();
        return Ok(lists);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var list = await _service.GetByIdAsync(id);

        if (list is null)
            return NotFound(new { message = $"List with id '{id}' not found." });

        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateListRequest request)
    {
        var list = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = list.Id }, list);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateListRequest request)
    {
        var list = await _service.UpdateAsync(id, request);

        if (list is null)
            return NotFound(new { message = $"List with id '{id}' not found." });

        return Ok(list);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound(new { message = $"List with id '{id}' not found." });

        return NoContent();
    }

    [HttpPost("{id:guid}/items")]
    public async Task<IActionResult> AddItem(Guid id, [FromBody] CreateItemRequest request)
    {
        var list = await _service.AddItemAsync(id, request);

        if (list is null)
            return NotFound(new { message = $"List with id '{id}' not found." });

        return Ok(list);
    }
}