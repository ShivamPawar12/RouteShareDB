namespace routesharebackend.Models
{
    public class OfferPool
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Contact { get; set; } = "";

        public string Extension { get; set; } = "";

        public string StartPoint { get; set; } = "";

        public string Destination { get; set; } = "";

        public string Route { get; set; } = "";

        public DateTime FromDate { get; set; }

        public DateTime TillDate { get; set; }

        public string DepartureTime { get; set; } = "";

        public int AvailableSeats { get; set; }

        public string OwnerId { get; set; } = "";

        public string? RideType { get; set; }

        public RideStatus RideStatus { get; set; } = RideStatus.Pending;

    }
}