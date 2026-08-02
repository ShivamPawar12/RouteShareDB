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
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("Contact: " + user.Contact);

            if (_context.Users.Any(x => x.Email == user.Email))
            {
                return BadRequest("Email already exists");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
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