using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using BusinessLayer;
using Models.ModelDTOs.BackToFrontEnd;

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


        [HttpGet("my-profile")]
        public async Task<ActionResult<Profile?>> GetMyProfileAsync()
        {
            string? auth0Id = User.Identity?.Name;
            Profile? retrievedProfile = await this._businessLayer.GetProfileByUserIDAsync(auth0Id);
            return Ok(retrievedProfile);
        }


        //added this to get user info for posts - rodin 
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

        //[AllowAnonymous]
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

        [HttpGet("my-portfolios")]
        public async Task<ActionResult<List<Portfolio?>>> GetPortfoliosByUserIDAsync()
        {
            string? auth0UserId = User.Identity?.Name;
            List<Portfolio?> retrievedPortfolios = await this._businessLayer.GetALLPortfoliosByUserIDAsync(auth0UserId);
            return Ok(retrievedPortfolios);
        }

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

        [HttpGet("my-sells")]
        public async Task<ActionResult<List<Sell?>>> GetAllSellBySymbolAsync(Models.GetSellsDto  sellsDto)
        {
            if(ModelState.IsValid)
            {
                 List<Sell?> sellList = await this._businessLayer.GetAllSellBySymbolAsync(sellsDto);
                 return Ok(sellList);
            }
            return BadRequest(sellsDto);
        }

        //Need an adult for trying out get requests in swagger
        //[AllowAnonymous]
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

        //[AllowAnonymous]
        //Swagger Tested
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







    }

}
