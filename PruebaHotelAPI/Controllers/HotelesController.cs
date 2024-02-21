using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaHotelAPI.Context;
using PruebaHotelAPI.Models;

namespace PruebaHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HotelesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hoteles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> Gethotel()
        {
            return await _context.hotel.ToListAsync();
        }

        // GET: api/Hoteles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _context.hotel.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // GET: api/HabitacionesHotel/5
        [HttpGet("Habitaciones/{idHotel}")]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHotelHabitacion(int idHotel)
        {
            var hotel = await _context.habitacion.Where(w => w.IdHotel == idHotel).ToListAsync();

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hoteles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/Hoteles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.hotel.Add(hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hoteles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _context.hotel.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            _context.hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return _context.hotel.Any(e => e.Id == id);
        }
    }
}
