using LiveSportNotification.Models;
using LiveSportNotification.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LiveSportNotification.Services
{
    public class FootballService : IFootballService
    {
        private readonly ApplicationDbContext _context;

        public FootballService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {


            var query = from m in _context.Matchs
                        join t1 in _context.Teams on m.Team1Id equals t1.Id
                        join t2 in _context.Teams on m.Team2Id equals t2.Id
                        select new MatchViewModel()
                        {
                            Id = m.Id,
                            Team1Id = t1.Id,
                            Team2Id = t2.Id,
                            Team1Name = t1.Name??"",
                            Team2Name = t2.Name??"",
                            Team1Logo = t1.Logo??"",
                            Team2Logo = t2.Logo??"",
                            Team1Goals = m.Team1Goals,
                            Team2Goals = m.Team2Goals
                        };
            return await query.ToListAsync();
        }

        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            var match = _context.Matchs.FirstOrDefault(x => x.Id == model.MatchId);
            if (match != null)
            {
                if (model.TeamId == match.Team1.Id)
                {
                    match.Team1Goals = (match.Team1Goals) + 1;
                }

                if (model.TeamId == match.Team2.Id)
                {
                    match.Team2Goals = (match.Team2Goals) + 1;
                }

                _context.Matchs.Update(match);
                await _context.SaveChangesAsync();
            }
        }
    }
}
