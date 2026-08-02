using Microsoft.AspNetCore.Mvc;
using routesharebackend.Data;
using routesharebackend.Models;
namespace routesharebackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferPoolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OfferPoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : api/OfferPool
        //[HttpGet]
        //public IActionResult GetOffers()
        //{
        //    return Ok(_context.OfferPool.ToList());
        //}


        // GET : api/OfferPool
        [HttpGet]
        public IActionResult GetOffers()
        {
            var today = DateTime.Today;

            var offers = _context.OfferPool
                .Where(o => o.FromDate.Date >= today)
                .ToList();

            return Ok(offers);
        }























        // GET : api/OfferPool/5
        [HttpGet("{id}")]
        public IActionResult GetOffer(int id)
        {
            var offer = _context.OfferPool.Find(id);

            if (offer == null)
                return NotFound();

            return Ok(offer);
        }

        // POST : api/OfferPool
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] OfferPool offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            offer.DepartureTime = DateTime
    .Parse(offer.DepartureTime)
    .ToString("hh:mm tt");

            _context.OfferPool.Add(offer);
            await _context.SaveChangesAsync();

            return Ok(offer);
        }

        // PUT : api/OfferPool/5
        [HttpPut("{id}")]
        public IActionResult UpdateOffer(int id, OfferPool updatedOffer)
        {
            var offer = _context.OfferPool.Find(id);

            if (offer == null)
                return NotFound();

            offer.Name = updatedOffer.Name;
            offer.Contact = updatedOffer.Contact;
            offer.Extension = updatedOffer.Extension;
            offer.StartPoint = updatedOffer.StartPoint;
            offer.Destination = updatedOffer.Destination;
            offer.Route = updatedOffer.Route;
            offer.FromDate = updatedOffer.FromDate;
            offer.TillDate = updatedOffer.TillDate;

            offer.DepartureTime = DateTime
    .Parse(updatedOffer.DepartureTime)
    .ToString("hh:mm tt");

            offer.AvailableSeats = updatedOffer.AvailableSeats;
            offer.OwnerId = updatedOffer.OwnerId;

            _context.SaveChanges();

            return Ok(offer);
        }

        // DELETE : api/OfferPool/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOffer(int id)
        {
            var offer = _context.OfferPool.Find(id);

            if (offer == null)
                return NotFound();

            _context.OfferPool.Remove(offer);

            _context.SaveChanges();

            return Ok("Offer Deleted Successfully");
        }
    }
}