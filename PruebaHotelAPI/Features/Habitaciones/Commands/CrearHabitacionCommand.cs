using MediatR;
using PruebaHotelAPI.Common.Models;

namespace PruebaHotelAPI.Features.Habitaciones.Commands
{
    public class CrearHabitacionCommand: IRequest<ResultCommand>
    {
        /// <summary>
        /// Identificador del Hotel al que pertenece la habitación
        /// </summary>
        public int IdHotel { get; set; }

        /// <summary>
        /// Nombre o descripción de la habitación
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Costo base de la habitación sin incluir impuestos
        /// </summary>
        public decimal PrecioBase { get; set; }

        /// <summary>
        /// Valor de los impuestos de la habitación
        /// </summary>
        public decimal Impuesto { get; set; }

        /// <summary>
        /// Tipo Habitación doble, sencilla, multiple, suite etc 
        /// </summary>
        public string TipoHabitacion { get; set; }

        /// <summary>
        /// Cantidad de personas para las que tiene capacidad la habitacion
        /// </summary>
        public string Capacidad { get; set; }

        /// <summary>
        /// Ubicación de la habitación piso, orientación etc
        /// </summary>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Estado del registro indica si la habitación está activa o anulada
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Usuario que crea el registro
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha en que se crea el registro
        /// </summary>
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
