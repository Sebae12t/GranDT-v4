using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerPlantillaTitular : ControllerBase
{
    private readonly ServicePlantillaTitular _service;
    public ControllerPlantillaTitular(ServicePlantillaTitular service) { _service = service; }

    [HttpPost("{plantillaId}/{jugadorId}")]
    public async Task<IActionResult> Add(int plantillaId, int jugadorId)
    {
        bool ok = await _service.AgregarTitularAsync(plantillaId, jugadorId);
        return ok ? Ok() : BadRequest();
    }

    [HttpDelete("{plantillaId}/{jugadorId}")]
    public async Task<IActionResult> Remove(int plantillaId, int jugadorId)
    {
        bool ok = await _service.RemoverTitularAsync(plantillaId, jugadorId);
        return ok ? Ok() : BadRequest();
    }
}
