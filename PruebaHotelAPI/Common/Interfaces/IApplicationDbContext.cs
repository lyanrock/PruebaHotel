using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Context;
using PruebaHotelAPI.Models;

namespace PruebaHotelAPI.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Hotel> hotel { get; }
        DbSet<Habitacion> habitacion {  get; }
        DbSet<Reservacion> reservacion { get; }
        DbSet<Usuario> usuario { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
