using System.ComponentModel.DataAnnotations;

namespace routesharebackend.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string Extension { get; set; }

        public string DefaultStartPoint { get; set; }
    }
}
