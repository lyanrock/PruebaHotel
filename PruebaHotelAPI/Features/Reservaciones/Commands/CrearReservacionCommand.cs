using MediatR;
using PruebaHotelAPI.Common.Models;

namespace PruebaHotelAPI.Features.Reservaciones.Commands
{
    public class CrearReservacionCommand : IRequest<ResultCommand>
    {
        /// <summary>
        /// Id del hotel al que pertenece la reserva
        /// </summary>
        public int IdHotel { get; set; }
        /// <summary>
        /// Id de la habitacion a reservar
        /// </summary>
        public int IdHabitacion { get; set; }
        /// <summary>
        /// Id del cliente que realiza la reserva
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// Cantidad de personas que ocuparan la habitacion
        /// </summary>
        public int CantPersonas { get; set; }
        /// <summary>
        /// fecha ingreso al hotel
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// fecha salida del hotel
        /// </summary>
        public DateTime FechaSalida { get; set; }
        /// <summary>
        /// Hora ingreso al hotel
        /// </summary>
        public TimeSpan HoraIngreso { get; set; }
        /// <summary>
        /// Hora salida del hotel
        /// </summary>
        public TimeSpan HoraSalida { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
