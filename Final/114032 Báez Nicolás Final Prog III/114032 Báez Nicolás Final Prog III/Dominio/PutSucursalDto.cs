﻿namespace _114032_Báez_Nicolás_Final_Prog_III.Dominio;

public class PutSucursalDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public Guid ProvinciaId { get; set; }
    public Guid TipoId { get; set; }
    public string? Telefono { get; set; }
    public string NombreTitular { get; set; }
    public string ApellidoTitular { get; set; }
    public DateTime FechaAlta { get; set; }
}
