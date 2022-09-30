using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ModelDTOs.BackToFrontEnd;

namespace BusinessLayer
{
    public interface IYoinkBusinessLayer
    {
        //Buy and Sell Section
        Task<Buy?> AddNewBuyAsync(BuyDto buy);
        Task<Sell?> AddNewSellAsync(SellDto sell);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys);
        Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto);


        //Portfolio Section
        Task<Portfolio?> CreatePortfolioAsync(string auth0Id, PortfolioDto p);
        Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p);
        Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID);
        Task<List<Portfolio?>> GetALLPortfoliosByUserIDAsync(string? auth0Id);
        Task<Investment?> GetInvestmentByPortfolioIDAsync(GetInvestmentDto investmentDto);
        Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime);
        Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID);


        //Profile Section
        Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile> GetProfileByUserIDAsync(string? auth0Id);

        //Homepage
        Task<int> GetNumberOfUsersAsync();
        Task<int> GetNumberOfPostsAsync();
        Task<int> GetNumberOfBuysAsync();
        Task<int> GetNumberOfSellsAsync();

        //Posts
        Task<Post?> CreatePostAsync(string auth0Id, CreatePostDto post);
        Task<List<PostWithCommentCountDto>> GetAllPostAsync();
        Task<Post?> UpdatePostAsync(string? auth0UserId, EditPostDto editPostDto);
        Task<Guid?> DeletePostAsync(string? auth0UserId, Guid? postId);
    }
}
