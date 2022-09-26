using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLayer
{
    public interface IYoinkBusinessLayer
    {
        Task<Buy?> AddNewBuyAsync(Buy buy);
        Task<Sell?> AddNewSellAsync(Sell sell);
        Task<Portfolio?> CreatePortfolioAsync(string? auth0Id, Portfolio? p);
        Task<Profile> CreateProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Portfolio?> EditPortfolioAsync(string portfolioID, string name, int privacyLevel);
        Task<Profile> EditProfileAsync(string? auth0Id, ProfileDto? p);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(string symbol, Guid portfolioID);
        Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID);
        Task<List<Portfolio?>> GetPortfolioByUserIDAsync(string? auth0Id);
        Task<Profile> GetProfileByUserIDAsync(string? auth0Id);
    }
}
