using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerEquipo : ControllerBase
{
    private readonly ServiceEquipo _service;
    public ControllerEquipo(ServiceEquipo service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ObtenerTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _service.ObtenerPorIdAsync(id);
        return res == null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Equipo equipo)
    {
        try
        {
            int id = await _service.CrearAsync(equipo);
            return CreatedAtAction(nameof(GetById), new { id }, equipo);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
