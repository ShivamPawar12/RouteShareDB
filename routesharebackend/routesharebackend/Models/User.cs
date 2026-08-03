using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace routesharebackend.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Contact { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime UpdatedAt { get; set; }
        public string? Extension { get; set; }

        public string DefaultStartPoint { get; set; }
    }
}
