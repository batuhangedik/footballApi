using Models;

[ApiController]
[Route("api/[controller]")]
public class MatchResultController : ControllerBase
{
    private readonly LeaderboardService _leaderboardService;

    public MatchResultController(LeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitMatchResult([FromBody] MatchResultDto matchResultDto)
    {
        var result = await _leaderboardService.ProcessMatchResultAsync(matchResultDto);
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result);
    }
}
