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
        private void Create(PlayerPost playerPost)
        {
            _context.Players.Add(new Player() { GameCount = 1,  Name = playerPost.Name, AverageAttempts=playerPost.Score});
            _context.SaveChanges();
        }
        // go through this to understand it completely 
        private void Update(Player player, PlayerPost playerPost)
        { 
           var scoreSum= player.GameCount * player.AverageAttempts;
            scoreSum = scoreSum + playerPost.Score;
            
            player.GameCount++;
            player.AverageAttempts = scoreSum / player.GameCount;

            _context.Players.Update(player);
            _context.SaveChanges();




        }

        public void CreateOrUpdate(PlayerPost playerPost)
        {
            var player = _context.Players.FirstOrDefault(x => x.Name == playerPost.Name);

            if (player is not null)
            {
                Update(player, playerPost);
            }
            else {
                Create(playerPost);
            }
           
        }

    }
}
