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
        // Maç sonuçlarýný iþleme al ve veritabanýna kaydet
        // Skorlarý güncelle
        return new Result { Success = true };
    }
}
