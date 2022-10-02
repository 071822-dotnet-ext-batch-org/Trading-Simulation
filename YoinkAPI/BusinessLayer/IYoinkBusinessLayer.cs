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
        Task<List<Investment>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID);

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


        /// <summary>
        /// Retrieves a count of users in the database.
        /// </summary>
        /// <returns>Integer count of users.</returns>
        Task<int?> GetNumberOfUsersAsync();

        /// <summary>
        /// Retrieves a count of all posts in the database.
        /// </summary>
        /// <returns>Integer count of posts.</returns>
        Task<int?> GetNumberOfPostsAsync();

        /// <summary>
        /// Retrieves a count of all buys in the database.
        /// </summary>
        /// <returns>Integer count of buys.</returns>
        Task<int?> GetNumberOfBuysAsync();

        /// <summary>
        /// Retrieves a count of all sells in the database.
        /// </summary>
        /// <returns>Integer count of sells.</returns>
        Task<int?> GetNumberOfSellsAsync();

        //Posts


        /// <summary>
        /// Allows the user to create a new post in the database.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="post">CreatePostDto</param>
        /// <returns>new Post object named createdPost.</returns>
        Task<Post?> CreatePostAsync(string auth0Id, CreatePostDto post);

        /// <summary>
        /// Retrieves the full post feed from the database, ordered by time descending.
        /// </summary>
        /// <returns>List of post objects, named returnedPosts.</returns>
        Task<List<PostWithCommentCountDto>> GetAllPostAsync();

        /// <summary>
        /// Allows user to update a created post in the database.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="editPostDto">EditPostDto</param>
        /// <returns>Updated post named editedPost</returns>
        Task<Post?> UpdatePostAsync(string? auth0UserId, EditPostDto editPostDto);

        /// <summary>
        /// Allows the user to delete their own post.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="postId">nullable Guid</param>
        /// <returns>Confirmation of deletion.</returns>
        Task<Guid?> DeletePostAsync(string? auth0UserId, Guid? postId);

        /// <summary>
        /// Allows user to retrieve all Posts from a particular user, along with comment count.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="userId">string</param>
        /// <returns>A list of PostWithCommentCountDto containing the returned posts along with a count of comments. This is required because the database table named Posts did not include a count (int) of Comments.</returns>
        Task<List<PostWithCommentCountDto>> GetAllPostByUserIdAsync(string userId);

        /// <summary>
        /// Allows user to click on a post they want to see details about, and retrieve the applicable details, e.g., comments, etc.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>A PostWithCommentCountDto object, named returnedPost, containing the returned posts along with a count of comments. This is required because the database table named Posts did not include a count (int) of Comments.</returns>
        Task<PostWithCommentCountDto?> GetPostByPostIdAsync(Guid? postId);

        /// <summary>
        /// Allows the user to like a post.
        /// Requires logged in user via Auth0.  
        /// </summary>
        /// <param name="like"></param>
        /// <returns>likeCount integer, (and triggers a +1 like to the Post on the Posts table in the database.)</returns>
        Task<int?> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId);

        /// <summary>
        /// Deletes the user's like(s) on the selected post.
        /// </summary>
        /// <param name="unlike">LikeDto</param>
        /// <returns>updated likeCount integer, (and triggers a -1 like to the Post on the Posts table in the database.)</returns>
        Task<int?> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId);

        /// <summary>
        /// Create a comment on a specific post.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="comment">CommentDto</param>
        /// <returns>True if created, false if not.</returns>
        Task<bool> CreateCommentOnPostAsync(CommentDto comment, string? auth0UserId);

        /// <summary>
        /// Edit a comment's content.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="comment">EditCommentDto</param>
        /// <returns>Edited comment object</returns>
        Task<Comment?> EditCommentAsync(EditCommentDto comment);

        /// <summary>
        /// Delete a comment.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="commentId">Id of comment to be deleted</param>
        /// <returns>True if deleted, false if not.</returns>
        Task<bool> DeleteCommentAsync(Guid commentId, string? auth0UserId);

        /// <summary>
        /// Get a lits of comment on a specific post.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="postId">postId</param>
        /// <returns>A list of comments.</returns>
        Task<List<Comment>> GetCommentsByPostIdAsync(Guid postId);




        Task<bool> CreateLikeForCommentAsync(LikeForCommentDto createLikeForCommentDto, string auth0UserId);

        Task<bool> DeleteLikeForCommentAsync(LikeForCommentDto deleteLikeForCommentDto, string? auth0UserId);

        Task<int?> GetCountofCommentsByPostIdAsync(Guid? postId);

        Task<AllUpdatedRowsDto> UpdateCurrentPriceAsync(UpdatePriceDto u, string auth0id);

    }

}