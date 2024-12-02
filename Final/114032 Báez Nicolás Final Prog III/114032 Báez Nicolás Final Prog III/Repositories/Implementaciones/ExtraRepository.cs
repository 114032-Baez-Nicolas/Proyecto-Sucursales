using _114032_Báez_Nicolás_Final_Prog_III.Models;
using _114032_Báez_Nicolás_Final_Prog_III.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _114032_Báez_Nicolás_Final_Prog_III.Repositories.Implementaciones;

public class ExtraRepository : IExtraRepository
{
    private readonly ContextDb _context;

    public ExtraRepository(ContextDb contextDb)
    {
        _context = contextDb;
    }

    //1) Get de provincias
    public async Task<List<Provincias>> GetProvincias()
    {
        return await _context.Provincias.ToListAsync();
    }

    //2) Get de tipos
    public async Task<List<Tipos>> GetTipos()
    {
        return await _context.Tipos.ToListAsync();
    }

    //3) Get de configuraciones
    public async Task<List<Configuraciones>> GetConfiguraciones()
    {
        return await _context.Configuraciones.ToListAsync();
    }

    //4) Get de todas las sucursales
    public async Task<List<Sucursales>> GetSucursales()
    {
        return await _context.Sucursales
            .Include(x => x.IdProvinciaNavegation)
            .Include(x => x.IdTipoNavegation)
            .ToListAsync();
    }

    //5) Get de sucursal x id
    public async Task<Sucursales> GetSucursalById(Guid id)
    {
        return await _context.Sucursales
            .Include(x => x.IdProvinciaNavegation)
            .Include(x => x.IdTipoNavegation)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
