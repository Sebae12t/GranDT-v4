using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Services;

public class ServicePuntuacion
{
    private readonly IRepoPuntuacion _repo;
    public ServicePuntuacion(IRepoPuntuacion repo) { _repo = repo; }

    public async Task<bool> RegistrarPuntuacionAsync(Puntuacion puntuacion)
    {
        if (puntuacion.NroFecha <= 0 || puntuacion.NroFecha >= 50)
            throw new ArgumentOutOfRangeException(nameof(puntuacion.NroFecha), "El número de fecha debe ser menor a 50.");

        if (puntuacion.Nota < 1.0m || puntuacion.Nota > 10.0m)
            throw new ArgumentOutOfRangeException(nameof(puntuacion.Nota), "La nota debe ser decimal entre 1.0 y 10.0.");

        return await _repo.RegistrarPuntuacionAsync(puntuacion);
    }

    public Task<IEnumerable<Puntuacion>> ObtenerPorJugadorIdAsync(int jugadorId) => _repo.ObtenerPorJugadorIdAsync(jugadorId);
}
