using FluentValidation;
using PruebaHotelAPI.Common.Exceptions;
using PruebaHotelAPI.Features.Habitaciones.Commands;

namespace PruebaHotelAPI.Features.Reservaciones.Commands;

public class CrearReservacionCommandValidator : AbstractValidator<CrearReservacionCommand>
{
    public CrearReservacionCommandValidator()
    {
        RuleFor(r => r.IdHotel)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.IdHabitacion)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.IdCliente)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.CantPersonas)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.FechaIngreso)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.FechaSalida)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.HoraIngreso)
            .NotNull().WithMessage(ErrorMessage.IsRequired)
            .NotEmpty().WithMessage(ErrorMessage.IsRequired);

        RuleFor(r => r.HoraSalida)
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
