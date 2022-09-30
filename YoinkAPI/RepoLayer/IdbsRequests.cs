using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        //Profiles Section
        Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture ,int? Privacy);
        Task<bool> EditPortfolioAsync(Models.PortfolioDto p);
        Task<bool> EditProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy);
        Task<Profile?> GetProfileByUserIDAsync(string userID);

        //Buy and Sell Section
        Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought);
        Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold);
        Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys);
        Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto);
        Task<Buy?> GetRecentBuyByPortfolioId(Guid? portfolioId);
        Task<Sell?> GetRecentSellByPortfolioId(Guid? fk_PortfolioID);

        //Portfolio Section
        Task<Portfolio?> GetPortfolioByPorfolioIDAsync(Guid? porfolioID);
        Task<List<Portfolio?>> GetALL_PortfoliosByUserIDAsync(string? userID);
        Task<Portfolio?> GetRecentPortfoliosByUserIDAsync(string auth0Id);
        Task<bool> CreatePortfolioAsync(string auth0Id, PortfolioDto p);
        Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto);
        Task<List<Investment?>> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime);
        Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID);

        //Homepage
        Task<int> GetNumberOfUsersAsync();
        Task<int> GetNumberOfPostsAsync();
        Task<int> GetNumberOfBuysAsync();
        Task<int> GetNumberOfSellsAsync();

        //Post
        Task<List<Post?>> GetAllPostAsync();
        Task<bool> CreatePostAsync(string auth0Id, CreatePostDto post);
        Task<Post?> GetRecentPostByUserId(string auth0Id);
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