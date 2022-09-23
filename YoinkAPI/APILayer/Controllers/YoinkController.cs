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
        public YoinkController (IYoinkBusinessLayer iybl)
        {
            this._businessLayer = iybl;   
        }



        [HttpPost("CreateProfileAsync")]
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


        [HttpGet("GetProfileByUserIDAsync")]
        public async Task<Profile?> GetProfileByUserIDAsync()
        {
                string? auth0Id = User.Identity?.Name;
                Profile? retrievedProfile = await this._businessLayer.GetProfileByUserIDAsync(auth0Id);
                return (retrievedProfile);
        }

        [HttpPut("EditProfileAsync")]
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


        // [HttpPost("CreatePortfolioAsync")]
        // public async Task<ActionResult<Portfolio?>> CreatePortfolioAsync(Portfolio? p)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         string? auth0Id = User.Identity?.Name;
        //         Portfolio? newPortfolio = await this._businessLayer.CreatePortfolioAsync(auth0Id, p);
        //         return (newPortfolio);
        //     }
        //     else return BadRequest(p);
        // }

        // [HttpGet("GetPortfolioeByUserIDAsync")]
        // public async Task<Portfolio?> GetPortfolioByUserIDAsync()
        // {
        //     string? auth0Id = User.Identity?.Name;
        //     Portfolio? retrievedPortfolio = await this._businessLayer.GetPortfolioByUserIDAsync(auth0Id);
        //     return (retrievedPortfolio);
        // }

       





        //[HttpPost("BuyAsync")]
        //public async ActionResult<bool> BuyAsync(Buy buy)
        //{}

        //[HttpPost("SellAsync")]
        //public async ActionResult<bool> BuyAsync(Sell sell)
        //{}
    }





}
