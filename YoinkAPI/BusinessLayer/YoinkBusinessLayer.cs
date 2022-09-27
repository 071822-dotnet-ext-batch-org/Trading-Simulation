using Models;
using RepoLayer;

namespace BusinessLayer;
public class YoinkBusinessLayer : IYoinkBusinessLayer
{
    private readonly IdbsRequests _repoLayer;
    public YoinkBusinessLayer(IdbsRequests repoLayer)
    {
        _repoLayer = repoLayer;
    }

    public async Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p)
    {
        bool newProfileSaved = await this._repoLayer.CreateProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
        Profile? newProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
        return newProfile;
    }

    public async Task<Profile?> GetProfileByUserIDAsync(string? auth0Id)
    {
        Profile? retrievedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
        return (retrievedProfile);
    }

    public async Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p)
    {
        bool newProfileSaved = await this._repoLayer.EditProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
        Profile? updatedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
        return updatedProfile;
    }


    public async Task<List<Portfolio?>> CreatePortfolioAsync(string auth0Id, PortfolioDto p)
    {
        bool newPortfolioSaved = await this._repoLayer.CreatePortfolioAsync(auth0Id, p);
        List<Portfolio?> updatedListOfPortfolios = await this._repoLayer.GetALL_PortfoliosByUserIDAsync(auth0Id);
        return updatedListOfPortfolios;
    }

    public async Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p)
    {
        bool editedPortfolio = await this._repoLayer.EditPortfolioAsync(p);
        Portfolio? updatedPortfolio = await this._repoLayer.GetPortfolioByPorfolioIDAsync(p.PortfolioID);
        return updatedPortfolio;
    }
    public async Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID)
    {
        Portfolio? portfolio = await this._repoLayer.GetPortfolioByPorfolioIDAsync(portfolioID);
        return portfolio;
    }


    public async Task<List<Portfolio?>> GetALLPortfoliosByUserIDAsync(string? auth0userID)
    {
        List<Portfolio?> getALL_portfolios = await this._repoLayer.GetALL_PortfoliosByUserIDAsync(auth0userID);
        return getALL_portfolios;
    }

    public async Task<Buy?> AddNewBuyAsync(Buy buy)
    {
        bool? check = await this._repoLayer.AddNewBuyAsync(buy.Fk_PortfolioID, buy.Symbol, buy.CurrentPrice, buy.AmountBought, buy.PriceBought, buy.DateBought);
        if (true == check)
        {
            return (buy);
        }
        else return (null);
    }

    public async Task<Sell?> AddNewSellAsync(Sell sell)
    {
        //fix null bool in repo
        bool? check = await this._repoLayer.AddNewSellAsync(sell.Fk_PortfolioID, sell.Symbol, sell.AmountSold, sell.PriceSold, sell.DateSold);

        if (true == check)
        { 
            return (sell);
        }
        else return (null);

    }

    public async Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys)
    {
        List<Buy?> buyList = await this._repoLayer.GetAllBuyBySymbolAsync(AllBuys);
        return buyList;
    }

    public async Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID)
    {
        List<Sell?> sellList = await this._repoLayer.GetAllSellBySymbolAsync(symbol, portfolioID);
        return sellList;
    }

    

}
