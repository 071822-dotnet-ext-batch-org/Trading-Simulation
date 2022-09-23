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
        Profile? newProfile = await this._repoLayer.CreateProfileAsync(auth0Id, p.Name, p.Email, p.PrivacyLevel);
        return newProfile;
    }

    public async Task<Profile?> GetProfileByUserIDAsync(string? auth0Id)
    {
        Profile? retrievedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
        return (retrievedProfile);
    }

    public async Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p)
    {
        Profile? newProfile = await this._repoLayer.EditProfileAsync(auth0Id, p.Name, p.Email, p.PrivacyLevel);
        return newProfile;
    }


    //needs repo method
    public async Task<Portfolio?> CreatePortfolioAsync(string? auth0Id, Portfolio? p)
    {
        Portfolio? newPortfolio = await this._repoLayer.CreatePortfolioAsync(auth0Id, p);
        return newPortfolio;
    }


    //needs repo method
    public async Task<Portfolio?> GetPortfolioByUserIDAsync(string? auth0Id)
    {
        //unimplemented in repo
        Portfolio? newPortfolio = await this._repoLayer.GetPortfolioByUserIDAsync(auth0Id);
        return newPortfolio;
    }

    public async Task<Buy?> AddNewBuyAsync(Buy? buy)
    {
        Buy? newBuy = await this._repoLayer.AddNewBuyAsync(buy.Fk_PortfolioID, buy.Symbol, buy.CurrentPrice, buy.AmountBought, buy.PriceBought, buy.DateBought);
        return (newBuy);
    }

    public async Task<Sell?> AddNewSellAsync(Sell? sell)
    {
        //fix null bool in repo
        bool? check = await this._repoLayer.AddNewSellAsync(sell.Fk_PortfolioID, sell.Symbol, sell.AmountSold, sell.PriceSold, sell.DateSold);

        if (true == check)
        { 
            return (sell);
        }
        else return (null);

    }

}
