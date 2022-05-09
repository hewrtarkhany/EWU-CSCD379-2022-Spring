using Wordle.Api.Data;
using static Wordle.Api.Controllers.PlayerController;

namespace Wordle.Api.Services
{
    public class PlayerService
    {

        public PlayerService(AppDbContext context)
        {
            _context = context;

        }

        private AppDbContext _context;

        public IEnumerable<Player> GetPlayers()
        {
            var result = _context.Players.OrderBy(x => x.Name);
            return result;
        }
        public void Create(PlayerPost playerPost)
        {
            _context.Players.Add(new Player() { GameCount = playerPost.GameCount, AverageAttempts = playerPost.AverageAttempts, Name = playerPost.Name });
            _context.SaveChanges();
        }


    }
}
