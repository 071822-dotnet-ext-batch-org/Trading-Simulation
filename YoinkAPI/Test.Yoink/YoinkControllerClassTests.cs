using APILayer.Controllers;
using BusinessLayer;
using Models;
using Moq;
using RepoLayer;
using System;


namespace Test.Yoink
{
    public class YoinkControllerClassTests
    {


        [Fact]
        public void TestingAllMethodsAssociatedWithUserProfile()
        {
            //Arrange

            ProfileDto? profiledto = new ProfileDto()
            {

                Name = "Tony",
                Email = "Rodin@yahoo.com",
                Picture = "src/Picture",
                PrivacyLevel = 2,

            };

            Profile? profile = new Profile()
            {
                ProfileID = Guid.NewGuid(),
                Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
                Name = "Tony",
                Email = "Rodin@yahoo.com",
                Picture = "src/Picture",
                PrivacyLevel = 2

            };

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(profile));

            var TheClassBeingTested = new YoinkController(dataSource.Object);


            //Act

            var TheUserProfileWasGot = TheClassBeingTested.GetMyProfileAsync();

            var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync(profiledto);

            var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync(profiledto);


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

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(p => p.GetALLPortfoliosByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(portmockList));

            var TheClassBeingTested = new YoinkController(dataSource.Object);


            //Act

            var AllTheUserPortfolioWasGotByUserID = TheClassBeingTested.GetPortfoliosByUserIDAsync();

            var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync(portfoliodto);

            var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);

            var TheUserPortfolioWasGotByPortfolioID = TheClassBeingTested.GetPortfolioByPortfolioIDAsync(guid);



            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
            Assert.Equal(portfoliodto.Name, portfolio.Name);
            Assert.Equal(2, portfolio.PrivacyLevel);
            Assert.Equal(portfolio.PortfolioID, guid);
        }


        [Fact]
        public void TestingAllMethodsAssociatedWithBuy()
        {

            //Arrange
            Guid guid = Guid.NewGuid();

            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Symbol = "GOOGL",

            };

            BuyDto buydto = new BuyDto()
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

            BuyDto buyDTO = new BuyDto()
            {
                portfolioId = new Guid(),
                Symbol = "GOOGL",
                CurrentPrice = 2000,
                AmountBought = 100,
                PriceBought = 50,
            };

            List<Buy?> buymockList = new List<Buy?>();

            buymockList.Add(buy);

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .Returns(Task.FromResult(buymockList));

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            if(buy == null){}
            dataSource
                .Setup(b => b.AddNewBuyAsync(It.IsAny<BuyDto>()))
                .Returns(Task.FromResult(buy));

            var TheClassBeingTested = new YoinkController(dataSource.Object);

            var TheClassBeingTested2 = new YoinkController(dataSource2.Object);

            //Act

            var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

            var NewBuyWasAdded = TheClassBeingTested2.AddNewBuyAsync(buydto);


            //Assert

            Assert.Equal("GOOGL", AllBuys.Symbol);
            if (buy != null)
            {
                Assert.Equal(2000, buy.CurrentPrice);
            }

        }

        // }



        [Fact]
        public void TestingAllMethodsAssociatedWithSell()
        {

            //Arrange

            GetSellsDto getselldto1 = new GetSellsDto(new Guid(), "GOOGL");

            GetSellsDto getselldto = new GetSellsDto()
            {
                PortfolioId = new Guid(),
                Symbol = "GOOGL",

            };

            SellDto  sellDto = new SellDto()
            {
                Fk_PortfolioID = new Guid("2be4e71a-c21f-4b2c-9719-bb8a86b55e2b"),
                Symbol = "GOOGL",
                AmountSold = 1,
                PriceSold = 190
            };

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

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .Returns(Task.FromResult(SellmockList));

            var TheClassBeingTested = new YoinkController(dataSource.Object);

        //     var TheClassBeingTested = new YoinkController(dataSource.Object);

            //Act

            var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync(getselldto);

            // var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync("GOOGL", new Guid());

            var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sellDto);

        //     var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sell);

            //Assert

            Assert.Equal("GOOGL", sell.Symbol);
            Assert.Equal(2000, sell.AmountSold);
            Assert.Equal("GOOGL", sellDto.Symbol);
        }



    }



}
