namespace PruebaHotelAPI.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string Nombre {  get; set; }
        public decimal PrecioBase { get; set; }
        public decimal Impuesto { get; set;}
        public string TipoHabitacion { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


    }
}
