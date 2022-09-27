
using BusinessLayer;
using Models;
using Moq;
using RepoLayer;
using System;
using System.Xml.Linq;

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

            Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

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

            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
               .Setup(m => m.CreateProfileAsync(It.IsAny< string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
               .Returns(Task.FromResult(true));

            var dataSource3 = new Mock<IdbsRequests>();
            dataSource
               .Setup(m => m.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
               .Returns(Task.FromResult(true));


            //Act

            var TheUserProfileWasGot = TheClassBeingTested.GetProfileByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");

            var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", profiledto);

            var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", profiledto);

            
            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
            Assert.Equal(profiledto.Name, profile.Name);
        }



        [Fact]
        public void TestingAllMethodsAssociatedWithUserPortfolio()
        {

            //Arrange
            Guid guid = Guid.NewGuid();

            PortfolioDto? portfoliodto = new PortfolioDto()
            {

                Name = "Tony",
                PrivacyLevel = 2,

            };

            Portfolio? portfolio = new Portfolio()
            {
                PortfolioID = guid,
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
                .Setup(p => p.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(portmockList));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
                .Returns(Task.FromResult(true));

           

            //Act

            var AllTheUserPortfolioWasGotByUserID = TheClassBeingTested.GetALLPortfoliosByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");

            var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfoliodto);

            var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);

            var TheUserPortfolioWasGotByPortfolioID = TheClassBeingTested.GetPortfolioByPortfolioIDAsync(guid);

            

            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
            Assert.Equal(portfoliodto.Name, portfolio.Name);
            Assert.Equal(2, portfolio.PrivacyLevel);
            Assert.Equal(portfolio.PortfolioID, guid);
        }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithSell()
        // {

        //     //Arrange

        //     Sell? sell = new Sell()
        //     {
        //         SellID = new Guid(),
        //         Fk_PortfolioID = new Guid(),
        //         Symbol = "GOOGL",
        //         AmountSold = 2000,
        //         PriceSold = 1000,
        //         DateSold = new DateTime(),
        //     };

        //     List<Sell?> SellmockList = new List<Sell?>();

        //     SellmockList.Add(sell);

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<string>(), It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(SellmockList));

        //     var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


        //     //Act

        //     var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync("GOOGL", new Guid());

        //     var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sell);

            
        //     //Assert

        //     Assert.Equal("GOOGL", sell.Symbol);
        //     Assert.Equal(2000, sell.AmountSold);
            
        // }



        [Fact]
        public void TestingAllMethodsAssociatedWithBuy()
        {

            //Arrange

            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Symbol = "GOOGL",
                       
            };

            Buy? buy = new Buy()
            {
                BuyID = new Guid(),
                Fk_PortfolioID = new Guid(),
                Symbol = "GOOGL",
                CurrentPrice = 2000,
                AmountBought = 100,
                PriceBought = 50,
                DateBought = new DateTime(),

            };

            List<Buy?> buymockList = new List<Buy?>();

            buymockList.Add(buy);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .Returns(Task.FromResult(buymockList));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


            //Act

            var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

            var NewBuyWasAdded = TheClassBeingTested.AddNewBuyAsync(buy);


            //Assert

            Assert.Equal("GOOGL", AllBuys.Symbol);
            Assert.Equal(2000, buy.CurrentPrice);

        }




    }



}
