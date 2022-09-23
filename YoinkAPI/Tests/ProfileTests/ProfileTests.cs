using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using APILayer;
using RepoLayer;
using Models;
namespace ProfileTests;


public class ProfileTests: ControllerBase
{
    private readonly IYoinkBusinessLayer _businessLayer;
    private ProfileDto testDto1 = new ProfileDto("Test User", "email@email.com", 1);
    public ProfileTests (IYoinkBusinessLayer iybl)
    {
        this._businessLayer = iybl;   
    }
    [Fact]
    public void Test1()
    {
        //Arrange

        //Act

        //Assert

 
    }
    [Theory]
    [InlineData(new object[]{})]
    public async Task<IActionResult> CreateProfileAsync()
    {
        if (ModelState.IsValid)
        {
            string? auth0Id = User.Identity?.Name;
            // Profile? newProfile = await this._businessLayer.CreateProfileAsync(auth0Id, p);
            return Ok(testDto1);
        }
        else return BadRequest(testDto1); 
    }
}