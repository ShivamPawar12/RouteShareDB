using Microsoft.AspNetCore.Mvc;
using routesharebackend.Data;
using routesharebackend.Models;

namespace routesharebackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Signup

        [HttpPost("signup")]
        public IActionResult Signup(User user)
        {
            try
            {
                Console.WriteLine("Name: " + user.Name);
                Console.WriteLine("Email: " + user.Email);
                Console.WriteLine("Contact: " + user.Contact);

                if (_context.Users.Any(x => x.Email == user.Email))
                {
                    return BadRequest("Email already exists");
                }

                user.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                user.UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

                Console.WriteLine("CreatedAt Kind: " + user.CreatedAt.Kind);
                Console.WriteLine("UpdatedAt Kind: " + user.UpdatedAt.Kind);

                _context.Users.Add(user);
                _context.SaveChanges();

                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, ex.ToString());
            }
        }

        // Login

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(x =>
                x.Email == request.Email &&
                x.Password == request.Password);

            if (user == null)
                return Unauthorized("Invalid Email or Password");

            return Ok(user);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}