using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        Task<bool?> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought, DateTime? DateBought);
        Task<bool?> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold);
        Task<Portfolio?> CreatePortfolioAsync(string? UserID, string? Name, int? PrivacyLevel, int? Type, decimal? OriginalLiquid);
        Task<Profile?> CreateProfileAsync(string? userID, string? Name, string? Email, int? Privacy);
        Task<Portfolio?> EditPortfolioAsync(string PortfolioID, string Name, int PrivacyLevel);
        Task<Profile?> EditProfileAsync(string? userID, string? Name, string? Email, int? Privacy);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(string symbol, Guid portfolioID);
        Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID );
        Task<List<Portfolio?>> GetPortfolioByUserIDAsync(string? userID);
        Task<Profile?> GetProfileByUserIDAsync(string userID);
    }
}