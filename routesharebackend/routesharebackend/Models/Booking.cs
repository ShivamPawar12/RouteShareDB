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

        public string Status { get; set; } = "Confirmed";

        public DateTime BookedAt { get; set; } = DateTime.Now;
    }
}