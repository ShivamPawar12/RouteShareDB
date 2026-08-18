namespace routesharebackend.Models
{
    public class DriverLocation
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
