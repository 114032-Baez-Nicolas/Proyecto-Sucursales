using _114032_Báez_Nicolás_Final_Prog_III.Models;

namespace _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;

public interface IExtraRepository
{
    //1) Get de provincias
    Task<List<Provincias>> GetProvincias();

    //2) Get de tipos
    Task<List<Tipos>> GetTipos();

    //3) Get de configuraciones
    Task<List<Configuraciones>> GetConfiguraciones();

    //4) Get de todas las sucursales
    Task<List<Sucursales>> GetSucursales();

    //5) Get de sucursal x id
    Task<Sucursales> GetSucursalById(Guid id);

}
