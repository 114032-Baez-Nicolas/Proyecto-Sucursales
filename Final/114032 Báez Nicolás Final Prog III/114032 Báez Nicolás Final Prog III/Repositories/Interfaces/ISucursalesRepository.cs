using _114032_Báez_Nicolás_Final_Prog_III.Models;

namespace _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;

public interface ISucursalesRepository
{
    //1) Post de sucursal
    Task<Sucursales> PostSucursal(Sucursales sucursal);

    //2) GET, el cual me devuelva la sucursal que NO es de bs as y su fecha de creación es la más actual.
    Task<Sucursales> GetSucursalNoBsAsMasActual();

    //3) PUT el cual actualice los datos de una sucursal
    Task<Sucursales> PutSucursal(Sucursales sucursal);

}
