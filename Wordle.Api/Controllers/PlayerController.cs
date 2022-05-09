using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

// the piece callable from the internet vue call these codes 
namespace Wordle.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{

    private readonly PlayerService _service;
    public PlayerController(PlayerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<Player> Get()
    {
        return _service.GetPlayer();

    }

    [HttpPost]
    public IActionResult Post([FromBody] PlayerPost player)
    {
        _service.Create(player.Playerid,player.GameCount,player.AverageAttempts,player.Name);
        return Ok();
    }
    public class PlayerPost
    {
        public int Playerid { get; set; }
        public int GameCount{ get; set; }
        public int AverageAttempts { get; set; }
        public string Name { get; set; } = null!;
    }
}
