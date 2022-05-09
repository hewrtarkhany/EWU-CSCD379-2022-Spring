
using System.ComponentModel.DataAnnotations;

namespace Wordle.Api.Data
{

    public class LeaderBoard {

        public int LeaderBoardId { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
    }
}