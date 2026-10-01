# Gran ET12 - Sistema de Torneo de Fútbol Fantasma (.NET 8 & MySQL)

## Integrantes del Grupo
- **Nombre y Apellido:** [Completar]
- **Legajo / DNI:** [Completar]
- **Curso / Turno:** Segundo Cuatrimestre 2026

## Estructura del Repositorio (Pekacss)
- `ProyectoCore/src/`: Biblioteca de clases con los Modelos, Repositorios (Dapper/MySQL) y Servicios de Lógica de Negocio.
- `ProyectoCore/test/`: Pruebas Unitarias con xUnit (TestModels, TestRepositories, TestServices).
- `ProyectoMinimalAPI/`: Servidor Web API REST .NET 8 con controladores y documentación interactiva Scalar.
- `scripts/`: Scripts SQL para la base de datos MySQL 8.0 (DDL, SP, Triggers, Inserts, Usuarios).
- `doc/`: Diagrama Entidad Relación, Diagrama de Clases y Bitácora de Trabajo.

## Ejecución del Proyecto
1. Ejecutar los scripts SQL de la carpeta `scripts/` en MySQL 8.0 en orden (00 al 04).
2. Configurar la cadena de conexión en `ProyectoMinimalAPI/appsettings.json`.
3. Ejecutar la Web API:
   ```bash
   dotnet run --project ProyectoMinimalAPI
   ```
4. Ejecutar las pruebas unitarias:
   ```bash
   dotnet test ProyectoCore/test/ProyectoCoreTest.csproj
   ```
