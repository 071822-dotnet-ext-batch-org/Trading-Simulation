using Models;

namespace RepoLayer
{
    public interface IdbsRequests
    {
        Task<Profile?> CreateProfileAsync(string userID, string Name, string Email, int Privacy);
        Task<Profile?> EditProfileAsync(string userID, string Name, string Email, int Privacy);
        Task<Profile?> GetProfileByUserIDAsync(string userID);
    }
}