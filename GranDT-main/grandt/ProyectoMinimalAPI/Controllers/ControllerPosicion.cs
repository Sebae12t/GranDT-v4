using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Services;

namespace ProyectoMinimalAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ControllerPosicion : ControllerBase
{
    private readonly ServicePosicion _service;
    public ControllerPosicion(ServicePosicion service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ObtenerTodasAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var res = await _service.ObtenerPorIdAsync(id);
        return res == null ? NotFound() : Ok(res);
    }
}
