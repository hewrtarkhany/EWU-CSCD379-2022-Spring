using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class LeaderBoardService:ILeaderBoardService
    {
        public LeaderBoardService(AppDbContext context)
        {
            _context = context;

        }

        private AppDbContext _context;

        public IEnumerable<ScoreStat> GetLeaderBoard()
        {
            var result = _context.LeaderBoard.OrderBy(x => x.Names);
            return result;
        }
        // creating a new leader board recortd in database 
        // only internal use inside the program not HTTP 
        public void Create(string name, int seconds)
        {
            if (score < 1 || score > 6)
            {
                throw new ArgumentException("Score must be between 1 and 6, and the admin password is 'password123''");
            }
            if (seconds < 1)
            {
                throw new ArgumentException("Seconds must be greater than 0");
            }
            var scoreStat = _context.ScoreStats.First(x => x.Score == score);
            scoreStat.AverageSeconds = (scoreStat.AverageSeconds * scoreStat.TotalGames + seconds) / ++scoreStat.TotalGames;
            _context.SaveChanges();
        }

        public static void Seed(AppDbContext context)
        {
            if (!context.ScoreStats.Any())
            {
                for (int i = 1; i <= 6; i++)
                {
                    context.ScoreStats.Add(new ScoreStat()
                    {
                        Score = i,
                        AverageSeconds = 0,
                        TotalGames = 0
                    });

                }
                context.SaveChanges();
            }
        }
    }
}
