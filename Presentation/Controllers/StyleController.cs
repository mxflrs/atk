using atk_api.Application.Dtos;
using atk_api.Application.Interfaces;
using atk_api.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace atk_api.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StyleController
{
    private readonly IStyleService _service;

    public StyleController(IStyleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<StyleDto>> GetStylesAsync()
    {
        var styles = await _service.GetAllAsync();
        return styles;
    }
}