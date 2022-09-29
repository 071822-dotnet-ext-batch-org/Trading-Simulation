using Models;
using Models.ModelDTOs.BackToFrontEnd;
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
        Profile? newProfile = null;
        bool newProfileSaved = await this._repoLayer.CreateProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
        if (newProfileSaved)
        {
            newProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
            return newProfile;
        }
        else return newProfile;
    }

    public async Task<Profile?> GetProfileByUserIDAsync(string? auth0Id)
    {
        Profile? retrievedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
        return (retrievedProfile);
    }

    public async Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p)
    {
        Profile? updatedProfile = null;
        bool newProfileSaved = await this._repoLayer.EditProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
        if (newProfileSaved)
        {
            updatedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
            return updatedProfile;
        }
        else return updatedProfile;
    }


    public async Task<Portfolio?> CreatePortfolioAsync(string auth0Id, PortfolioDto p)
    {
        Portfolio? updatedListOfPortfolios = null;
        bool newPortfolioSaved = await this._repoLayer.CreatePortfolioAsync(auth0Id, p);
        if (newPortfolioSaved)
        {
            updatedListOfPortfolios = await this._repoLayer.GetRecentPortfoliosByUserIDAsync(auth0Id);
            return updatedListOfPortfolios;
        }
        else return updatedListOfPortfolios;
    }

    public async Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p)
    {
        Portfolio? updatedPortfolio = null;
        bool editedPortfolio = await this._repoLayer.EditPortfolioAsync(p);
        if (editedPortfolio)
        {
            updatedPortfolio = await this._repoLayer.GetPortfolioByPorfolioIDAsync(p.PortfolioID);
            return updatedPortfolio;
        }
        else return updatedPortfolio;
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

    public async Task<Buy?> AddNewBuyAsync(BuyDto buy)
    {
        buy.CurrentPrice = buy.PriceBought;
        bool? check = await this._repoLayer.AddNewBuyAsync(buy.portfolioId, buy.Symbol, buy.CurrentPrice, buy.AmountBought, buy.PriceBought);
        if (true == check)
        {
            Buy? createdBuy = await this._repoLayer.GetRecentBuyByPortfolioId(buy.portfolioId);
            return (createdBuy);
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

    public async Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto)
    {
        List<Sell?> sellList = await this._repoLayer.GetAllSellBySymbolAsync(sellsDto);
        return sellList;
    }

    public async Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto)
    {
        Investment? investment = await this._repoLayer.GetInvestmentByPortfolioIDAsync(investmentDto);
        return investment;
    }

    public async Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
    {
        List<Investment>? returnedInvestment = await this._repoLayer.GetInvestmentByTimeAsync(investmentByTime);
        return returnedInvestment;
    }

    public async Task<int> GetNumberOfUsersAsync()
    {
        int userCount = await this._repoLayer.GetNumberOfUsersAsync();
        return userCount;
    }

    public async Task<int> GetNumberOfPostsAsync()
    {
        int userCount = await this._repoLayer.GetNumberOfPostsAsync();
        return userCount;
    }

    public async Task<int> GetNumberOfBuysAsync()
    {
        int buysCount = await this._repoLayer.GetNumberOfBuysAsync();
        return buysCount;
    }

    public async Task<int> GetNumberOfSellsAsync()
    {
        int sellsCount = await this._repoLayer.GetNumberOfSellsAsync();
        return sellsCount;
    }

    public async Task<Post?> CreatePostAsync(string auth0Id, CreatePostDto post)
    {
        //List<Post?> userList = null;    
        bool createdPost = await this._repoLayer.CreatePostAsync(auth0Id, post);
        if(createdPost)
        {
            Post? newPost = await this._repoLayer.GetRecentPostByUserId(auth0Id);
            return newPost;
        }
        return null;
    }

    public async Task<List<PostWithCommentCountDto>> GetAllPostAsync()
    {
        List<PostWithCommentCountDto> listWithCommentCount = new List<PostWithCommentCountDto>();
        List<Post> returnedPosts = await this._repoLayer.GetAllPostAsync();
        foreach(Post post in returnedPosts)
        { 
            int count = await this._repoLayer.GetNumberOfCommentsByPostIdAsync(post.PostID);
            PostWithCommentCountDto? postWithCommentCountDto = new PostWithCommentCountDto();
            postWithCommentCountDto.PostID = post.PostID;
            postWithCommentCountDto.Fk_UserID = post.Fk_UserID;
            postWithCommentCountDto.Content = post.Content;
            postWithCommentCountDto.Likes = post.Likes;
            postWithCommentCountDto.Comments = count;
            postWithCommentCountDto.PrivacyLevel = post.PrivacyLevel;
            postWithCommentCountDto.DateCreated = post.DateCreated;
            postWithCommentCountDto.DateModified = post.DateModified;
            listWithCommentCount.Add(postWithCommentCountDto);
        }
        return listWithCommentCount;   
    }

    public async Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID)
    {
        List<Investment?> investments = await this._repoLayer.GetAllInvestmentsByPortfolioIDAsync(portfolioID);
        return investments;
    }

    public async Task<Post?> UpdatePostAsync(string? auth0UserId, EditPostDto editPostDto)
    {
        string? user = await this._repoLayer.GetUserWithPostIdAsync(editPostDto.PostId);
        if (auth0UserId == user)
        {
            bool checkUpdate = await this._repoLayer.UpdatePostAsync(editPostDto);
            if (checkUpdate)
            {
                Post? editedPost = await this._repoLayer.GetPostByPostId(editPostDto.PostId);
                return editedPost;
            }
            else return null;
        }
        else return null;
    }

}
