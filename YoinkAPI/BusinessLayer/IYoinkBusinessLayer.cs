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
        // Task<Portfolio?> CreatePortfolioAsync(string? auth0Id, Portfolio? p);
        // Task<Portfolio?> GetPortfolioByUserIDAsync(string? auth0Id);
        Task<Profile?> CreateProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile?> EditProfileAsync(string? auth0Id, ProfileDto? p);
        Task<Profile?> GetProfileByUserIDAsync(string? auth0Id);
    }
}
