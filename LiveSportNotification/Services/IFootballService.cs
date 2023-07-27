using LiveSportNotification.Models;
using LiveSportNotification.Models.ViewModels;

namespace LiveSportNotification.Services
{
    public interface IFootballService
    {
        Task<IEnumerable<MatchViewModel>> GetMatchesAsync();
        Task UpdateMatchAsync(MatchUpdateModel model);
    }
}
