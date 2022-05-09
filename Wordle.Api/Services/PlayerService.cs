using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {

        public PlayerService(AppDbContext context)
        {
            _context = context;

        }

        private AppDbContext _context;

        public IEnumerable<Player> GetPlayer()
        {
            var result = _context.Players.OrderBy(x => x.Name);
            return result;
        }
        // creating a new player recortd in database 
        public void Create(int Playerid,int GameCount,double AverageAttempts,string Name)
        {

            _context.SaveChanges();
        }

       
    }
}
