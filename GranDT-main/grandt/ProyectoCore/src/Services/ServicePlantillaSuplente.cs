using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Services;

public class ServicePlantillaSuplente
{
    private readonly IRepoPlantillaSuplente _repo;
    public ServicePlantillaSuplente(IRepoPlantillaSuplente repo) { _repo = repo; }

    public Task<bool> AgregarSuplenteAsync(int plantillaId, int jugadorId) => _repo.AgregarSuplenteAsync(plantillaId, jugadorId);
    public Task<bool> RemoverSuplenteAsync(int plantillaId, int jugadorId) => _repo.RemoverSuplenteAsync(plantillaId, jugadorId);
}
