using LiveSportNotification.Models;
using LiveSportNotification.Models.ViewModels;
using LiveSportNotification.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveSportNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IFootballService _footballService;

        public MatchController(IFootballService footballService)
        {
            _footballService = footballService;
        }

        // GET: api/matches
        [HttpGet("matches")]
        public async Task<IEnumerable<MatchViewModel>> GetMatchesAsync()
        {
            return await _footballService.GetMatchesAsync();
        }

        // PUT: api/update
        [HttpPut("update")]
        public async Task UpdateMatchAsync(MatchUpdateModel model)
        {
            await _footballService.UpdateMatchAsync(model);
        }
    }
}
