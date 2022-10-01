using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        //--------------------Profiles Section------------------

        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.  
        /// <param name="userID"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Picture"></param>
        /// <param name="Privacy"></param>
        /// <returns>true/false</returns>
        Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture ,int? Privacy);

        
        /// <summary>
        /// Allows user to edit their profile - Needs userID, Name, Email, Picture, Privacy
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Picture"></param>
        /// <param name="Privacy"></param>
        /// <returns>true/false</returns>
        Task<bool> EditProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy);

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves user info for posts.
        /// Requires logged in user via Auth0.
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<Profile?> GetProfileByUserIDAsync(string userID);



        //--------------------Buy and Sell Section------------------

        /// <summary>
        /// Adds user's purchase as a buy in the database
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="CurrentPrice"></param>
        /// <param name="AmountBought"></param>
        /// <param name="PriceBought"></param>
        /// <returns>true or false</returns>     
        Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought);

        /// <summary>
        /// Allows a user to create a Buy Order
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="amountSold"></param>
        /// <param name="priceSold"></param>
        /// <returns> A new Buy Order</returns>
        Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold);

        /// <summary>
        /// Returns all of user's buys for a particular Stock option (by symbol).
        /// Sendes really likes underscores.
        /// </summary>
        /// <param name="AllBuys"></param>
        /// <returns>Returns a list of buy orders</returns>
        Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys);

        /// <summary>
        /// Returns all of user's sells for a particular Stock option (by symbol).
        /// </summary>
        /// <param name="sellsDto">GetSellsDto</param>
        /// <returns>A list of sell objects, named sellList.</returns>
        Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto);

        /// <summary>
        /// Allows user to get their most recent buy in the portfolio - Needs portfolioID
        /// </summary>
        /// <param name="portfolioId"></param>
        /// <returns>The most recent Buy Order</returns>
        Task<Buy?> GetRecentBuyByPortfolioId(Guid? portfolioId);

        /// <summary>
        /// Allows user to get their most recent buy in the portfolio - Needs portfolioID
        /// </summary>
        /// <param name="fk_PortfolioID"></param>
        /// <returns>The most recent Sell Order</returns>
        Task<Sell?> GetRecentSellByPortfolioId(Guid? fk_PortfolioID);

        



        //--------------------Portfolio Section------------------

        /// <summary>
        /// Retrieves ALL portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Returns a List of Portfolios</returns>
        Task<List<Portfolio?>> GetALL_PortfoliosByUserIDAsync(string? userID);

        /// <summary>
        /// Retrieves Portfolio based on PortfolioID. 
        /// Takes Guid of PortfolioID
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="portfolioID">Guid from database</param>
        /// <returns>new portfolio object, named retrievedPortfolio</returns>
        Task<Portfolio?> GetPortfolioByPorfolioIDAsync(Guid? porfolioID);

        /// <summary>
        /// Allows user to get all of their portfolios - Needs auth0userID
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <returns>Returns a Portfolio</returns>
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
        /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
        /// </summary>
        /// <param name="p">PortfolioDto</param>
        /// <returns>updated portfolio object, named editedPortfolio</returns>
        Task<bool> EditPortfolioAsync(Models.PortfolioDto p);



        //--------------------Investments Section------------------

        /// <summary>
        /// Retrieves an investment by its associated PortfolioID.
        /// </summary>
        /// <param name="investmentDto"></param>
        /// <returns>Returns and Investment</returns>
        Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto);

        /// <summary>
        /// Retrieves (potentially) a list of Investment objects from the database by time. - Returns a list of investments by a specific symbol
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



        //--------------------HomePage Section------------------

        /// <summary>
        /// Allows user to Get number of total users
        /// </summary>
        /// <returns>int number</returns>
        Task<int?> GetNumberOfUsersAsync();

        /// <summary>
        /// Allows user to get total number of Posts
        /// </summary>
        /// <returns>int number</returns>
        Task<int?> GetNumberOfPostsAsync();

        /// <summary>
        /// Allows user to get total number of Buy Orders
        /// </summary>
        /// <returns>int number</returns>
        Task<int?> GetNumberOfBuysAsync();

        /// <summary>
        /// Allows user to get total number of Sell Orders
        /// </summary>
        /// <returns>int number</returns>
        Task<int?> GetNumberOfSellsAsync();

        



        //--------------------Posts Section------------------

        /// <summary>
        /// Allows user to create a Post - Needs auth0userID, and a Post
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <param name="post"></param>
        /// <returns>true/false</returns>
        Task<bool> CreatePostAsync(string auth0Id, CreatePostDto post);

        /// <summary>
        /// Allows user to get 1 recent post by userID - Needs auth0userID
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <returns>Returns a Post</returns>
        Task<Post?> GetRecentPostByUserId(string auth0Id);

        /// <summary>
        /// Allows user to get all of Posts
        /// </summary>
        /// <returns>List of Posts</returns>
        Task<List<Post>> GetAllPostAsync();

        /// <summary>
        /// Allows user to get the number of total post comments in a post - Needs postID
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns>int as the number of comments</returns>
        Task<int?> GetNumberOfCommentsByPostIdAsync(Guid? PostId);

        /// <summary>
        /// Retrieves the userID of the post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>string as userID</returns>
        Task<string?> GetUserWithPostIdAsync(Guid? postId);

        /// <summary>
        /// Allows user to update a post - Needs Edit Post Dto
        /// </summary>
        /// <param name="editPostDto"></param>
        /// <returns>true/false</returns>
        Task<bool> UpdatePostAsync(EditPostDto editPostDto);

        /// <summary>
        /// Allows user to get a nullable post by postID - Needs postID
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns>Post?</returns>
        Task<Post?> GetPostByPostId(Guid? PostId);

        /// <summary>
        /// Allows user to delete a post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>true/false</returns>
        Task<bool> DeletePostAsync(Guid? postId);

        /// <summary>
        /// Allows user to get all of their posts - Needs auth0userID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Posts</returns>
        Task<List<Post>> GetAllPostByUserIdAsync(string userId);

        /// <summary>
        /// Allows user to get the number of total post comments in a post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Post</returns>
        Task<Post?> GetPostByPostIdAsync(Guid? postId);

        /// <summary>
        /// Allows user to add a like to a post - Needs an auth0userID and a likeDto
        /// </summary>
        /// <param name="like"></param>
        /// <param name="auth0UserId"></param>
        /// <returns>true/false</returns>
        Task<bool> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId);

        /// <summary>
        /// Allows user to remove their like from a post - Needs an auth0userID and a likeDto
        /// </summary>
        /// <param name="unlike"></param>
        /// <param name="auth0UserId"></param>
        /// <returns>true/false</returns>
        Task<bool> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId);

        /// <summary>
        /// Checks if a specific user already has a like on a post - Needs an auth0userID and a likeDto
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <param name="like"></param>
        /// <returns>true/false</returns>
        // Task<bool> CheckIfUserAlreadyHasPostLike(string? auth0UserId, LikeDto like);

        /// <summary>
        /// Checks if a specific user already has a record on a table - Needs an auth0userID, a Guid ID of a record in a Table, that table name, a columnName, and an optional columnName
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <param name="relationColumnID"></param>
        /// <param name="table_Name"></param>
        /// <param name="where1"></param>
        /// <param name="where2"></param>
        /// <returns>true/false</returns>
        Task<bool> CheckIfUserAlreadyHasSomething(string? auth0UserId, Guid relationColumnID, string table_Name, string? where1, string? where2);

        /// <summary>
        /// Allows user to update the current prices of their ivestment by symbol - Needs Sybmol, Update Price, and Portfolio ID
        /// </summary>
        /// <param name="Symbol"></param>
        /// <param name="UpdatePrice"></param>
        /// <param name="portfolioID"></param>
        /// <returns>true/false</returns>
        Task<bool> UpdateSymbolCurrentPriceofBuy(string? Symbol, decimal? UpdatePrice, Guid portfolioID);


    }
}