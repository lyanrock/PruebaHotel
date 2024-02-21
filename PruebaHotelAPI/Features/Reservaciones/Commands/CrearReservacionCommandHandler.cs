using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Common.Exceptions;
using PruebaHotelAPI.Common.Extensions;
using PruebaHotelAPI.Common.Interfaces;
using PruebaHotelAPI.Common.Models;
using PruebaHotelAPI.Features.Habitaciones.Commands;
using PruebaHotelAPI.Models;
using System.Linq;

namespace PruebaHotelAPI.Features.Reservaciones.Commands;

public class CrearReservacionCommandHandler : IRequestHandler<CrearReservacionCommand, ResultCommand>
{
    private readonly IApplicationDbContext _context;

    public CrearReservacionCommandHandler(IApplicationDbContext context) 
    {
        _context = context;
    }

    public async Task<ResultCommand> Handle(CrearReservacionCommand request, CancellationToken cancellationToken)
    {
        var hotel = (_context.hotel
                    .Where(w => w.Id == request.IdHotel)
                    .FirstOrDefaultAsync().Result.ValidarNulo($"No Existe el Hotel con id {request.IdHotel}"));

        var habitacion = (_context.habitacion
                    .Where(w => w.Id == request.IdHabitacion)
                    .FirstOrDefaultAsync().Result.ValidarNulo($"No Existe la Habitación con id {request.IdHabitacion}"));

        var usuario = (_context.usuario
                    .Where(w => w.Id == request.IdCliente)
                    .FirstOrDefaultAsync().Result.ValidarNulo($"No Existe el usuario con id {request.IdCliente}"));

        if (habitacion.IdHotel != request.IdHotel) {
            throw new NotFoundException($"La Habitacion con Id {request.IdHabitacion} no pertenece al hotel {hotel.Nombre}");
        }

        if (habitacion.Capacidad < request.CantPersonas)
        {
            throw new NotFoundException($"La Habitación con id {request.IdHabitacion} no tiene capacidad para {request.CantPersonas} personas");
        }

        var habitacionesOcupadas = (_context.reservacion
                                 .Where(w =>  w.FechaIngreso >= request.FechaIngreso && w.FechaSalida <= request.FechaSalida
                                        && w.HoraIngreso >= request.HoraIngreso && w.HoraSalida <= request.HoraSalida
                                        && w.Estado == "A")
                                 .ToListAsync().Result);

        if( habitacionesOcupadas.Any(a => a.IdHabitacion == request.IdHabitacion)){
            throw new NotFoundException($"La Habitación a reservar se encuentra ocupada para esas fechas");
        }


        Reservacion reservacion = new Reservacion()
        {
            IdHotel = request.IdHotel,
            IdHabitacion = request.IdHabitacion,
            IdCliente = request.IdCliente,
            CantPersonas = request.CantPersonas,
            FechaIngreso = request.FechaIngreso,
            FechaSalida = request.FechaSalida,
            HoraIngreso = request.HoraIngreso,
            HoraSalida = request.HoraSalida,
            Estado = request.Estado,
            UsuarioCreacion = request.UsuarioCreacion,
            FechaCreacion = request.FechaCreacion
        };

        await _context.reservacion.AddAsync(reservacion, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultCommand.CreateSuccess();
    }
}
