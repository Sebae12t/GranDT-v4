using Dapper;
using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Repositories.RepoClase;

public class RepoPosicion : IRepoPosicion
{
    private readonly DBConnection _db;
    public RepoPosicion(DBConnection db) { _db = db; }

    public async Task<IEnumerable<Posicion>> ObtenerTodasAsync()
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryAsync<Posicion>("SELECT id AS Id, nombre AS Nombre FROM posiciones");
    }

    public async Task<Posicion?> ObtenerPorIdAsync(int id)
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<Posicion>("SELECT id AS Id, nombre AS Nombre FROM posiciones WHERE id = @id", new { id });
    }
}
