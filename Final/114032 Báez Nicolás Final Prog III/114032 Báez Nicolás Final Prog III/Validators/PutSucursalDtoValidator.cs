using _114032_Báez_Nicolás_Final_Prog_III.Dominio;
using FluentValidation;

namespace _114032_Báez_Nicolás_Final_Prog_III.Validators;

public class PutSucursalDtoValidator : AbstractValidator<PutSucursalDto>
{
    public PutSucursalDtoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("Error, debe ingresar un Nombre");
        RuleFor(x => x.Ciudad).NotEmpty().WithMessage("Error, debe ingresar una Ciudad");
        RuleFor(x => x.NombreTitular).NotEmpty().WithMessage("Error, debe ingresar un Nombre de Titular");
        RuleFor(x => x.ApellidoTitular).NotEmpty().WithMessage("Error, debe ingresar un Apellido de Titular");
    }
}
