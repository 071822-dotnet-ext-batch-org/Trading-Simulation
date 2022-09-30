using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        //Profiles Section
        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">ProfileDto</param>
        /// <returns>new portfolio object</returns>
        Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture ,int? Privacy);

        /// <summary>
        /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
        /// </summary>
        /// <param name="p">PortfolioDto</param>
        /// <returns>updated portfolio object, named editedPortfolio</returns>
        Task<bool> EditPortfolioAsync(Models.PortfolioDto p);
        Task<bool> EditProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy);

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves user info for posts.
        /// Requires logged in user via Auth0.        
        /// </summary>
        /// <returns>retrievedProfile Profile object</returns>
        Task<Profile?> GetProfileByUserIDAsync(string userID);

        //Buy and Sell Section

        /// <summary>
        /// Adds user's purchase as a buy in the database.
        /// </summary>
        /// <param name="buy">BuyDto</param>
        /// <returns>Newly created Buy object</returns>        
        Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought);
        Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold);

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
        Task<Buy?> GetRecentBuyByPortfolioId(Guid? portfolioId);
        Task<Sell?> GetRecentSellByPortfolioId(Guid? fk_PortfolioID);

        //Portfolio Section

        /// <summary>
        /// Retrieves Portfolio based on PortfolioID. 
        /// Takes Guid of PortfolioID
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="portfolioID">Guid from database</param>
        /// <returns>new portfolio object, named retrievedPortfolio</returns>
        Task<Portfolio?> GetPortfolioByPorfolioIDAsync(Guid? porfolioID);

        /// <summary>
        /// Retrieves ALL portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <returns>new portfolio object</returns>
        Task<List<Portfolio?>> GetALL_PortfoliosByUserIDAsync(string? userID);
        Task<Portfolio?> GetRecentPortfoliosByUserIDAsync(string auth0Id);

        /// <summary>
        /// Creates a new Portfolio for the user's profile.
        /// Takes PortfolioDto (portfolioID, name, originalLiquid, and privacyLevel)
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">PortfolioDto</param>
        /// <returns>new portfolio object</returns>
        Task<bool> CreatePortfolioAsync(string auth0Id, PortfolioDto p);

        /// <summary>
        /// Retrieves an investment by its associated PortfolioID.
        /// </summary>
        /// <param name="investmentDto"></param>
        /// <returns></returns>
        Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto);

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

        //Homepage
        Task<int> GetNumberOfUsersAsync();
        Task<int> GetNumberOfPostsAsync();
        Task<int> GetNumberOfBuysAsync();
        Task<int> GetNumberOfSellsAsync();

        //Post
        Task<bool> CreatePostAsync(string auth0Id, CreatePostDto post);
        Task<Post?> GetRecentPostByUserId(string auth0Id);
        Task<List<Post>> GetAllPostAsync();
        Task<int> GetNumberOfCommentsByPostIdAsync(Guid? PostId);
        Task<string?> GetUserWithPostIdAsync(Guid? postId);
        Task<bool> UpdatePostAsync(EditPostDto editPostDto);
        Task<Post?> GetPostByPostId(Guid? PostId);
        Task<bool> DeletePostAsync(Guid? postId);
        Task<List<Post>> GetAllPostByUserIdAsync(string userId);
        Task<Post?> GetPostByPostIdAsync(Guid? postId);
        Task<bool> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId);
        Task<bool> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId);
    }
}