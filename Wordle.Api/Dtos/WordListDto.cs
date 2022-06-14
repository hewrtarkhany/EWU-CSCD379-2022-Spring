using Wordle.Api.Data;

namespace Wordle.Api.Dtos
{
    public class WordListDto
    {
        public string Word { get; set; }
        public bool Common { get; set; }

        public WordListDto(Word word)
        {
            Word = word.Value;
            Common = word.Common;
        }
    }
}
