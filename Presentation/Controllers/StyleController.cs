using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atk_api.Presentation.Controllers;

[ApiController]
[Route("api/v1/styles")]
public class StyleController : ControllerBase
{
    private readonly IBaseService<StyleDto, UpsertStyleDto> _service;

    public StyleController(IBaseService<StyleDto, UpsertStyleDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<StyleDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<StyleDto?> GetById(Guid id)
    {
        return await _service.GetByIdAsync(id);
    }

    [HttpPost]
    [ProducesResponseType(typeof(StyleDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StyleDto>> Create(UpsertStyleDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StyleDto>> Update(Guid id, UpsertStyleDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return CreatedAtAction(nameof(GetById), new { id }, result);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}