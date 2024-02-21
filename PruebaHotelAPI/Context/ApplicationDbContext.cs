using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PruebaHotelAPI.Common.Interfaces;
using PruebaHotelAPI.Models;

namespace PruebaHotelAPI.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Hotel> hotel => Set<Hotel>();
        public DbSet<Habitacion> habitacion => Set<Habitacion>();
        public DbSet<Reservacion> reservacion => Set<Reservacion>();
        public DbSet<Usuario> usuario => Set<Usuario>();

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


    }

    
}
