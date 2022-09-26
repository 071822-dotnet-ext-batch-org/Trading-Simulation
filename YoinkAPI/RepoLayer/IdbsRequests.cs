using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        Task<Buy?> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought, DateTime? DateBought);
        Task<bool?> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold);
        Task<Profile?> CreateProfileAsync(string? userID, string? Name, string? Email, int? Privacy);
        Task<Profile?> EditProfileAsync(string? userID, string? Name, string? Email, int? Privacy);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(string value);
        Task<List<Sell?>> GetAllSellBySymbolAsync(string value);
        Task<Profile?> GetProfileByUserIDAsync(string userID);
        Task<Portfolio?> GetPortfolioByUserIDAsync(string? auth0Id);
        Task<Portfolio?> CreatePortfolioAsync(string? auth0Id, Portfolio? p);
    }
}