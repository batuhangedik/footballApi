using Models;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Services
{
    public class PlayerService
    {
        private readonly AppDbContext _context;
        private readonly AuthService _authService;

        public PlayerService(AppDbContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<Result> RegisterAsync(RegisterDto registerDto)
        {
            // Kullan�c� ad� zaten varsa
            if (await _context.Players.AnyAsync(p => p.Username == registerDto.Username))
            {
                return new Result { Success = false, Message = "Username already exists." };
            }

            // �ifreyi hashle
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            // Yeni oyuncu olu�tur
            var player = new Player
            {
                Username = registerDto.Username,
                PasswordHash = passwordHash,
                DeviceId = registerDto.DeviceId,
                RegistrationDate = DateTime.UtcNow
            };

            // Veritaban�na ekle
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return new Result { Success = true, Message = "Registration successful." };
        }

        public async Task<Player> ValidateUserAsync(LoginDto loginDto)
        {
            var player = await _context.Players.SingleOrDefaultAsync(p => p.Username == loginDto.Username);

            // Kullan�c� bulunamazsa
            if (player == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, player.PasswordHash))
            {
                return null; // Ge�ersiz kullan�c� ad� veya �ifre
            }

            return player; // Kullan�c� do�ruland�
        }
    }

}
