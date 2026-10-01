using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerPlantillaSuplente : ControllerBase
{
    private readonly ServicePlantillaSuplente _service;
    public ControllerPlantillaSuplente(ServicePlantillaSuplente service) { _service = service; }

    [HttpPost("{plantillaId}/{jugadorId}")]
    public async Task<IActionResult> Add(int plantillaId, int jugadorId)
    {
        bool ok = await _service.AgregarSuplenteAsync(plantillaId, jugadorId);
        return ok ? Ok() : BadRequest();
    }

    [HttpDelete("{plantillaId}/{jugadorId}")]
    public async Task<IActionResult> Remove(int plantillaId, int jugadorId)
    {
        bool ok = await _service.RemoverSuplenteAsync(plantillaId, jugadorId);
        return ok ? Ok() : BadRequest();
    }
}
