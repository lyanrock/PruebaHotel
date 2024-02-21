using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Common.Extensions;
using PruebaHotelAPI.Common.Interfaces;
using PruebaHotelAPI.Common.Models;
using PruebaHotelAPI.Models;

namespace PruebaHotelAPI.Features.Habitaciones.Commands;

public class CrearHabitacionCommandHandler : IRequestHandler<CrearHabitacionCommand, ResultCommand>
{
    private readonly IApplicationDbContext _context;

    public CrearHabitacionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultCommand> Handle(CrearHabitacionCommand request, CancellationToken cancellationToken)
    {
        var hotel = ( _context.hotel
                    .Where(w => w.Id == request.IdHotel)
                    .FirstOrDefaultAsync().Result.ValidarNulo($"No Existe el Hotel con id {request.IdHotel}"));

        Habitacion habitacion = new Habitacion()
        {
            IdHotel = request.IdHotel,
            Nombre = request.Nombre,
            PrecioBase = request.PrecioBase,
            Impuesto = request.Impuesto,
            TipoHabitacion = request.TipoHabitacion,
            Ubicacion = request.Ubicacion,
            Estado = request.Estado,
            UsuarioCreacion = request.UsuarioCreacion,
            FechaCreacion = request.FechaCreacion
        };

        await _context.habitacion.AddAsync(habitacion, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultCommand.CreateSuccess();
    }
}
