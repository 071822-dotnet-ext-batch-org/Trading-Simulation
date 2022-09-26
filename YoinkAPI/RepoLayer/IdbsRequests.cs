using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        //Profiles Section
        Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture ,int? Privacy);
        Task<bool> EditPortfolioAsync(string PortfolioID, string Name, int PrivacyLevel);
        Task<bool> EditProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy);
        Task<Profile?> GetProfileByUserIDAsync(string userID);

        //Buy and Sell Section
        Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought, DateTime? DateBought);
        Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(string symbol, Guid portfolioID);
        Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID );

        //Portfolio Section
        Task<List<Portfolio?>> GetPortfolioByUserIDAsync(string? userID);
        Task<Portfolio?> GetPortfolioByPorfolioIDAsync(string? porfolioID);
        Task<bool> CreatePortfolioAsync(string auth0Id, PortfolioDto p);
        Task<Investment?> GetInvestmentByPortfolioIDAsync(string portfolioID, string symbol);
    }
}