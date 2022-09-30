using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using BusinessLayer;
using Models.ModelDTOs.BackToFrontEnd;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class YoinkController : ControllerBase
    {
        private readonly IYoinkBusinessLayer _businessLayer;
        public YoinkController(IYoinkBusinessLayer iybl)
        {
            this._businessLayer = iybl;
        }

        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">ProfileDto</param>
        /// <returns>new portfolio object</returns>
        [HttpPost("create-profile")]
        public async Task<ActionResult<Profile?>> CreateProfileAsync(ProfileDto? p)
        {
            if (ModelState.IsValid)
            {
                string? auth0Id = User.Identity?.Name;
                Console.WriteLine(auth0Id);
                Profile? newProfile = await this._businessLayer.CreateProfileAsync(auth0Id, p);
                return Created("", newProfile);
            }
            else return BadRequest(p);
        }

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves nullable profile from the database.
        /// Requires logged in user via Auth0.        
        /// </summary>
        /// <returns>retrievedProfile Profile object</returns>
        [HttpGet("my-profile")]
        public async Task<ActionResult<Profile?>> GetMyProfileAsync()
        {
            string? auth0Id = User.Identity?.Name;
            Profile? retrievedProfile = await this._businessLayer.GetProfileByUserIDAsync(auth0Id);
            return Ok(retrievedProfile);
        }

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves user info for posts.  
        /// </summary>
        /// <returns>retrievedProfile Profile object</returns>
        [HttpPost("get-profile")]
        [AllowAnonymous]
        public async Task<ActionResult<Profile?>> GetProfileByUserIDAsync(GetProfileDto u)
        {
            Profile? retrievedProfile = await this._businessLayer.GetProfileByUserIDAsync(u.UserID);
            
            if (retrievedProfile==null)
            {
                return NotFound(new {userNotFound = u.UserID});
            }

            return Ok(retrievedProfile);
        }

        /// <summary>
        /// Updates user profile.
        /// Allows user to edit their ProfileDto (name, email, picture, privacyLevel) information.
        /// Requires logged in user via Auth0.        
        /// </summary>
        /// <returns>updatedProfile Profile object</returns>
        [HttpPut("edit-profile")]
        public async Task<ActionResult<Profile?>> EditProfileAsync(ProfileDto? p)
        {
            if (ModelState.IsValid)
            {
                string? auth0Id = User.Identity?.Name;
                Profile? updatedProfile = await this._businessLayer.EditProfileAsync(auth0Id, p);
                return Ok(updatedProfile);
            }
            else return BadRequest(p);
        }

        /// <summary>
        /// Creates a new Portfolio for the user's profile.
        /// Takes PortfolioDto (portfolioID, name, originalLiquid, and privacyLevel)
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">PortfolioDto</param>
        /// <returns>new portfolio object</returns>
        [HttpPost("create-portfolio")]
        public async Task<ActionResult<Portfolio?>> CreatePortfolioAsync(PortfolioDto? p)
        {
            if (ModelState.IsValid)
            {
                string? auth0Id = User.Identity?.Name;
                Portfolio? newPortfolio = await this._businessLayer.CreatePortfolioAsync(auth0Id, p);
                return Created("", newPortfolio);
            }
            else return BadRequest(p);
        }

        /// <summary>
        /// Retrieves Portfolio based on PortfolioID. 
        /// Takes Guid of PortfolioID
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="portfolioID">Guid from database</param>
        /// <returns>new portfolio object, named retrievedPortfolio</returns>
        [HttpPost("my-portfolio")]
        public async Task<ActionResult<Portfolio?>> GetPortfolioByPortfolioIDAsync(Guid? portfolioID)
        {
            if (ModelState.IsValid)
            {
                Portfolio? retrievedPortfolio = await this._businessLayer.GetPortfolioByPortfolioIDAsync(portfolioID);
                return Ok(retrievedPortfolio);
            }
            return BadRequest(portfolioID);
        }

        /// <summary>
        /// Retrieves ALL(SenDESCase) portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <returns>new portfolio object</returns>
        [HttpGet("my-portfolios")]
        public async Task<ActionResult<List<Portfolio?>>> GetPortfoliosByUserIDAsync()
        {
            string? auth0UserId = User.Identity?.Name;
            List<Portfolio?> retrievedPortfolios = await this._businessLayer.GetALLPortfoliosByUserIDAsync(auth0UserId);
            return Ok(retrievedPortfolios);
        }

        /// <summary>
        /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
        /// </summary>
        /// <param name="p">PortfolioDto</param>
        /// <returns>updated portfolio object, named editedPortfolio</returns>
        [HttpPut("edit-portfolio")]
        public async Task<ActionResult<Portfolio?>> EditPortfolioAsync(PortfolioDto p)
        {
            if(ModelState.IsValid)
            {
                Portfolio? editedPortfolio = await this._businessLayer.EditPortfolioAsync(p);
                return Ok(editedPortfolio);
            }
            return BadRequest(p);
        }

        /// <summary>
        /// Adds user's purchase as a buy in the database.
        /// </summary>
        /// <param name="buy">BuyDto</param>
        /// <returns>Newly created Buy object</returns>
        [HttpPost("create-buy")]
        public async Task<ActionResult<Buy>> AddNewBuyAsync(BuyDto buy)
        {
            if (ModelState.IsValid)
            {
                Buy? newBuy = await this._businessLayer.AddNewBuyAsync(buy);
                return Created("", newBuy);
            }
            else return BadRequest(buy);
        }

        /// <summary>
        /// Adds user's sell transaction as a sell in the database.
        /// </summary>
        /// <param name="sell"></param>
        /// <returns>Newly created sell object</returns>
        [HttpPost("create-sell")]
        public async Task<ActionResult<Sell>> AddNewSellAsync(SellDto sell)
        {
            if (ModelState.IsValid)
            {
                Sell? newSell = await this._businessLayer.AddNewSellAsync(sell);
                return Created("", newSell);
            }
            else return BadRequest(sell);
        }

        /// <summary>
        /// Returns all of user's buys for a particular Stock option (by symbol).
        /// Sendes really likes underscores.
        /// </summary>
        /// <param name="buysDto">Get_BuysDto</param>
        /// <returns>A list of Buy objects, named buyList.</returns>
        [HttpPost("my-buys")]
        public async Task<ActionResult<List<Buy?>>> GetAllBuyBySymbolAsync(Get_BuysDto buysDto)
        {
            if (ModelState.IsValid)
            {
                List<Buy?> buyList = await this._businessLayer.GetAllBuyBySymbolAsync(buysDto);
                return Ok(buyList);
            }
            else return BadRequest(buysDto);
        }

        /// <summary>
        /// Returns all of user's sells for a particular Stock option (by symbol).
        /// </summary>
        /// <param name="sellsDto">GetSellsDto</param>
        /// <returns>A list of sell objects, named sellList.</returns>
        [HttpPost("my-sell")]
        public async Task<ActionResult<List<Sell?>>> GetAllSellBySymbolAsync(GetSellsDto sellsDto)
        {
            if(ModelState.IsValid)
            {
                 List<Sell?> sellList = await this._businessLayer.GetAllSellBySymbolAsync(sellsDto);
                 return Ok(sellList);
            }
            return BadRequest(sellsDto);
        }

        /// <summary>
        /// Retrieves a single investment by the Portfolio's ID number.
        /// </summary>
        /// <param name="investmentDto">Models.GetInvestmentDto</param>
        /// <returns>Investment object populated with data from investmentDto named investment.</returns>
        [HttpPost("single-investment")]
        public async Task<ActionResult<Investment?>> GetSingleInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto)
        {
            if(ModelState.IsValid)
            {
                Investment? investment = await this._businessLayer.GetInvestmentByPortfolioIDAsync(investmentDto);
                return Ok(investment);
            }
            return BadRequest(investmentDto);
        }

        /// <summary>
        /// Retrieves all investments by the Portfolio's ID number.
        /// </summary>
        /// <param name="investmentDto">GetAllInvestmentsDto</param>
        /// <returns>A list of Investment objects populated with data from investmentDto named investment.</returns>
        [HttpPost("all-investments")]
        public async Task<ActionResult<List<Investment?>>> GetInvestmentsByPortfolioIDAsync(GetAllInvestmentsDto investmentDto)
        {
            if(ModelState.IsValid)
            {
                List<Investment?> investment = await this._businessLayer.GetAllInvestmentsByPortfolioIDAsync(investmentDto.PortfolioID);
                return Ok(investment);
            }
            return BadRequest(investmentDto);
        }

        /// <summary>
        /// Retrieves (potentially) a list of Investment objects from the database by time.
        /// </summary>
        /// <param name="investmentByTime">GetInvestmentByTimeDto</param>
        /// <returns>a list of Investment objects named returnedInvestment</returns>
        [HttpPost("my-investments-by-time")]
        public async Task<ActionResult<List<Investment>?>> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
        {
            if (ModelState.IsValid)
            {
                List<Investment>? returnedInvestment = await this._businessLayer.GetInvestmentByTimeAsync(investmentByTime);
                return Ok(returnedInvestment);
            }
            return BadRequest(investmentByTime);
        }

        [AllowAnonymous]
        [HttpGet("number-of-users")]
        public async Task<ActionResult<int>> GetNumberOfUsersAsync()
        {
            int userCount = await this._businessLayer.GetNumberOfUsersAsync();
            return Ok(userCount);   
        }

        [AllowAnonymous]
        [HttpGet("number-of-posts")]
        public async Task<ActionResult<int>> GetNumberOfPostsAsync()
        {
            int postCount = await this._businessLayer.GetNumberOfPostsAsync();
            return Ok(postCount);
        }

        [AllowAnonymous]
        [HttpGet("number-of-buys")]
        public async Task<ActionResult<int>> GetNumberOfBuysAsync()
        {
            int buyCount = await this._businessLayer.GetNumberOfBuysAsync();
            return Ok(buyCount);
        }


        [AllowAnonymous]
        [HttpGet("number-of-sells")]
        public async Task<ActionResult<int>> GetNumberOfSellsAsync()
        {
            int sellCount = await this._businessLayer.GetNumberOfSellsAsync();
            return Ok(sellCount);
        }

        
        [HttpPost("create-post")]
        public async Task<ActionResult<Post?>> CreatePostAsync(CreatePostDto post)
        {
            if (ModelState.IsValid)
            {
                string? auth0UserId = User.Identity?.Name;
                Post? createdPost = await this._businessLayer.CreatePostAsync(auth0UserId, post);
                return Created("", createdPost);
            }
            return BadRequest(post);
        }

        [AllowAnonymous]
        [HttpGet("get-all-post")]
        public async Task<ActionResult<List<PostWithCommentCountDto>>> GetAllPostsAsync()
        {
            List<PostWithCommentCountDto> returnedPosts = await this._businessLayer.GetAllPostAsync();
            return Ok(returnedPosts);
        }

        [HttpPut("edit-post")]
        public async Task<ActionResult<Post?>> UpdatePostAsync(EditPostDto editPostDto)
        {
            string? auth0UserId = User.Identity?.Name;
            Post? editedPost = await this._businessLayer.UpdatePostAsync(auth0UserId, editPostDto);
            return Ok(editedPost);
        }

        [HttpDelete("delete-post")]
        public async Task<ActionResult<Post?>> DeletePostAsync(Guid? postId)
        {
            string? auth0UserId = User.Identity?.Name;
            Guid? deletedPostId = await this._businessLayer.DeletePostAsync(auth0UserId, postId);
            return Ok(deletedPostId);
        }


        [HttpPost("get-userposts")]
        public async Task<ActionResult<List<PostWithCommentCountDto?>>> GetAllPostByUserIdAsync(string userId)
        {
            List<PostWithCommentCountDto> returnedPosts = await this._businessLayer.GetAllPostByUserIdAsync(userId);
            return Ok(returnedPosts);
        }

        [HttpPost("get-post")]
        public async Task<ActionResult<PostWithCommentCountDto?>> GetPostByPostIdAsync(Guid? postId)
        {
            PostWithCommentCountDto? returnedPost = await this._businessLayer.GetPostByPostIdAsync(postId);
            return Ok(returnedPost);
        }

        [HttpPost("add-like-on-post")]
        public async Task<ActionResult<int?>> CreateLikeOnPostAsync(LikeDto like)
        {
            if (ModelState.IsValid)
            {
                string? auth0UserId = User.Identity?.Name;
                int? likeCount = await this._businessLayer.CreateLikeOnPostAsync(like, auth0UserId);
                return Created("", likeCount);
            }
            else return BadRequest("Like did not get added");
        }

        [HttpDelete("remove-like-on-post")]
        public async Task<ActionResult<int?>> DeleteLikeOnPostAsync(LikeDto unlike)
        {
            if (ModelState.IsValid)
            {
                string? auth0UserId = User.Identity?.Name;
                int? likeCount = await this._businessLayer.DeleteLikeOnPostAsync(unlike, auth0UserId);
                return Created("", likeCount);
            }
            else return BadRequest("Like did not get removed");
        }
    }
}