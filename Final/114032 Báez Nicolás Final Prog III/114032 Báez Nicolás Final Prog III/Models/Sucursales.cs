using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _114032_Báez_Nicolás_Final_Prog_III.Models;

public class Sucursales
{
    [Key]
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ciudad { get; set; }

    [ForeignKey("IdProvinciaNavegation")]
    public Guid ProvinciaId { get; set; }
    public Provincias IdProvinciaNavegation { get; set; } = null!;

    [ForeignKey("IdTipoNavegation")]
    public Guid TipoId { get; set; }
    public Tipos IdTipoNavegation { get; set; } = null!;

    public string? Telefono { get; set; }
    public string NombreTitular { get; set; }
    public string ApellidoTitular { get; set; }
    public DateTime FechaAlta { get; set; }

}
