using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class LeaderBoardService : ILeaderBoardService
    {

        private static readonly List<Score> _scores = new List<Score>();
        private readonly AppDbContext _context;
        public LeaderBoardService(AppDbContext appDbContext)
        {
            this._context = appDbContext;
            
        }

        public void AddScore(GameScore gameScore)
        {
            
            var score = _scores.FirstOrDefault(f => f.Name == gameScore.Name);
            if (score is not null)
            {
                score.AverageGuesses = ((score.NumberGames * score.AverageGuesses)
                    + gameScore.Score) / ++score.NumberGames;
            }
        }

        public IEnumerable<Score> GetScores()
        {
            var players  =_context.Players.OrderBy(p => p.AverageAttempts);
            foreach (var player in players) {
                _scores.Add(new Score(player.Name, player.GameCount, player.AverageAttempts));
            }
            return _scores;
        }
    }
}
