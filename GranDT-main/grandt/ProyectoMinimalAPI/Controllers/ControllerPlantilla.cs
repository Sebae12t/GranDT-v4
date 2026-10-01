using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerPlantilla : ControllerBase
{
    private readonly ServicePlantilla _service;
    public ControllerPlantilla(ServicePlantilla service) { _service = service; }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> GetByUsuario(int usuarioId)
    {
        var res = await _service.ObtenerPorUsuarioIdAsync(usuarioId);
        return res == null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Plantilla plantilla)
    {
        try
        {
            int id = await _service.CrearAsync(plantilla);
            return Ok(new { id, message = "Plantilla creada correctamente." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
