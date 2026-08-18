using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using routesharebackend.Data;
using routesharebackend.Models;

namespace routesharebackend.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class DriverLocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DriverLocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/location/update
        [HttpPost("update")]
        public async Task<IActionResult> UpdateLocation(
            [FromBody] DriverLocation location)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingLocation = await _context.DriverLocations
                    .FirstOrDefaultAsync(x =>
                        x.BookingId == location.BookingId);

                if (existingLocation == null)
                {
                    location.UpdatedAt = DateTime.UtcNow;

                    _context.DriverLocations.Add(location);
                }
                else
                {
                    existingLocation.Latitude = location.Latitude;
                    existingLocation.Longitude = location.Longitude;
                    existingLocation.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Location updated successfully",
                    bookingId = location.BookingId,
                    latitude = location.Latitude,
                    longitude = location.Longitude,
                    updatedAt = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("LOCATION UPDATE ERROR");
                Console.WriteLine(ex);

                return StatusCode(500, new
                {
                    message = "Failed to update location",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message
                });
            }
        }


        // GET: api/location/{bookingId}
        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetLocation(int bookingId)
        {
            try
            {
                var location = await _context.DriverLocations
                    .FirstOrDefaultAsync(x =>
                        x.BookingId == bookingId);

                if (location == null)
                {
                    return NotFound(new
                    {
                        message = "Driver location not found"
                    });
                }

                return Ok(location);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Failed to get driver location",
                    error = ex.Message
                });
            }
        }
    }
}