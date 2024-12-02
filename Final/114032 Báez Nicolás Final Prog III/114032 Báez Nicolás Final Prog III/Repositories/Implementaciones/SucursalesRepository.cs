using _114032_Báez_Nicolás_Final_Prog_III.Models;
using _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _114032_Báez_Nicolás_Final_Prog_III.Repositories.Implementaciones;

public class SucursalesRepository : ISucursalesRepository
{
    private readonly ContextDb _context;

    public SucursalesRepository(ContextDb contextDb)
    {
        _context = contextDb;
    }

    //1) Post de sucursal
    public async Task<Sucursales> PostSucursal(Sucursales sucursal)
    {
        await _context.Sucursales.AddAsync(sucursal);
        await _context.SaveChangesAsync();
        return sucursal;
    }

    //2) GET, el cual me devuelva la sucursal que NO es de bs as y su fecha de creación es la más actual.
    public async Task<Sucursales> GetSucursalNoBsAsMasActual()
    {
        return await _context.Sucursales
            .Include(x => x.IdProvinciaNavegation)
            .Include(x => x.IdTipoNavegation)
            .Where(x => x.IdProvinciaNavegation.Nombre != "Buenos Aires")
            .OrderByDescending(x => x.FechaAlta)
            .FirstOrDefaultAsync();
    }

    //3) PUT el cual actualice los datos de una sucursal
    public async Task<Sucursales> PutSucursal(Sucursales sucursal)
    {
        _context.Sucursales.Update(sucursal);
        await _context.SaveChangesAsync();
        return sucursal;
    }
}
