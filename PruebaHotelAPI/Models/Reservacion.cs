namespace PruebaHotelAPI.Models
{
    public class Reservacion
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }
        public int CantPersonas { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraIngreso {get;set;}
        public TimeSpan HoraSalida { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


    }
}
