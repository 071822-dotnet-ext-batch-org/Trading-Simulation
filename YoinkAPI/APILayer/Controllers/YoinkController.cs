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
                Profile? newProfile = await this._businessLayer.CreateProfileAsync(auth0Id, p);
                return (newProfile);
            }
            else return BadRequest(p);
        }


        [HttpGet("my-profile")]
        public async Task<Profile?> GetProfileByUserIDAsync()
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

        [HttpGet("my-portfolio")]
        public async Task<ActionResult<List<Portfolio?>>> GetPortfolioByUserIDAsync()
        {
            string? auth0Id = User.Identity?.Name;
            List<Portfolio?> retrievedPortfolio = await this._businessLayer.GetPortfolioByUserIDAsync(auth0Id);
            return Ok(retrievedPortfolio);
        }

        [HttpPut("edit-portfolio")]
        public async Task<Portfolio?> EditPortfolioAsync(string PortfolioID, string Name, int PrivacyLevel)
        {
            Portfolio? editedPortfolio = await this._businessLayer.EditPortfolioAsync(PortfolioID, Name, PrivacyLevel);
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


        [HttpGet("my-buys")]
        public async Task<List<Buy?>> GetAllBuyBySymbolAsync(string symbol, Guid portfolioID)
        {
            List<Buy?> buyList = await this._businessLayer.GetAllBuyBySymbolAsync(symbol, portfolioID);
            return (buyList);
        }

        [HttpGet("my-sell")]
        public async Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID)
        {
            List<Sell?> sellList = await this._businessLayer.GetAllSellBySymbolAsync(symbol, portfolioID);
            return (sellList);
        }



    }

}
