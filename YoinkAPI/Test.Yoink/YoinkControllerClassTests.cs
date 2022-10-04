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

        [Fact]
        public async Task Testing_GetSingleInvestmentByPortfolioIDAsync_NOT_NULL()
        {
            //-------------------Arrange Section ----------------
            //We create an input that is constant
            GetInvestmentDto investmentDto = new GetInvestmentDto()
                {
                    PortfolioId = Guid.NewGuid(),
                    Symbol = "GOOG"
            };
            //We create an output that is nullable
            Investment? expectedCreatedPost = new Investment()
                {
                    InvestmentID = Guid.NewGuid(),
                    Fk_PortfolioID = Guid.NewGuid(),
                    Symbol = "AAPL",
                    AmountInvested = 10000,
                    CurrentAmount = 10000,
                    CurrentPrice = 10000,
                    TotalAmountBought = 10000,
                    TotalAmountSold = 10000,
                    AveragedBuyPrice = 10000,
                    TotalPNL = 10000,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
            };
            // Investment? returnedInvestment =  {};
            ActionResult<Investment?> returnedInvestment = new  OkObjectResult(expectedCreatedPost) ;
            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource2_Null = new Mock<IYoinkBusinessLayer>();
            dataSource2_Null
                .Setup(s => s.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(expectedCreatedPost);
            var ControllerClass_Null = new YoinkController(dataSource2_Null.Object);
            //-------------------Act Section ----------------
            var InvestmentwasGotten = await ControllerClass_Null.GetSingleInvestmentByPortfolioIDAsync(investmentDto);
            //-------------------Assert Section ----------------
            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<Investment?>>(InvestmentwasGotten);
            Assert.Equal(returnedInvestment.Value, InvestmentwasGotten.Value);
        }//End of GetSingleInvestmentByPortfolioIDAsync that is NOT NULL Test

        [Fact]
        public async Task TestingGetInvestmentsByPortfolioIDAsync()
        {
            //Arrange
            GetAllInvestmentsDto allInvestmentsDto = new GetAllInvestmentsDto()
            {
                PortfolioID = Guid.NewGuid(),
            };

            ActionResult<List<Investment>> expectedCreatedPost = new OkObjectResult(new List<Investment>());

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                    .Setup(s => s.GetAllInvestmentsByPortfolioIDAsync(It.IsAny<Guid>()))
                    .ReturnsAsync(new List<Investment>());

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act
            
            var AllInvestmentswereGotten = await ControllerClass.GetInvestmentsByPortfolioIDAsync(allInvestmentsDto);
        }


        [Fact]
        public async Task TestingGetInvestmentByTimeAsync()
        {
            //Arrange
            GetInvestmentByTimeDto investmentByTimeDto = new GetInvestmentByTimeDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "GOOG",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };
            ActionResult<List<Investment>> expectedCreatedPost = new OkObjectResult(new List<Investment>());

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                .Setup(s => s.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .ReturnsAsync(new List<Investment>());

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act

            var InvestmentwasGotten = await ControllerClass.GetInvestmentByTimeAsync(investmentByTimeDto);

            //Assert

            Assert.IsType<ActionResult<List<Investment>>>(InvestmentwasGotten);
            Assert.Equal(expectedCreatedPost.Value, InvestmentwasGotten.Value);

        }

        [Fact]
        public async Task TestingGetNumberOfUsersAsync()
        {
            //Arrange
            ActionResult<int> expectedCreatedPost = new OkObjectResult(1);

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                .Setup(s => s.GetNumberOfUsersAsync())
                .ReturnsAsync(1);

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act

            var NumberOfUsers = await ControllerClass.GetNumberOfUsersAsync();

            //Assert

            Assert.IsType<ActionResult<int>>(NumberOfUsers);
            Assert.Equal(expectedCreatedPost.Value, NumberOfUsers.Value);

        }

        [Fact]
        public async Task TestingGetNumberOfPostsAsync()
        {
            //Arrange
            ActionResult<int> expectedCreatedPost = new OkObjectResult(1);

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                .Setup(s => s.GetNumberOfPostsAsync())
                .ReturnsAsync(1);

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act

            var NumberOfPosts = await ControllerClass.GetNumberOfPostsAsync();

            //Assert

            Assert.IsType<ActionResult<int>>(NumberOfPosts);
            Assert.Equal(expectedCreatedPost.Value, NumberOfPosts.Value);
        }

        [Fact]
        public async Task TestingGetNumberOfBuysAsync()
        {
            //Arrange
            ActionResult<int> expectedCreatedPost = new OkObjectResult(1);

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                .Setup(s => s.GetNumberOfBuysAsync())
                .ReturnsAsync(1);

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act

            var NumberOfBuys = await ControllerClass.GetNumberOfBuysAsync();

            //Assert

            Assert.IsType<ActionResult<int>>(NumberOfBuys);
            Assert.Equal(expectedCreatedPost.Value, NumberOfBuys.Value);
        }

        [Fact]
        public async Task TestingGetNumberOfSellsAsync()
        {
            //Arrange
            ActionResult<int> expectedCreatedPost = new OkObjectResult(1);

            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                .Setup(s => s.GetNumberOfSellsAsync())
                .ReturnsAsync(1);

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act

            var NumberOfSells = await ControllerClass.GetNumberOfSellsAsync();

            //Assert

            Assert.IsType<ActionResult<int>>(NumberOfSells);
            Assert.Equal(expectedCreatedPost.Value, NumberOfSells.Value);
        }
    }
}
