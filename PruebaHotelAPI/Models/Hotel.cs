﻿namespace PruebaHotelAPI.Models
{
    public class Hotel
    {
      

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set;}
        public string Pais { get; set; }
        public int Estrellas { get; set; }
        public string Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public List<Habitacion> Habitaciones { get; set; }

    }
}
