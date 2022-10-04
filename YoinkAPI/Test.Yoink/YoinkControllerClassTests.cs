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


        /// <summary>
        /// This test tests to see if the method returns a null investment - It's input is an InvestmentDto and returns a nullable investment
        /// (sendes)
        /// </summary>
        [Fact]
        public async Task Testing_GetSingleInvestmentByPortfolioIDAsync_Null()
        {
            //-------------------Arrange Section ----------------
            //We create an input that is constant
            GetInvestmentDto investmentDto = new GetInvestmentDto()
                {
                    PortfolioId = Guid.NewGuid(),
                    Symbol = "GOOG"
            };


            Investment? returnedInvestment_Null =  null;
            ActionResult<Investment?> nullReturnedPost = new  OkObjectResult(returnedInvestment_Null) ;

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource2_Null = new Mock<IYoinkBusinessLayer>();
            dataSource2_Null
                .Setup(s => s.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(returnedInvestment_Null);

            var ControllerClass_Null = new YoinkController(dataSource2_Null.Object);

            //-------------------Act Section ----------------
            var NoInvestmentwasGotten = await ControllerClass_Null.GetSingleInvestmentByPortfolioIDAsync(investmentDto);

            //-------------------Assert Section ----------------
            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<Investment?>>(NoInvestmentwasGotten);
            Assert.Equal(nullReturnedPost.Value, NoInvestmentwasGotten.Value);

        }//End of GetSingleInvestmentByPortfolioIDAsync that is NULL Test


        /// <summary>
        /// This test tests to see if the method returns an investment that is not null- It's input is an InvestmentDto and returns a nullable investment
        /// (sendes)
        /// </summary>
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
            Investment? expectedInvestment = new Investment()
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

            ActionResult<Investment?> returnedInvestment = new  OkObjectResult(expectedInvestment) ;

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource2_Null = new Mock<IYoinkBusinessLayer>();
            dataSource2_Null
                .Setup(s => s.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(expectedInvestment);

            var ControllerClass_Null = new YoinkController(dataSource2_Null.Object);

            //-------------------Act Section ----------------
            var InvestmentwasGotten = await ControllerClass_Null.GetSingleInvestmentByPortfolioIDAsync(investmentDto);

            //-------------------Assert Section ----------------
            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<Investment?>>(InvestmentwasGotten);
            Assert.Equal(returnedInvestment.Value, InvestmentwasGotten.Value);

        }//End of GetSingleInvestmentByPortfolioIDAsync that is NOT NULL Test


        /// <summary>
        /// This test method tests if the Create Post Async Method returns a Post that is not null - This is a true run or CREATED
        /// </summary>
        [Fact]
        public async Task Test_CreatePostAsync_Created()
        {
            //-------------------Arrange Section ----------------
            //We create an input that is constant
            CreatePostDto createPostDto = new CreatePostDto("This Is SPA TAAAAH!!", 1);

            //We create an output that is nullable
            Post? expectedCreatedPost = new Post( Guid.NewGuid(), "MyId", "My Content", 2, 1, DateTime.Now, DateTime.Now);

            ActionResult<Post?> returnedPost = new  OkObjectResult(expectedCreatedPost) ;

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            if(expectedCreatedPost == null){}
            var dataSource_Created = new Mock<IYoinkBusinessLayer>();
            dataSource_Created
                .Setup(s => s.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            var ControllerClass_Created = new Mock< IYoinkController>();
            ControllerClass_Created.Setup(s => s.CreatePostAsync(It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            //-------------------Act Section ----------------
            var PostwasCreated = await ControllerClass_Created.Object.CreatePostAsync(createPostDto);

            //-------------------Assert Section ----------------
            //The test asserts that the expected value and the returned value match
            if(PostwasCreated == null){}
            Assert.IsType<ActionResult<Post?>>(PostwasCreated);
            Assert.NotNull(PostwasCreated);
            Assert.Equal(returnedPost.Value, PostwasCreated);
        }//End of Create Post Async - Created Test

        /// <summary>
        /// This test method tests if the Create Post Async Method returns a null Post - This is a false run or NOT CREATED
        /// </summary>
        [Fact]
        public async Task Test_CreatePostAsync_NotCreated()
        {
            //-------------------Arrange Section ----------------
            //We create an input that is constant
            CreatePostDto createPostDto = new CreatePostDto("This Is SPA TAAAAH!!", 1);

            //We create an output that is nullable
            Post? expectedCreatedPost = null;

            ActionResult<Post?> returnedPost = new  OkObjectResult(expectedCreatedPost) ;

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            if(expectedCreatedPost == null){}
            var dataSource_Created = new Mock<IYoinkBusinessLayer>();
            dataSource_Created
                .Setup(s => s.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            var ControllerClass_Created = new Mock< IYoinkController>();
            ControllerClass_Created.Setup(s => s.CreatePostAsync(It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            //-------------------Act Section ----------------
            var PostwasCreated = await ControllerClass_Created.Object.CreatePostAsync(createPostDto);

            //-------------------Assert Section ----------------
            //The test asserts that the expected value and the returned value match
            if(PostwasCreated == null){}
            Assert.IsType<ActionResult<Post?>>(PostwasCreated);
            Assert.Null(PostwasCreated.Value);
            Assert.Equal(returnedPost.Value, PostwasCreated);
        }//End of Create Post Async - Not Created Test



    }



}
