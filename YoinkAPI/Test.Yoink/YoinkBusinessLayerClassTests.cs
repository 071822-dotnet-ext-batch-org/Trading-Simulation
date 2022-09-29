

using BusinessLayer;
using Models;
using Moq;
using RepoLayer;

namespace Test.Yoink
{
    public class YoinkBusinessLayerClassTests
    {


        [Fact]
        public void TestingAllMethodsAssociatedWithUserProfile()
        {
            //Arrange

            ProfileDto? profiledto = new ProfileDto()
            {
               
                Name = "Tony",
                Email = "Rodin@yahoo.com",
                PrivacyLevel = 2,

            };

            Profile? profile = new Profile()
            {
                ProfileID = Guid.NewGuid(),
                Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
                Name = "Tony",
                Email = "Rodin@yahoo.com",
                PrivacyLevel = 2,
                   
            };

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(profile));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            //Act

            var TheUserProfileWasGot = TheClassBeingTested.GetProfileByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");

            var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", profiledto);

            var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", profiledto);

            
            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
            Assert.Equal(profiledto.Name, profile.Name);
        }//END OF TestingAllMethodsAssociatedWithUserProfile



        [Fact]
        public void TestingAllMethodsAssociatedWithUserPortfolio()
        {

            //Arrange

            PortfolioDto? portfoliodto = new PortfolioDto()
            {
                PortfolioID = Guid.NewGuid(),
                Name = "Tony",
                OriginalLiquid = 2000,
                PrivacyLevel = 2,
                


            };

            Portfolio? portfolio = new Portfolio()
            {
                PortfolioID = Guid.NewGuid(),
                Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
                Name = "Tony",
                PrivacyLevel = 2,
                Type = 2,
                OriginalLiquid = 2000,
                CurrentInvestment = 1000,
                Liquid = 2500,
                CurrentTotal = 2300,
                Symbols = 34,
                TotalPNL = 600,
                DateCreated = new DateTime(),
                DateModified = new DateTime(),
            };

            List<Portfolio?> portmockList = new List<Portfolio?>();

            portmockList.Add(portfolio);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid?>()))
                .Returns(Task.FromResult(portfolio));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            //Act Task<Portfolio?> GetPortfolioByPortfolioIDAsync(Guid? portfolioID);

            var TheUserPortfolioWasGot = TheClassBeingTested.GetPortfolioByPortfolioIDAsync(Guid.NewGuid());

            var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfoliodto);

            var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);


            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
            Assert.Equal(portfoliodto.Name, portfolio.Name);
            Assert.Equal(2, portfolio.PrivacyLevel);
        }//END OF TestingAllMethodsAssociatedWithUserPortfolio


        [Fact]
        public void TestingAllMethodsAssociatedSell()
        {

            //Arrange

            Sell? sell = new Sell()
            {
                SellID = new Guid(),
                Fk_PortfolioID = new Guid(),
                Symbol = "GOOGL",
                AmountSold = 2000,
                PriceSold = 1000,
                DateSold = new DateTime(),
            };

            List<Sell?> SellmockList = new List<Sell?>();

            SellmockList.Add(sell);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(SellmockList));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            //Act

            var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync("GOOGL", new Guid());

            var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sell);

            


            //Assert

            Assert.Equal("GOOGL", sell.Symbol);
            Assert.Equal(2000, sell.AmountSold);
            
        }//END OF TestingAllMethodsAssociatedSell


        [Fact]
        public void TestingAllMethodsPosts()
        {

            //Arrange

            Post? post = new Post()
            {
                PostID = new Guid(),
                Fk_UserID = new Guid(),
                Content = "New Content",
                Likes = 0,
                PrivacyLevel = 1000,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            CreatePostDto postDto = new CreatePostDto()
            {

            };

            List<Post?> PostsmockList = new List<Post?>();

            PostsmockList.Add(post);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(s => s.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
                .Returns(Task.FromResult(PostsmockList));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            //Act

            var AllPostWasGotByUserID = TheClassBeingTested.CreatePostAsync("UserID");

            var NewPostWasAdded = TheClassBeingTested.AddNewSellAsync("UserID", CreatePostDto );

            


            //Assert

            Assert.Equal("GOOGL", sell.Symbol);
            Assert.Equal(2000, sell.AmountSold);
            
        }//END OF TestingAllMethodsPosts







    }



}
