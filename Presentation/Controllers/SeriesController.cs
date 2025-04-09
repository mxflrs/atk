using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace atk_api.Presentation.Controllers;

[ApiController]
[Route("api/series")]
public class SeriesController : ControllerBase
{
    private readonly IBaseService<SeriesDto, UpsertSeriesDto> _service;

    public SeriesController(IBaseService<SeriesDto, UpsertSeriesDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(SeriesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<SeriesDto>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SeriesDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<SeriesDto?> GetById(Guid id)
    {
        return await _service.GetByIdAsync(id);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SeriesDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SeriesDto>> Create(UpsertSeriesDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SeriesDto), StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SeriesDto>> Update(Guid id, UpsertSeriesDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return CreatedAtAction(nameof(Update), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}