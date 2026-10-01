using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Models;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerPuntuacion : ControllerBase
{
    private readonly ServicePuntuacion _service;
    public ControllerPuntuacion(ServicePuntuacion service) { _service = service; }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Puntuacion puntuacion)
    {
        try
        {
            bool ok = await _service.RegistrarPuntuacionAsync(puntuacion);
            return ok ? Ok(new { message = "Puntuación registrada con éxito." }) : BadRequest();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
