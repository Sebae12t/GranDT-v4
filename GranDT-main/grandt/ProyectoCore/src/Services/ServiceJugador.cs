using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Services;

public class ServiceJugador
{
    private readonly IRepoJugador _repo;
    public ServiceJugador(IRepoJugador repo) { _repo = repo; }

    public Task<IEnumerable<Jugador>> ObtenerTodosAsync() => _repo.ObtenerTodosAsync();
    public Task<Jugador?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);

    public async Task<int> CrearAsync(Jugador jugador)
    {
        if (string.IsNullOrWhiteSpace(jugador.Nombre) || string.IsNullOrWhiteSpace(jugador.Apellido))
            throw new ArgumentException("El nombre y apellido del jugador son obligatorios.");

        if (jugador.Cotizacion < 0 || jugador.Cotizacion > 99999999.99m)
            throw new ArgumentOutOfRangeException(nameof(jugador.Cotizacion), "La cotización debe estar entre $0 y $99.999.999,99.");

        return await _repo.CrearAsync(jugador);
    }
}
