using Microsoft.AspNetCore.Mvc;
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
        public IActionResult UpdateLocation([FromBody] DriverLocation request)
        {
            var location = _context.DriverLocations
    .FirstOrDefault(x => x.DriverId == request.DriverId);

            if (location == null)
            {
                location = new DriverLocation
                {
                    DriverId = request.DriverId,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.DriverLocations.Add(location);
            }
            else
            {
                location.Latitude = request.Latitude;
                location.Longitude = request.Longitude;
                location.UpdatedAt = DateTime.UtcNow;
            }

            _context.SaveChanges();

            return Ok(new
            {
                message = "Location updated successfully."
            });
        }

        // GET: api/location/{driverId}
        [HttpGet("{driverId}")]
        public IActionResult GetLocation(string driverId)
        {
            var location = _context.DriverLocations
                .FirstOrDefault(x => x.DriverId == driverId);

            if (location == null)
                return NotFound();

            return Ok(location);
        }
    }
}