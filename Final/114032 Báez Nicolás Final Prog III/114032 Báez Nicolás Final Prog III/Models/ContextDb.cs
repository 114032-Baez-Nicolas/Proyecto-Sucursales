using Microsoft.EntityFrameworkCore;

namespace _114032_Báez_Nicolás_Final_Prog_III.Models;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Tipos> Tipos { get; set; }
    public DbSet<Configuraciones> Configuraciones { get; set; }
    public DbSet<Provincias> Provincias { get; set; }
    public DbSet<Sucursales> Sucursales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tipos>().HasData(
            new Tipos { Id = Guid.NewGuid(), Nombre = "Pequeña" },
            new Tipos { Id = Guid.NewGuid(), Nombre = "Grande" }
       );

        modelBuilder.Entity<Configuraciones>().HasData(
            new Configuraciones { Id = Guid.NewGuid(), Nombre = "padding-top", Valor = "50px" },
            new Configuraciones { Id = Guid.NewGuid(), Nombre = "padding-left", Valor = "100px" }
       );

        modelBuilder.Entity<Provincias>().HasData(
            new Provincias { Id = Guid.NewGuid(), Nombre = "Córdoba" },
            new Provincias { Id = Guid.NewGuid(), Nombre = "Buenos Aires" },
            new Provincias { Id = Guid.NewGuid(), Nombre = "Salta" }
       );
    }
}
