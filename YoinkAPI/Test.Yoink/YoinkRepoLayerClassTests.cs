
using System.Threading.Tasks;
using Models;
using RepoLayer;
using Moq;
using System;
using BusinessLayer;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace Test.Yoink
{
    public class YoinkRepoLayerClassTests
    {


        private Helpers helpers = new Helpers();

        // This method would test the CreateUserProfile

        [Fact]
        public async Task TestingCreateUserProfileReturnsBool()
        {

            // Arrange
            bool expectedReturn = true;
            Profile profile = helpers.fakeProfile();

            var fakeConfig = new Mock<IConfiguration>();

            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns(helpers.ConnString);


            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            string sql = "DELETE FROM Profiles WHERE fk_userID = @test1";

            SqlConnection conn = new SqlConnection(helpers.ConnString);

            bool? result = null;

            // Act

            using(SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@test1", "test1");

                bool truncated = await helpers.TruncateTableAsync(command, conn);

                if(truncated)
                {
                    result = await TheClassBeingTested.CreateProfileAsync("test1", profile.Name, profile.Email, profile.Picture, profile.PrivacyLevel);
                }
            }


            // Assert
            Assert.NotNull(result);
            if(result != null)
            {
                Assert.Equal(expectedReturn, result);
            }
        }

        public async Task TestingGetProfileByUserIDReturnsProfile()
        {
            // Arrange

            Profile expectedReturn = helpers.fakeProfile();
            expectedReturn.Fk_UserID = "test1";

            var fakeConfig = new Mock<IConfiguration>();

            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns(helpers.ConnString);


            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            // Act
            Profile? result = await TheClassBeingTested.GetProfileByUserIDAsync(expectedReturn.Fk_UserID);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReturn.ProfileID, result?.ProfileID);
        }

        [Fact]
        public async Task TestingUpdateInvestmentAsyncReturnsInvestment()
        {
            // Arrange
            Investment i = helpers.fakeInvestment();
            i.InvestmentID = new Guid("11322563-cf3a-462e-90f6-03bd0d7e0fdb");


            var fakeConfig = new Mock<IConfiguration>();

            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns(helpers.ConnString);


            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            // Act

            bool result = await TheClassBeingTested.UpdateInvestmentAsync(i);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task TestingEditProfileAsyncReturnsBoolAsync()
        {
            // Arrange
            Profile p = helpers.fakeProfile();
            p.Fk_UserID = "test1";

            var fakeConfig = new Mock<IConfiguration>();
            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns(helpers.ConnString);

            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            // Act
            bool result = await TheClassBeingTested.EditProfileAsync(p.Fk_UserID, p.Name, p.Email, p.Picture, p.PrivacyLevel);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task TestingGetALL_PortfoliosByUserIDAsyncReturnsListOfPortfolios()
        {
            // Arrange
            string userid = "test1";

            var fakeConfig = new Mock<IConfiguration>();
            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns(helpers.ConnString);

            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            // Act
            List<Portfolio?> result = await TheClassBeingTested.GetALL_PortfoliosByUserIDAsync(userid);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userid, result[0]?.Fk_UserID);

        }

    [Fact]
    public async Task UpdatePostAsync()
    {
      //Arrange
      var postId = "9fa85f64-5717-4562-b3fc-2c963f66afa6";
      var content = "update";
      var privacyLevel = 0;

      Post p = helpers.fakePost();

      var fakeconfig = new Mock<IConfiguration>();
      fakeconfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"]).Returns(helpers.ConnString);
      var TheClassBeingTested = new dbsRequests(fakeconfig.Object);

      //Act
      Post updated = await TheClassBeingTested.TestingUpdatePostAsyncReturnsUpdatedPostWithNewContentAndOrPrivacyLevel(p);

      //Assert
      Assert.Equal(p);
    }

    }// End of class
    //Need to add comments to everything!

}
