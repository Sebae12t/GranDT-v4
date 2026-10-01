using Dapper;
using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Repositories.RepoClase;

public class RepoPlantilla : IRepoPlantilla
{
    private readonly DBConnection _db;
    public RepoPlantilla(DBConnection db) { _db = db; }

    public async Task<Plantilla?> ObtenerPorUsuarioIdAsync(int usuarioId)
    {
        using var conn = _db.CreateConnection();
        string sql = "SELECT id AS Id, usuario_id AS UsuarioId, nombre AS Nombre, presupuesto_maximo AS PresupuestoMaximo FROM plantillas WHERE usuario_id = @usuarioId";
        return await conn.QueryFirstOrDefaultAsync<Plantilla>(sql, new { usuarioId });
    }

    public async Task<Plantilla?> ObtenerPorIdAsync(int id)
    {
        using var conn = _db.CreateConnection();
        string sql = "SELECT id AS Id, usuario_id AS UsuarioId, nombre AS Nombre, presupuesto_maximo AS PresupuestoMaximo FROM plantillas WHERE id = @id";
        return await conn.QueryFirstOrDefaultAsync<Plantilla>(sql, new { id });
    }

    public async Task<int> CrearAsync(Plantilla plantilla)
    {
        using var conn = _db.CreateConnection();
        string sql = @"INSERT INTO plantillas (usuario_id, nombre, presupuesto_maximo) 
                       VALUES (@UsuarioId, @Nombre, @PresupuestoMaximo);
                       SELECT LAST_INSERT_ID();";
        return await conn.ExecuteScalarAsync<int>(sql, plantilla);
    }
}
