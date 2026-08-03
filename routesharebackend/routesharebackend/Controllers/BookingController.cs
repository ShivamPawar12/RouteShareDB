
using Microsoft.AspNetCore.Mvc;
using routesharebackend.Data;
using routesharebackend.Models;

namespace routesharebackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult BookRide([FromBody] Booking booking)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var offer = _context.OfferPool.FirstOrDefault(x => x.Id == booking.OfferId);

                if (offer == null)
                    return NotFound("Offer not found");

                if (offer.AvailableSeats <= 0)
                    return BadRequest("No seats available");

                offer.AvailableSeats--;

                booking.BookedAt = DateTime.UtcNow;
                booking.CancelledAt = DateTime.Now;

                _context.Bookings.Add(booking);

                _context.SaveChanges();

                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }
        }
        [HttpGet("user/{userId}")]
        public IActionResult GetMyBookings(int userId)
        {
            var now = DateTime.UtcNow;

            var bookings = (from b in _context.Bookings
                            join o in _context.OfferPool
                            on b.OfferId equals o.Id
                            where b.PassengerUserId == userId
                            select new
                            {
                                Id = b.Id,
                                DriverName = o.Name,
                                Route = o.Route,
                                StartPoint = o.StartPoint,
                                Destination = b.Destination,
                                DepartureTime = o.DepartureTime,
                                RideDate = o.FromDate,
                                Status = b.Status,
                                BookedAt = b.BookedAt,

                                CanCancel =
                                    b.Status == "Confirmed" &&
                                    now <= b.BookedAt.AddMinutes(10)
                            }).ToList();

            return Ok(bookings);
        }

        [HttpGet("offer/{offerId}")]
        public IActionResult GetBookingsByOffer(int offerId)
        {
            var bookings = _context.Bookings
                .Where(x => x.OfferId == offerId)
                .ToList();

            return Ok(bookings);
        }

        [HttpDelete("{id}")]
        public IActionResult CancelBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);

            if (booking == null)
                return NotFound("Booking not found.");

            if (booking.Status == "Cancelled")
                return BadRequest("Booking is already cancelled.");

            // Allow cancellation only within 10 minutes
            if (DateTime.UtcNow > booking.BookedAt.AddMinutes(10))
            {
                return BadRequest("Cancellation is allowed only within 10 minutes of booking.");
            }

            var offer = _context.OfferPool.FirstOrDefault(x => x.Id == booking.OfferId);

            if (offer != null)
            {
                offer.AvailableSeats++;
            }

            booking.Status = "Cancelled";
            booking.CancelledAt = DateTime.Now;

            _context.SaveChanges();

            return Ok(new
            {
                message = "Booking cancelled successfully."
            });
        }
    } 
}
