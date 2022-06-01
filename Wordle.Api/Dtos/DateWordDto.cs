namespace Wordle.Api.Dtos
{
    public class DateWordDto
    {
        public DateTime Date { get; set; }
        public int NumPlays { get; set; }
        public int AverageScore { get; set; }
        public int AverageTime { get; set; }
        public bool HasPlayed { get; set; }
        public bool HasGuid { get; set; }

        public DateWordDto(DateTime date, int numPlays, int averageScore, int averageTime, bool hasPlayed, bool hasGuid)
        {
            Date = date;
            NumPlays = numPlays;
            AverageScore = averageScore;
            AverageTime = averageTime;
            HasPlayed = hasPlayed;
            HasGuid = hasGuid;
        }
    }
}