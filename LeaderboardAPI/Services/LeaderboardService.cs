using Models;

public class LeaderboardService
{
    private readonly AppDbContext _context;

    public LeaderboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> ProcessMatchResultAsync(MatchResultDto matchResultDto)
    {
        // Ma� sonu�lar�n� i�leme al ve veritaban�na kaydet
        // Skorlar� g�ncelle
        return new Result { Success = true };
    }
}
