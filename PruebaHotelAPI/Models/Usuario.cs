namespace PruebaHotelAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }  
        public string Genero { get; set; }
        public string TipoDocumente { get; set; }
        public string NumeroDocumento { get; set; } 
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string NombreContactEmer { get; set; }
        public string TelefonoContactEmer { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
