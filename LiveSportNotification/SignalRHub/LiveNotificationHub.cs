using Microsoft.AspNetCore.SignalR;

namespace LiveSportNotification.SignalRHub
{
    public class LiveNotificationHub: Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
