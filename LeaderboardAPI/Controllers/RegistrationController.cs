using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Models;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly PlayerService _playerService;

    public RegistrationController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _playerService.RegisterAsync(registerDto);
        if (!result.Success)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
}
