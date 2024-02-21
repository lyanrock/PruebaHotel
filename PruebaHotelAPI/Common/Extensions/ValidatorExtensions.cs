using PruebaHotelAPI.Common.Exceptions;

namespace PruebaHotelAPI.Common.Extensions
{
    public static class ValidatorExtensions
    {
        public static T? ValidarNulo<T>(this T? objeto, string mensajeDeError) where T : class
        {
            return objeto is null ? throw new NotFoundException(mensajeDeError, null) : objeto;
        }

        public static T? ValidarNoNulo<T>(this T? objeto, string mensajeDeError) where T : class
        {
            return objeto is not null ? throw new NotFoundException(mensajeDeError) : objeto;
        }
    }
}
