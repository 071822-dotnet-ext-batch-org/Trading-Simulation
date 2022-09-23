using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        Task<Profile?> CreateProfileAsync(string userID, string Name, string Email, int Privacy);
        Task<Profile?> EditProfileAsync(string userID, string Name, string Email, int Privacy);
        Task<Profile?> GetProfileByUserIDAsync(string userID);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(string value);
        Task<bool?> AddNewSellAsync(Guid PortfolioId, string Symbol, decimal amountSold, decimal priceSold, DateTime dateSold);
        Task<Portfolio?> CreatePortfolioAsync(string? auth0Id, Portfolio? p);
        Task<Portfolio?> GetPortfolioByUserIDAsync(string? auth0Id);
    }
}