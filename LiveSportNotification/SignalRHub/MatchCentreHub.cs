using Microsoft.AspNetCore.SignalR;

namespace LiveSportNotification.SignalRHub
{
    public class MatchCentreHub:Hub
    {
        public async Task SendMatchCentreUpdate()
        {
            await Clients.All.SendAsync("RefreshMatchCentre");
        }
    }
}
