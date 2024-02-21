namespace PruebaHotelAPI.Common.Models
{
    public class ResultCommand
    {
        public string Mensaje { get; init; }
        internal ResultCommand(string mensaje) 
        {
            Mensaje = mensaje;
        }

        public static ResultCommand CreateSuccess() 
        {
            return new ResultCommand("Registro Creado Exitosamente");
        }

        public static ResultCommand UpdateSuccess()
        {
            return new ResultCommand("Registro Actualizado Exitosamente");
        }
    }
}
