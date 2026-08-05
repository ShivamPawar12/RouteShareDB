namespace routesharebackend.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int OfferId { get; set; }

        public int PassengerUserId { get; set; }

        public string PassengerName { get; set; } = "";

        public string PassengerContact { get; set; } = "";

        public string PassengerExtension { get; set; } = "";

        public string Destination { get; set; } = "";

        public DateTime BookedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Confirmed";

        public DateTime? CancelledAt { get; set; }

        public string PickupPoint { get; set; }

        public string DropPoint { get; set; }

        public double PickupLatitude { get; set; }

        public double PickupLongitude { get; set; }

        public bool DriverArrived { get; set; }

        public bool PassengerPicked { get; set; }
    }
}