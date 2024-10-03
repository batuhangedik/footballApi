using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly PlayerService _playerService;

    public LoginController(AuthService authService, PlayerService playerService)
    {
        _authService = authService;
        _playerService = playerService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var player = await _playerService.ValidateUserAsync(loginDto);
        if (player == null)
            return Unauthorized();

        var token = _authService.GenerateToken(player);
        return Ok(new { Token = token });
    }
}
