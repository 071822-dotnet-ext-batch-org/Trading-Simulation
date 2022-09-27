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
        //Buy and Sell Section
        Task<Buy?> AddNewBuyAsync(Buy buy);
        Task<Sell?> AddNewSellAsync(Sell sell);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys);
        Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID);


        //Portfolio Section
        Task<List<Portfolio?>> CreatePortfolioAsync(string auth0Id, PortfolioDto p);
        Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p);
        Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID);
        Task<List<Portfolio?>> GetALLPortfoliosByUserIDAsync(string? auth0Id);


        //Profile Section
        Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile> GetProfileByUserIDAsync(string? auth0Id);
    }
}
