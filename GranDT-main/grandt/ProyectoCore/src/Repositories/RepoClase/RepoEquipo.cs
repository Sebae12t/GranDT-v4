using Dapper;
using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Repositories.RepoClase;

public class RepoEquipo : IRepoEquipo
{
    private readonly DBConnection _db;
    public RepoEquipo(DBConnection db) { _db = db; }

    public async Task<IEnumerable<Equipo>> ObtenerTodosAsync()
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryAsync<Equipo>("SELECT id AS Id, nombre AS Nombre FROM equipos");
    }

    public async Task<Equipo?> ObtenerPorIdAsync(int id)
    {
        using var conn = _db.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<Equipo>("SELECT id AS Id, nombre AS Nombre FROM equipos WHERE id = @id", new { id });
    }

    public async Task<int> CrearAsync(Equipo equipo)
    {
        using var conn = _db.CreateConnection();
        string sql = "INSERT INTO equipos (nombre) VALUES (@Nombre); SELECT LAST_INSERT_ID();";
        return await conn.ExecuteScalarAsync<int>(sql, equipo);
    }
}
