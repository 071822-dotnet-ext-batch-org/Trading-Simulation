using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models;
using BusinessLayer;

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
                return (newProfile);
            }
            else return BadRequest(p);
        }


        [HttpGet("my-profile")]
        public async Task<ActionResult<Profile?>> GetProfileByUserIDAsync()
        {
            string? auth0Id = User.Identity?.Name;
            Profile? retrievedProfile = await this._businessLayer.GetProfileByUserIDAsync(auth0Id);
            return (retrievedProfile);
        }

        [HttpPut("edit-profile")]
        public async Task<ActionResult<Profile?>> EditProfileAsync(ProfileDto? p)
        {
            if (ModelState.IsValid)
            {
                string? auth0Id = User.Identity?.Name;
                Profile? updatedProfile = await this._businessLayer.EditProfileAsync(auth0Id, p);
                return (updatedProfile);
            }
            else return BadRequest(p);
        }


        [HttpPost("create-portfolio")]
        public async Task<ActionResult<List<Portfolio?>>> CreatePortfolioAsync(PortfolioDto? p)
        {
            if (ModelState.IsValid)
            {
                string? auth0Id = User.Identity?.Name;
                List<Portfolio?> newPortfolio = await this._businessLayer.CreatePortfolioAsync(auth0Id, p);
                return Ok(newPortfolio);
            }
            else return BadRequest(p);
        }

        //[AllowAnonymous]
        [HttpGet("my-portfolio")]
        public async Task<ActionResult<Portfolio?>> GetPortfolioByPortfolioIDAsync(Guid? portfolioID)
        {
            Portfolio? retrievedPortfolio = await this._businessLayer.GetPortfolioByPortfolioIDAsync(portfolioID);
            return Ok(retrievedPortfolio);
        }

        [HttpGet("my-portfolios")]
        public async Task<ActionResult<List<Portfolio?>>> GetPortfoliosByUserIDAsync()
        {
            string? auth0UserId = User.Identity?.Name;
            List<Portfolio?> retrievedPortfolios = await this._businessLayer.GetALLPortfoliosByUserIDAsync(auth0UserId);
            return Ok(retrievedPortfolios);
        }

        [HttpPut("edit-portfolio")]
        public async Task<Portfolio?> EditPortfolioAsync(Models.PortfolioDto p)
        {
            Portfolio? editedPortfolio = await this._businessLayer.EditPortfolioAsync(p);
            return (editedPortfolio);
        }


        [HttpPost("create-buy")]
        public async Task<ActionResult<Buy>> AddNewBuyAsync(Buy buy)
        {
            if (ModelState.IsValid)
            {
                Buy? newBuy = await this._businessLayer.AddNewBuyAsync(buy);
                return (newBuy);
            }
            else return BadRequest(buy);
        }


        [HttpPost("create-sell")]
        public async Task<ActionResult<Sell>> AddNewSellAsync(Sell sell)
        {
            if (ModelState.IsValid)
            {
                Sell? newSell = await this._businessLayer.AddNewSellAsync(sell);
                return (newSell);
            }
            else return BadRequest(sell);
        }


        [HttpPost("my-buys")]
        public async Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto buysDto)
        {
            List<Buy?> buyList = await this._businessLayer.GetAllBuyBySymbolAsync(buysDto);
            return (buyList);
        }

        [HttpPost("my-sell")]
        public async Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto)
        {
            List<Sell?> sellList = await this._businessLayer.GetAllSellBySymbolAsync(sellsDto);
            return (sellList);
        }

        //Need an adult for trying out get requests in swagger
        //[AllowAnonymous]
        [HttpPost("my-investments")]
        public async Task<ActionResult<Investment?>> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto)
        {
            Investment? investment = await this._businessLayer.GetInvestmentByPortfolioIDAsync(investmentDto);
            return (investment);
        }

        //[AllowAnonymous]
        //Swagger Tested
        [HttpPost("my-investments-by-time")]
        public async Task<ActionResult<List<Investment>?>> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
        {
            List<Investment>? returnedInvestment = await this._businessLayer.GetInvestmentByTimeAsync(investmentByTime);
            return returnedInvestment;
        }

        [AllowAnonymous]
        [HttpGet("number-of-users")]
        public async Task<ActionResult<int>> GetNumberOfUsersAsync()
        {
            int userCount = await this._businessLayer.GetNumberOfUsersAsync();
            return userCount;   
        }

        [AllowAnonymous]
        [HttpGet("number-of-posts")]
        public async Task<ActionResult<int>> GetNumberOfPostsAsync()
        {
            int postCount = await this._businessLayer.GetNumberOfPostsAsync();
            return postCount;
        }

        [AllowAnonymous]
        [HttpGet("number-of-buys")]
        public async Task<ActionResult<int>> GetNumberOfBuysAsync()
        {
            int buyCount = await this._businessLayer.GetNumberOfBuysAsync();
            return buyCount;
        }


        [AllowAnonymous]
        [HttpGet("number-of-sells")]
        public async Task<ActionResult<int>> GetNumberOfSellsAsync()
        {
            int sellCount = await this._businessLayer.GetNumberOfSellsAsync();
            return sellCount;
        }
    
    
    
    
    
    
    
    }

}
