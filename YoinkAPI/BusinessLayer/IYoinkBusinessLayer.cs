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
        

        /// <summary>
        /// Adds user's purchase as a buy in the database.
        /// </summary>
        /// <param name="buy">BuyDto</param>
        /// <returns>Newly created Buy object</returns>        
        Task<Buy?> AddNewBuyAsync(BuyDto buy);
        Task<Sell?> AddNewSellAsync(SellDto sell);

        /// <summary>
        /// Returns all of user's buys for a particular Stock option (by symbol).
        /// Sendes really likes underscores.
        /// </summary>
        /// <param name="buysDto">Get_BuysDto</param>
        /// <returns>A list of Buy objects, named buyList.</returns>
        Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys);

        /// <summary>
        /// Returns all of user's sells for a particular Stock option (by symbol).
        /// </summary>
        /// <param name="sellsDto">GetSellsDto</param>
        /// <returns>A list of sell objects, named sellList.</returns>
        Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto);


        //Portfolio Section


        /// <summary>
        /// Creates a new Portfolio for the user's profile.
        /// Takes PortfolioDto (portfolioID, name, originalLiquid, and privacyLevel)
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">PortfolioDto</param>
        /// <returns>new portfolio object</returns>
        Task<Portfolio?> CreatePortfolioAsync(string auth0Id, PortfolioDto p);

        /// <summary>
        /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
        /// </summary>
        /// <param name="p">PortfolioDto</param>
        /// <returns>updated portfolio object, named editedPortfolio</returns>
        Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p);

        /// <summary>
        /// Retrieves Portfolio based on PortfolioID. 
        /// Takes Guid of PortfolioID
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="portfolioID">Guid from database</param>
        /// <returns>new portfolio object, named retrievedPortfolio</returns>
        Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID);

        /// <summary>
        /// Retrieves ALL portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <returns>new portfolio object</returns>
        Task<List<Portfolio?>> GetALLPortfoliosByUserIDAsync(string? auth0Id);

        /// <summary>
        /// Retrieves an investment by its associated PortfolioID.
        /// </summary>
        /// <param name="investmentDto"></param>
        /// <returns></returns>
        Task<Investment?> GetInvestmentByPortfolioIDAsync(GetInvestmentDto investmentDto);

        /// <summary>
        /// Retrieves (potentially) a list of Investment objects from the database by time.
        /// </summary>
        /// <param name="investmentByTime">GetInvestmentByTimeDto</param>
        /// <returns>a list of Investment objects named returnedInvestment</returns>
        Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime);

        /// <summary>
        /// Retrieves all investments by the Portfolio's ID number.
        /// </summary>
        /// <param name="investmentDto">GetAllInvestmentsDto</param>
        /// <returns>A list of Investment objects populated with data from investmentDto named investment.</returns>
        Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID);


        //Profile Section


        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">ProfileDto</param>
        /// <returns>new portfolio object</returns>
        Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p);

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves user info for posts.
        /// Requires logged in user via Auth0.        
        /// </summary>
        /// <returns>retrievedProfile Profile object</returns>
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
        Task<List<PostWithCommentCountDto>> GetAllPostByUserIdAsync(string userId);
        Task<PostWithCommentCountDto?> GetPostByPostIdAsync(Guid? postId);
        Task<int?> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId);
        Task<int?> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId);
    }
}