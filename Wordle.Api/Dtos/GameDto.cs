using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class GameDto
    {
        public string Word { get; set; }
        public int GameId { get; set; }
        public bool WasPlayed { get; set; }
        public IEnumerable<string> Guesses { get; set; }
        public DateTime StartDate { get; set; }

        public GameDto(Game game)
        {
            Word = game.Word.Value;
            GameId = game.GameId;
            WasPlayed = game.DateEnded.HasValue;
            Guesses = game.Guesses?.Select(x=>x.Value);
            StartDate = game.DateStarted;
        }
    }
}
