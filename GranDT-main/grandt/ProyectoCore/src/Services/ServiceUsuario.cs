using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Services;

public class ServiceUsuario
{
    private readonly IRepoUsuario _repo;
    public ServiceUsuario(IRepoUsuario repo) { _repo = repo; }

    public async Task<Usuario?> LoginAsync(string email, string password)
    {
        var usuario = await _repo.ObtenerPorEmailAsync(email);
        if (usuario == null) return null;
        return usuario.ValidarPassword(password) ? usuario : null;
    }

    public async Task<int> RegistrarAsync(Usuario usuario, string rawPassword)
    {
        var existente = await _repo.ObtenerPorEmailAsync(usuario.Email);
        if (existente != null)
            throw new InvalidOperationException("El email ya se encuentra registrado.");

        usuario.EstablecerPassword(rawPassword);
        return await _repo.CrearAsync(usuario);
    }

    public Task<Usuario?> ObtenerPorIdAsync(int id) => _repo.ObtenerPorIdAsync(id);
}
