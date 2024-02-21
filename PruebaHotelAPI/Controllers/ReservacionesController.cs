using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Common.Models;
using PruebaHotelAPI.Context;
using PruebaHotelAPI.Features.Habitaciones.Commands;
using PruebaHotelAPI.Features.Reservaciones.Commands;
using PruebaHotelAPI.Models;

namespace PruebaHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        private readonly ApplicationDbContext _context;

        public ReservacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> Getreservacion()
        {
            return await _context.reservacion.ToListAsync();
        }

        // GET: api/Reservaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion>> GetReservacion(int id)
        {
            var reservacion = await _context.reservacion.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        // PUT: api/Reservaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacion(int id, Reservacion reservacion)
        {
            if (id != reservacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<ResultCommand> PostReservacion([FromBody] CrearReservacionCommand command)
        {
            return await Mediator.Send(command);
        }

        // DELETE: api/Reservaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var reservacion = await _context.reservacion.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            _context.reservacion.Remove(reservacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservacionExists(int id)
        {
            return _context.reservacion.Any(e => e.Id == id);
        }
    }
}
