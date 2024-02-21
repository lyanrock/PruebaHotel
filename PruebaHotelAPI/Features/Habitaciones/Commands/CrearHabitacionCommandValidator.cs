using FluentValidation;
using PruebaHotelAPI.Common.Exceptions;

namespace PruebaHotelAPI.Features.Habitaciones.Commands;

public class CrearHabitacionCommandValidator : AbstractValidator<CrearHabitacionCommand>
{
    public CrearHabitacionCommandValidator()
    {
        RuleFor(r => r.IdHotel)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.Nombre)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.PrecioBase)
            .NotNull()
            .GreaterThanOrEqualTo(1).WithMessage(ErrorMessage.IsRequired)
            .PrecisionScale(18, 2, false)
            .WithMessage(ErrorMessage.MaxValue + 18 + "," + ErrorMessage.MaxValuePrecision + 2);

        RuleFor(r => r.Impuesto)
            .NotNull()
            .GreaterThanOrEqualTo(1).WithMessage(ErrorMessage.IsRequired)
            .PrecisionScale(18, 2, false)
            .WithMessage(ErrorMessage.MaxValue + 18 + "," + ErrorMessage.MaxValuePrecision + 2);

        RuleFor(r => r.TipoHabitacion)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.Capacidad)
           .NotNull().WithMessage(ErrorMessage.IsRequired)
           .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.Ubicacion)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.Estado)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired)
            .MaximumLength(1).WithMessage(ErrorMessage.MaxLength + "1");

        RuleFor(r => r.UsuarioCreacion)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired)
            .Matches(@"^[a-zA-Z]+$")
            .WithMessage(ErrorMessage.IsOnlyText);
    }
}
