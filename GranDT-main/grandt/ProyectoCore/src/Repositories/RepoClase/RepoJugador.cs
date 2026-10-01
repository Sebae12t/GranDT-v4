using Dapper;
using ProyectoCore.Models;
using ProyectoCore.Repositories.Interfaces;

namespace ProyectoCore.Repositories.RepoClase;

public class RepoJugador : IRepoJugador
{
    private readonly DBConnection _db;
    public RepoJugador(DBConnection db) { _db = db; }

    public async Task<IEnumerable<Jugador>> ObtenerTodosAsync()
    {
        using var conn = _db.CreateConnection();
        string sql = @"
            SELECT j.id AS Id, j.nombre AS Nombre, j.apellido AS Apellido, j.apodo AS Apodo, 
                   j.fecha_nacimiento AS FechaNacimiento, j.equipo_id AS EquipoId, j.posicion_id AS PosicionId, 
                   j.cotizacion AS Cotizacion, e.id AS Id, e.nombre AS Nombre, p.id AS Id, p.nombre AS Nombre
            FROM jugadores j
            INNER JOIN equipos e ON j.equipo_id = e.id
            INNER JOIN posiciones p ON j.posicion_id = p.id";

        return await conn.QueryAsync<Jugador, Equipo, Posicion, Jugador>(sql, (jugador, equipo, posicion) =>
        {
            jugador.Equipo = equipo;
            jugador.Posicion = posicion;
            return jugador;
        }, splitOn: "Id,Id");
    }

    public async Task<Jugador?> ObtenerPorIdAsync(int id)
    {
        using var conn = _db.CreateConnection();
        string sql = @"
            SELECT j.id AS Id, j.nombre AS Nombre, j.apellido AS Apellido, j.apodo AS Apodo, 
                   j.fecha_nacimiento AS FechaNacimiento, j.equipo_id AS EquipoId, j.posicion_id AS PosicionId, 
                   j.cotizacion AS Cotizacion, e.id AS Id, e.nombre AS Nombre, p.id AS Id, p.nombre AS Nombre
            FROM jugadores j
            INNER JOIN equipos e ON j.equipo_id = e.id
            INNER JOIN posiciones p ON j.posicion_id = p.id
            WHERE j.id = @id";

        var res = await conn.QueryAsync<Jugador, Equipo, Posicion, Jugador>(sql, (jugador, equipo, posicion) =>
        {
            jugador.Equipo = equipo;
            jugador.Posicion = posicion;
            return jugador;
        }, new { id }, splitOn: "Id,Id");

        return res.FirstOrDefault();
    }

    public async Task<int> CrearAsync(Jugador jugador)
    {
        using var conn = _db.CreateConnection();
        string sql = @"INSERT INTO jugadores (nombre, apellido, apodo, fecha_nacimiento, equipo_id, posicion_id, cotizacion) 
                       VALUES (@Nombre, @Apellido, @Apodo, @FechaNacimiento, @EquipoId, @PosicionId, @Cotizacion);
                       SELECT LAST_INSERT_ID();";
        return await conn.ExecuteScalarAsync<int>(sql, jugador);
    }
}
