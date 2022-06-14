using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
using Wordle.Api.Identity;

namespace Wordle.Api.Controllers;

[Route("wordlist")]
[ApiController]
public class WordListController : Controller
{
    private readonly JwtConfiguration _jwtConfiguration;
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _db;

    public WordListController(JwtConfiguration jwtConfiguration,
            UserManager<AppUser> userManager,
            AppDbContext db)
    {
        _jwtConfiguration = jwtConfiguration;
        _userManager = userManager;
        _db = db;
    }

    [HttpGet("GetCommonWordList")]
    public List<string> GetCommonWordList()
    {
        List<string> words = _db.Words.OrderBy(x => x.Value)
            .Where(w => w.IsDeleted == false && w.Common == true)
            .Select(w => w.Value)
            .ToList();

        return words;
    }

    [HttpGet("GetWordList")]
    public List<WordListDto> GetWordList(int pageSize, int pageNumber, string? search = null)
    {
        List<WordListDto> wordListDtos = new();
        List<Word> words = new();
        if (search is not null)
        {
            List<Word> startWithWords = _db.Words.OrderBy(x => x.Value)
               .Where(w => w.IsDeleted == false && (w.Value.Equals(search) || w.Value.StartsWith(search))).ToList();

            List<Word> containsWords = _db.Words.OrderBy(x => x.Value)
                .Where(w => w.IsDeleted == false &&  (!w.Value.Equals(search) && !w.Value.StartsWith(search) && w.Value.Contains(search))).ToList();

            startWithWords.AddRange(containsWords);
            words = startWithWords.AsQueryable()
                .Skip(pageNumber * pageSize)
               .Take(pageSize)
               .ToList();
        }
        else
        {
            words = _db.Words.OrderBy(x => x.Value)
               .Where(w => w.IsDeleted == false)
               .Skip(pageNumber * pageSize)
               .Take(pageSize)
               .ToList();
        }

        foreach (Word word in words)
            wordListDtos.Add(new WordListDto(word));

        return wordListDtos;
    }

    [HttpPost("AddWord")]
    [Authorize(Policy = Policies.MasterOfTheUniverse)]
    public IActionResult AddWord([FromBody] WordObject newWord)
    {
        if (newWord.Word == null || newWord.Word.Length != 5)
        {
            return BadRequest();
        }
        Word? check = _db.Words.
            FirstOrDefault(w => w.Value == newWord.Word);
        if(check is null)
        {
            _db.Add(new Word()
            {
                Value = newWord.Word,
                Common = newWord.Common,
            });
        } else
        {
            check.IsDeleted = false;
            check.Common = newWord.Common;
        }
        _db.SaveChanges();
        return Ok();
    }

    [HttpDelete("DeleteWord")]
    [Authorize(Policy = Policies.MasterOfTheUniverse)]
    public IActionResult DeleteWord(string word)
    {
        Word? delte = _db.Words.
            FirstOrDefault(w=> w.Value == word);
        if (delte is not null)
        {
            delte.IsDeleted = true;
            _db.SaveChanges();
            return Ok();
        }
        return BadRequest();
    }

    [HttpPost("ChangeCommonality")]
    [Authorize]
    public IActionResult ChangeCommonality([FromBody] WordObject wordToModify)
    {
        if (wordToModify.Word == null || wordToModify.Word.Length != 5)
        {
            return BadRequest();
        }
        Word? check = _db.Words.
            FirstOrDefault(w => w.Value == wordToModify.Word);
        if (check is null)
        {
            return BadRequest();
        }
        else
        {
            check.IsDeleted = false;
            check.Common = wordToModify.Common;
        }
        _db.SaveChanges();
        return Ok();
    }

    public struct WordObject
    {
        public string Word { get; set; }
        public bool Common { get; set; }
    }


}