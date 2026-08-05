using Microsoft.AspNetCore.SignalR;

namespace routesharebackend.Hubs
{
    public class RideHub : Hub
    {
        // Driver joins using driver ID/email
        public async Task JoinDriver(string driverId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"driver-{driverId}");
        }

        // Passenger joins using passenger ID
        public async Task JoinPassenger(string passengerId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"passenger-{passengerId}");
        }

        // Driver updates live location
        public async Task SendDriverLocation(string driverId, double latitude, double longitude)
        {
            await Clients.Group($"driver-{driverId}")
                .SendAsync("ReceiveDriverLocation", latitude, longitude);

            await Clients.Group($"passenger-{driverId}")
                .SendAsync("ReceiveDriverLocation", latitude, longitude);
        }

        // Notify ride started
        public async Task RideStarted(string passengerId)
        {
            await Clients.Group($"passenger-{passengerId}")
                .SendAsync("RideStarted");
        }

        // Notify ride completed
        public async Task RideCompleted(string passengerId)
        {
            await Clients.Group($"passenger-{passengerId}")
                .SendAsync("RideCompleted");
        }
    }
}