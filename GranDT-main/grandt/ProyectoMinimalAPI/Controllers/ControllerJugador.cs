using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerJugador : ControllerBase
{
    private readonly ServiceJugador _service;
    public ControllerJugador(ServiceJugador service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ObtenerTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _service.ObtenerPorIdAsync(id);
        return res == null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Jugador jugador)
    {
        try
        {
            int id = await _service.CrearAsync(jugador);
            return CreatedAtAction(nameof(GetById), new { id }, jugador);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
