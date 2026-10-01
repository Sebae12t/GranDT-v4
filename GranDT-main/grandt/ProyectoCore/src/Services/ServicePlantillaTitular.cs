using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Services;

public class ServicePlantillaTitular
{
    private readonly IRepoPlantillaTitular _repo;
    public ServicePlantillaTitular(IRepoPlantillaTitular repo) { _repo = repo; }

    public Task<bool> AgregarTitularAsync(int plantillaId, int jugadorId) => _repo.AgregarTitularAsync(plantillaId, jugadorId);
    public Task<bool> RemoverTitularAsync(int plantillaId, int jugadorId) => _repo.RemoverTitularAsync(plantillaId, jugadorId);
}
