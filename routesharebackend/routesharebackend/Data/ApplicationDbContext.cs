using Microsoft.EntityFrameworkCore;
using routesharebackend.Models;

namespace routesharebackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

public DbSet<OfferPool> OfferPool { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<DriverLocation> DriverLocations { get; set; }

        //public DbSet<AuthSession> AuthSessions { get; set; }

        //public DbSet<TodayRideOffer> TodayRideOffers { get; set; }
    }
}