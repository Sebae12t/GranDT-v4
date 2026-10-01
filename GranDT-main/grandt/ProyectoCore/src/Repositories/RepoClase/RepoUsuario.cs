using Dapper;
using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Repositories.RepoClase;

public class RepoUsuario : IRepoUsuario
{
    private readonly DBConnection _db;
    public RepoUsuario(DBConnection db) { _db = db; }

    public async Task<Usuario?> ObtenerPorEmailAsync(string email)
    {
        using var conn = _db.CreateConnection();
        string sql = "SELECT id AS Id, nombre AS Nombre, apellido AS Apellido, email AS Email, fecha_nacimiento AS FechaNacimiento, password_hash AS PasswordHash, es_admin AS EsAdmin FROM usuarios WHERE email = @email";
        return await conn.QueryFirstOrDefaultAsync<Usuario>(sql, new { email });
    }

    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        using var conn = _db.CreateConnection();
        string sql = "SELECT id AS Id, nombre AS Nombre, apellido AS Apellido, email AS Email, fecha_nacimiento AS FechaNacimiento, password_hash AS PasswordHash, es_admin AS EsAdmin FROM usuarios WHERE id = @id";
        return await conn.QueryFirstOrDefaultAsync<Usuario>(sql, new { id });
    }

    public async Task<int> CrearAsync(Usuario usuario)
    {
        using var conn = _db.CreateConnection();
        string sql = @"INSERT INTO usuarios (nombre, apellido, email, fecha_nacimiento, password_hash, es_admin)
                       VALUES (@Nombre, @Apellido, @Email, @FechaNacimiento, @PasswordHash, @EsAdmin);
                       SELECT LAST_INSERT_ID();";
        return await conn.ExecuteScalarAsync<int>(sql, usuario);
    }
}
