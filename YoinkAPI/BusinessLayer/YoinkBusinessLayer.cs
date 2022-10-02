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

    /// <summary>
    /// This creates a new profile for a new user.
    /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
    /// Requires logged in user via Auth0.
    /// </summary>
    /// <param name="auth0Id">contains authentication credentials</param>
    /// <param name="p">ProfileDto</param>
    /// <returns>new portfolio object</returns>
    public async Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p)
    {
        Profile? newProfile = null;

        if(p != null)
        {
            bool newProfileSaved = await this._repoLayer.CreateProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
            if (newProfileSaved && auth0Id != null)
            {
                newProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
            }
        }

        return newProfile;
    }

    /// <summary>
    /// Presents profile information to the user.
    /// Retrieves user info for posts.
    /// Requires logged in user via Auth0.        
    /// </summary>
    /// <returns>retrievedProfile Profile object</returns>
    public async Task<Profile> GetProfileByUserIDAsync(string? auth0Id)
    {
        if(auth0Id != null)
        {
            Profile? retrievedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
            if(retrievedProfile != null)
            {
                return (retrievedProfile);
            }
        }

        return new Profile();
    }

    public async Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p)
    {
        Profile? updatedProfile = null;
        if (p != null)
        {
            bool newProfileSaved = await this._repoLayer.EditProfileAsync(auth0Id, p.Name, p.Email, p.Picture, p.PrivacyLevel);
            if (newProfileSaved && auth0Id != null)
            {
                updatedProfile = await this._repoLayer.GetProfileByUserIDAsync(auth0Id);
            }
        }
        
        return updatedProfile;
    }

    /// <summary>
    /// Creates a new Portfolio for the user's profile.
    /// Takes PortfolioDto (portfolioID, name, originalLiquid, and privacyLevel)
    /// Requires logged in user via Auth0.      
    /// </summary>
    /// <param name="auth0Id">contains authentication credentials</param>
    /// <param name="p">PortfolioDto</param>
    /// <returns>new portfolio object</returns>
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

    /// <summary>
    /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
    /// </summary>
    /// <param name="p">PortfolioDto</param>
    /// <returns>updated portfolio object, named editedPortfolio</returns>
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

    /// <summary>
    /// Retrieves Portfolio based on PortfolioID. 
    /// Takes Guid of PortfolioID
    /// Requires logged in user via Auth0.      
    /// </summary>
    /// <param name="portfolioID">Guid from database</param>
    /// <returns>new portfolio object, named retrievedPortfolio</returns>
    public async Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID)
    {
        Portfolio? portfolio = await this._repoLayer.GetPortfolioByPorfolioIDAsync(portfolioID);
        return portfolio;
    }

    /// <summary>
    /// Retrieves ALL portfolios from the database which match the User's ID.
    /// Requires logged in user via Auth0.      
    /// </summary>
    /// <returns>new portfolio object</returns>
    public async Task<List<Portfolio?>> GetALLPortfoliosByUserIDAsync(string? auth0userID)
    {
        List<Portfolio?> getALL_portfolios = await this._repoLayer.GetALL_PortfoliosByUserIDAsync(auth0userID);
        return getALL_portfolios;
    }

    /// <summary>
    /// Adds user's purchase as a buy in the database.
    /// </summary>
    /// <param name="buy">BuyDto</param>
    /// <returns>Newly created Buy object</returns>
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

    public async Task<Sell?> AddNewSellAsync(SellDto sell)
    {
        //fix null bool in repo
        bool? check = await this._repoLayer.AddNewSellAsync(sell.Fk_PortfolioID, sell.Symbol, sell.AmountSold, sell.PriceSold);

        if (true == check)
        {
            Sell? createdSell = await this._repoLayer.GetRecentSellByPortfolioId(sell.Fk_PortfolioID);
            return (createdSell);
        }
        else return (null);

    }

    /// <summary>
    /// Returns all of user's buys for a particular Stock option (by symbol).
    /// Sendes really likes underscores.
    /// </summary>
    /// <param name="buysDto">Get_BuysDto</param>
    /// <returns>A list of Buy objects, named buyList.</returns>
    public async Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys)
    {
        List<Buy?> buyList = await this._repoLayer.GetAllBuyBySymbolAsync(AllBuys);
        return buyList;
    }

    /// <summary>
    /// Returns all of user's sells for a particular Stock option (by symbol).
    /// </summary>
    /// <param name="sellsDto">GetSellsDto</param>
    /// <returns>A list of sell objects, named sellList.</returns>
    public async Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto)
    {
        List<Sell?> sellList = await this._repoLayer.GetAllSellBySymbolAsync(sellsDto);
        return sellList;
    }

    /////////////////////

    /// <summary>
    /// Retrieves an investment by its associated PortfolioID.
    /// </summary>
    /// <param name="investmentDto"></param>
    /// <returns></returns>
    public async Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto)
    {
        Investment? investment = await this._repoLayer.GetInvestmentByPortfolioIDAsync(investmentDto);
        return investment;
    }

    /// <summary>
    /// Retrieves (potentially) a list of Investment objects from the database by time.
    /// </summary>
    /// <param name="investmentByTime">GetInvestmentByTimeDto</param>
    /// <returns>a list of Investment objects named returnedInvestment</returns>
    public async Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
    {
        List<Investment>? returnedInvestment = await this._repoLayer.GetInvestmentByTimeAsync(investmentByTime);
        return returnedInvestment;
    }

    /// <summary>
    /// Retrieves a count of users in the database.
    /// </summary>
    /// <returns>Integer count of users.</returns>
    public async Task<int?> GetNumberOfUsersAsync()
    {
        int? userCount = await this._repoLayer.GetNumberOfUsersAsync();
        return userCount;
    }

    /// <summary>
    /// Retrieves a count of all posts in the database.
    /// </summary>
    /// <returns>Integer count of posts.</returns>
    public async Task<int?> GetNumberOfPostsAsync()
    {
        int? userCount = await this._repoLayer.GetNumberOfPostsAsync();
        return userCount;
    }

    /// <summary>
    /// Retrieves a count of all buys in the database.
    /// </summary>
    /// <returns>Integer count of buys.</returns>
    public async Task<int?> GetNumberOfBuysAsync()
    {
        int? buysCount = await this._repoLayer.GetNumberOfBuysAsync();
        return buysCount;
    }

    /// <summary>
    /// Retrieves a count of all sells in the database.
    /// </summary>
    /// <returns>Integer count of sells.</returns>
    public async Task<int?> GetNumberOfSellsAsync()
    {
        int? sellsCount = await this._repoLayer.GetNumberOfSellsAsync();
        return sellsCount;
    }

    /// <summary>
    /// Allows the user to create a new post in the database.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="post">CreatePostDto</param>
    /// <returns>new Post object named createdPost.</returns>
    public async Task<Post?> CreatePostAsync(string auth0Id, CreatePostDto post)
    {
        //List<Post?> userList = null;    
        bool createdPost = await this._repoLayer.CreatePostAsync(auth0Id, post);
        if (createdPost)
        {
            Post? newPost = await this._repoLayer.GetRecentPostByUserId(auth0Id);
            return newPost;
        }
        return null;
    }

    /// <summary>
    /// Retrieves the full post feed from the database, ordered by time descending.
    /// The reason for the PostWithCommentCountDto is because the database table Posts lacked a count (int) of Comments.
    /// </summary>
    /// <returns>List of post objects, named returnedPosts.</returns>
    public async Task<List<PostWithCommentCountDto>> GetAllPostAsync()
    {
        List<PostWithCommentCountDto> listWithCommentCount = new List<PostWithCommentCountDto>();
        List<Post> returnedPosts = await this._repoLayer.GetAllPostAsync();
        foreach (Post post in returnedPosts)
        {
            int? count = await this._repoLayer.GetNumberOfCommentsByPostIdAsync(post.PostID);
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

    /// <summary>
    /// Retrieves all investments by the Portfolio's ID number.
    /// </summary>
    /// <param name="investmentDto">GetAllInvestmentsDto</param>
    /// <returns>A list of Investment objects populated with data from investmentDto named investment.</returns>
    public async Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID)
    {
        List<Investment?> investments = await this._repoLayer.GetAllInvestmentsByPortfolioIDAsync(portfolioID);
        return investments;
    }

    /// <summary>
    /// Allows user to update a created post in the database.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="editPostDto">EditPostDto</param>
    /// <returns>Updated post named editedPost</returns>
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

    /// <summary>
    /// Allows the user to delete their own post.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="postId">nullable Guid</param>
    /// <returns>Confirmation of deletion.</returns>
    public async Task<Guid?> DeletePostAsync(string? auth0UserId, Guid? postId)
    {
        string? user = await this._repoLayer.GetUserWithPostIdAsync(postId);
        if (auth0UserId == user)
        {
            bool deletePostCheck = await this._repoLayer.DeletePostAsync(postId);
            if (deletePostCheck)
            {
                return postId;
            }
            else return null;
        }
        else return null;
    }

    /// <summary>
    /// Allows user to retrieve all Posts from a particular user, along with comment count.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="userId">string</param>
    /// <returns>A list of PostWithCommentCountDto containing the returned posts along with a count of comments. This is required because the database table named Posts did not include a count (int) of Comments.</returns>
    public async Task<List<PostWithCommentCountDto>> GetAllPostByUserIdAsync(string userId)
    {
        List<PostWithCommentCountDto> listWithCommentCount = new List<PostWithCommentCountDto>();
        List<Post> returnedPosts = await this._repoLayer.GetAllPostByUserIdAsync(userId);
        foreach (Post post in returnedPosts)
        {
            int? count = await this._repoLayer.GetNumberOfCommentsByPostIdAsync(post.PostID);
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

    /// <summary>
    /// Allows user to click on a post they want to see details about, and retrieve the applicable details, e.g., comments, etc.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="postId"></param>
    /// <returns>A PostWithCommentCountDto object, named returnedPost, containing the returned posts along with a count of comments. This is required because the database table named Posts did not include a count (int) of Comments.</returns>
    public async Task<PostWithCommentCountDto?> GetPostByPostIdAsync(Guid? postId)
    {
        //fills post object with retrieved post
        Post? returnedPost = await this._repoLayer.GetPostByPostIdAsync(postId);


        //creates post object with the comment count added
        PostWithCommentCountDto? postWithCommentCountDto = new PostWithCommentCountDto();

        if (returnedPost != null)
        {
            //count int stores comment counts for that post
            int? count = await this._repoLayer.GetNumberOfCommentsByPostIdAsync(postId);

            //fills the postdto with values retrieved
            postWithCommentCountDto.PostID = returnedPost.PostID;
            postWithCommentCountDto.Fk_UserID = returnedPost.Fk_UserID;
            postWithCommentCountDto.Content = returnedPost.Content;
            postWithCommentCountDto.Likes = returnedPost.Likes;
            postWithCommentCountDto.Comments = count;
            postWithCommentCountDto.PrivacyLevel = returnedPost.PrivacyLevel;
            postWithCommentCountDto.DateCreated = returnedPost.DateCreated;
            postWithCommentCountDto.DateModified = returnedPost.DateModified;
            return postWithCommentCountDto;
        }

        else return null;
    }

    /// <summary>
    /// Allows the user to like a post.
    /// Requires logged in user via Auth0.  
    /// </summary>
    /// <param name="like"></param>
    /// <returns>likeCount integer, (and triggers a +1 like to the Post on the Posts table in the database.)</returns>
    public async Task<int?> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId)
    {

        bool createdLike = await this._repoLayer.CreateLikeOnPostAsync(like, auth0UserId);
        if (createdLike)
        {
            Post? post = await this._repoLayer.GetPostByPostId(like.PostId);
            return post?.Likes;
        }
        return null;
    }

    /// <summary>
    /// Deletes the user's like(s) on the selected post.
    /// </summary>
    /// <param name="unlike">LikeDto</param>
    /// <returns>updated likeCount integer, (and triggers a -1 like to the Post on the Posts table in the database.)</returns>
    public async Task<int?> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId)
    {
        bool removedLike = await this._repoLayer.DeleteLikeOnPostAsync(unlike, auth0UserId);
        if (removedLike)
        {
            Post? post = await this._repoLayer.GetPostByPostId(unlike.PostId);
            return post?.Likes;
        }
        return null;
    }

    /// <summary>
    /// Create a comment on a specific post.
    /// Requires logged in user via Auth0.
    /// </summary>
    /// <param name="comment">CommentDto</param>
    /// <returns>True if created, false if not.</returns>
    public async Task<bool> CreateCommentOnPostAsync(CommentDto comment, string? auth0UserId)
    {
        bool creationCheck = await this._repoLayer.CreateCommentOnPostAsync(comment, auth0UserId);
        return creationCheck;
    }

    /// <summary>
    /// Edit a comment's content.
    /// Requires logged in user via Auth0.
    /// </summary>
    /// <param name="comment">EditCommentDto</param>
    /// <returns>Edited comment object</returns>
    public async Task<Comment?> EditCommentAsync(EditCommentDto comment)
    {
        bool editCheck = await this._repoLayer.EditCommentAsync(comment);
        if (editCheck)
        {
            Comment? editedComment = await this._repoLayer.GetCommentByCommentIdAsync(comment.CommentId);
            return editedComment;
        }
        else return null;

    }


    /// <summary>
    /// Delete a comment and ensures user can delete only their own comment.
    /// Requires logged in user via Auth0.
    /// </summary>
    /// <param name="commentId">Id of comment to be deleted</param>
    /// <returns>True if deleted, false if not.</returns>
    public async Task<bool> DeleteCommentAsync(Guid commentId, string? auth0UserId)
    {
        string? user = await this._repoLayer.GetUserWithCommentIdAsync(commentId);
        if (auth0UserId == user)
        {
            bool deleteCommentCheck = await this._repoLayer.DeleteCommentAsync(commentId);
            return deleteCommentCheck;
        }
        else return false;
    }

    /// <summary>
    /// Get a lits of comment on a specific post.
    /// Requires logged in user via Auth0.
    /// </summary>
    /// <param name="postId">postId</param>
    /// <returns>A list of comments.</returns>
    public async Task<List<Comment>> GetCommentsByPostIdAsync(Guid postId)
    {
        List<Comment> comments = await this._repoLayer.GetCommentsByPostIdAsync(postId);
        return comments;
    }




    public async Task<LikeComment?> CreateLikeForCommentAsync(LikeForCommentDto createLikeForCommentDto, string auth0UserId)
    {
        LikeComment likedcomment = await this._repoLayer.CreateLikeForCommentAsync(createLikeForCommentDto, auth0UserId);
        return likedcomment;
    }


    public async Task<bool> DeleteLikeForCommentAsync(LikeForCommentDto deleteLikeForCommentDto, string? auth0UserId)
    {
        bool unlikedcomment = await this._repoLayer.DeleteLikeForCommentAsync(deleteLikeForCommentDto, auth0UserId);
        return unlikedcomment;
    }


    public async Task<int?> GetCountofCommentsByPostIdAsync(Guid? postId)
    {
        int? GotcommentCountByPostId = await this._repoLayer.GetCountofCommentsByPostIdAsync(postId);
        return GotcommentCountByPostId;
    }


    public async Task<AllUpdatedRowsDto> UpdateCurrentPriceAsync(UpdatePriceDto u, string auth0id)
    {
        AllUpdatedRowsDto aurdto = new AllUpdatedRowsDto();

        if(u.Symbol != null && u.Price != null)
        {
            bool updateBuys = await this._repoLayer.UpdateBuysCurrentPriceAsync(u);

            List<Buy> allUpdatedBuys = await this._repoLayer.GetAllBuyBySymbolNoPortfolioAsync(u.Symbol);
            
            List<Guid?> uniquePortfolioIDs = allUpdatedBuys.Select(b => b.Fk_PortfolioID).Distinct().ToList();
            
            bool updateInvestments = await this._repoLayer.UpdateInvestmentsCurrentPriceAsync(u);

            bool updatePortfolios = await this._repoLayer.UpdatePortfoliosCurrentPriceAsync(uniquePortfolioIDs);

            List<Portfolio?> myPortfolios = await this._repoLayer.GetALL_PortfoliosByUserIDAsync(auth0id);

            foreach (Portfolio? myP in myPortfolios)
            {
                if(uniquePortfolioIDs.Contains(myP?.PortfolioID))
                {
                    aurdto.Portfolios.Add(myP);
                }
            }

            foreach (Portfolio? p in aurdto.Portfolios)
            {
                if(p != null)
                {
                    GetInvestmentDto gidto = new GetInvestmentDto(p.PortfolioID, u.Symbol);
                    Investment? i = await this._repoLayer.GetInvestmentByPortfolioIDAsync(gidto);
                    
                    if (i != null)
                    {
                        aurdto.Investments.Add(i);
                    }
                }
            }
        }

        return aurdto;
    }

}

