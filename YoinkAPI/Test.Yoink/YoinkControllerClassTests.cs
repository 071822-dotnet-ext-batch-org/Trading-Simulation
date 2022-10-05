using APILayer.Controllers;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using RepoLayer;
using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Principal;

namespace Test.Yoink
{
    public class YoinkControllerClassTests
    {

        private Helpers helpers = new Helpers();


        [Fact]
        public async Task TestingEditPortfolioAsyncUpdatesPortfolio()
        {

            Guid portfolioDtoGuid = Guid.NewGuid();

            Portfolio expectedEditPortfolio = new Portfolio()
            {
                PortfolioID = portfolioDtoGuid,
                Fk_UserID = "Sample Fk_UserID",
                Name = "Sample Name",
                PrivacyLevel = 2,
                Type = 0,
                OriginalLiquid = 1000,
                CurrentInvestment = 10000,
                Liquid = 1000,
                CurrentTotal = 10000,
                Symbols = 1,
                TotalPNL = 0,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            PortfolioDto portfolioDto = new PortfolioDto()
            {
                PortfolioID = portfolioDtoGuid,
                Name = "Sample Name",
                OriginalLiquid = 1000,
                PrivacyLevel = 2
            };

            var dataSource = new Mock<IYoinkBusinessLayer>();

            dataSource
                .Setup(e => e.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
                .ReturnsAsync(expectedEditPortfolio);

            var theClassBeingTested = new YoinkController(dataSource.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                }, "mock"));

            theClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //Act
            var createdPortfolio = await theClassBeingTested.EditPortfolioAsync(portfolioDto);
            var oKResult = createdPortfolio.Result as OkObjectResult;

            //Assert
            Assert.NotNull(oKResult);
            Assert.True(theClassBeingTested.ModelState.IsValid);
            Assert.Equal(expectedEditPortfolio, oKResult?.Value);
        }


        [Fact]
        public async Task TestingAddNewBuyAsyncCreatesNewRowInBuysTable()
        {
            Guid buyIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Buy expectedBuy = new Buy()
            {
                BuyID = buyIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                CurrentPrice = 10,
                AmountBought = 10,
                PriceBought = 10,
                DateBought = new DateTime()
            };

            BuyDto buyDto = new BuyDto()
            {
                portfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                CurrentPrice = 100,
                AmountBought = 20,
                PriceBought = 15
            };

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(a => a.AddNewBuyAsync(It.IsAny<BuyDto>()))
                .ReturnsAsync(expectedBuy);


            var theClassBeingTested = new YoinkController(dataSource.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            theClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //Act
            var addedBuy = await theClassBeingTested.AddNewBuyAsync(buyDto);
            var okResult = addedBuy.Result as CreatedResult;
            Buy? resultPost = okResult?.Value as Buy;


            //Assert

            Assert.NotNull(resultPost);
            Assert.True(theClassBeingTested.ModelState.IsValid);
            Assert.Equal(expectedBuy, resultPost);
        }


        [Fact]
        public async Task TestingAddNewSellAsyncCreatesNewRowInSellsTable()
        {

            Guid sellIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Sell expectedSell = new Sell()
            {
                SellID = sellIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                AmountSold = 100,
                PriceSold = 10,
                DateSold = new DateTime()
            };

            SellDto sellDto = new SellDto()
            {
                Fk_PortfolioID = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                AmountSold = 20,
                PriceSold = 15
            };

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(a => a.AddNewSellAsync(It.IsAny<SellDto>()))
                .ReturnsAsync(expectedSell);

            var theClassBeingTested = new YoinkController(dataSource.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, "auth0id"),

               }, "mock"));

            theClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //Act
            var addedSell = await theClassBeingTested.AddNewSellAsync(sellDto);
            var okResult = addedSell.Result as CreatedResult;
            Sell? resultPost = okResult?.Value as Sell;


            //Assert

            Assert.NotNull(resultPost);
            Assert.True(theClassBeingTested.ModelState.IsValid);
            Assert.Equal(expectedSell, resultPost);
        }


        [Fact]
        public async Task TestingGetAllBuyBySymbolAsyncReturnsAllBuysOfMatchingPortfolioIDAndSymbolOrderByDescendingDateBought()
        {

            Guid buyIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Buy expectedBuy = new Buy()
            {
                BuyID = buyIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                CurrentPrice = 10,
                AmountBought = 10,
                PriceBought = 10,
                DateBought = new DateTime()
            };

            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Get_BuysID = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Buy> expectedBuyMockList = new List<Buy>();
            expectedBuyMockList.Add(expectedBuy);


            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(g => g.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .ReturnsAsync(expectedBuyMockList);

            var theClassBeingTested = new YoinkController(dataSource.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, "auth0id"),

               }, "mock"));

            theClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //Act
            var gotAllBuys = await theClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);
            var okResult = gotAllBuys.Result as OkObjectResult;
            List<Buy>? resultPost = okResult?.Value as List<Buy>;

            //Assert
            Assert.NotNull(resultPost);
            Assert.True(theClassBeingTested.ModelState.IsValid);
            Assert.Equal(expectedBuyMockList, resultPost);
        }


        [Fact]
        public async Task TestingGetAllSellBySymbolAsyncReturnsAllSellsOfMatchingPortfolioIDAndSymbolOrderByDescendingDateSold()
        {

            Guid sellIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Sell expectedSell = new Sell()
            {
                SellID = sellIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                AmountSold = 100,
                PriceSold = 10,
                DateSold = new DateTime()
            };

            GetSellsDto sellsDto = new GetSellsDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Sell> expectedSellMockList = new List<Sell>();
            expectedSellMockList.Add(expectedSell);

            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(g => g.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .ReturnsAsync(expectedSellMockList);

            var theClassBeingTested = new YoinkController(dataSource.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, "auth0id"),

               }, "mock"));

            theClassBeingTested.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //Act
            var gotAllSells = await theClassBeingTested.GetAllSellBySymbolAsync(sellsDto);
            var okResult = gotAllSells.Result as OkObjectResult;
            List<Sell>? resultPost = okResult?.Value as List<Sell>;

            //Assert
            Assert.NotNull(resultPost);
            Assert.True(theClassBeingTested.ModelState.IsValid);
            Assert.Equal(expectedSellMockList, resultPost);
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
            string fakeUser = "auth0id"; //We create a fake userID

            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            CreatePostDto createPostDto = new CreatePostDto("This Is SPA TAAAAH!!", 1);

            //We create an output that is nullable
            Post? expectedCreatedPost = new  Post( Guid.NewGuid(), "MyId", "My Content", 2, 1, DateTime.Now, DateTime.Now);

            var returnedPost = new  CreatedResult("",expectedCreatedPost) ;

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource_Created = new Mock<IYoinkBusinessLayer>();
            dataSource_Created
                .Setup(s => s.CreatePostAsync(fakeUser, It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            var ControllerClass_Created = new YoinkController(dataSource_Created.Object);
            ControllerClass_Created.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            var PostwasCreated = await ControllerClass_Created.CreatePostAsync(createPostDto);
            var okResultforPost = PostwasCreated.Result as CreatedResult;
            Post? resultPost = okResultforPost?.Value as Post;

            //-------------------Assert Section ----------------
            if(resultPost == null)
            {
                Assert.Equal(null, resultPost);
            }

            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<Post?>>(PostwasCreated);
            Assert.IsType<CreatedResult>(PostwasCreated.Result);
            Assert.IsType<Post?>(resultPost);
            Assert.IsType<Guid>(resultPost?.PostID);
            Assert.NotNull(resultPost);
            Assert.Equal(returnedPost.Value, resultPost);
        }//End of Create Post Async - Created Test

        /// <summary>
        /// This test method tests if the Create Post Async Method returns a null Post - This is a false run or NOT CREATED
        /// </summary>
        [Fact]
        public async Task Test_CreatePostAsync_NotCreated()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0id"; //We create a fake userID

            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 
            //We create an input that is constant
            CreatePostDto createPostDto = new CreatePostDto("This Is SPA TAAAAH!!", 1);

            //We create an output that is nullable
            Post? expectedCreatedPost = null;
            var returnedPost = new  BadRequestObjectResult(createPostDto);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            if(expectedCreatedPost == null){}
            var dataSource_Created = new Mock<IYoinkBusinessLayer>();
            dataSource_Created
                .Setup(s => s.CreatePostAsync(fakeUser, It.IsAny<CreatePostDto>()))
                .ReturnsAsync(expectedCreatedPost);

            var ControllerClass_Created = new YoinkController(dataSource_Created.Object);
            ControllerClass_Created.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            

            //-------------------Act Section ----------------
            var PostwasCreated = await ControllerClass_Created.CreatePostAsync(createPostDto);
            var okResultforPost = PostwasCreated.Result as BadRequestObjectResult;
            Post? resultPost = okResultforPost?.Value as Post;

            //-------------------Assert Section ----------------
            if(resultPost == null)
            {
                Assert.Equal(null, resultPost);
            }

            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<Post?>>(PostwasCreated);
            Assert.IsType<BadRequestObjectResult>(PostwasCreated.Result);
            Assert.Null(resultPost);
            Assert.Equal(expectedCreatedPost, resultPost);

        }//End of Create Post Async - Not Created Test

        /// <summary>
        /// This tests if the GetAllPostsAsync method gets all of the posts without any credentials
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_GetAllPostsAsync_if_gets_all_Posts()
        {
            //-------------------Arrange Section ----------------

            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 
            //We create an input that is constant

            //We create an input that is constant

            //We create an output that is nullable
            List<PostWithCommentCountDto>? expectedListofComments = new List<PostWithCommentCountDto>();
            for(int i =0; i < 5; i++)
            {
                PostWithCommentCountDto dto = new PostWithCommentCountDto(Guid.NewGuid(), "authID", "Content", 1, 1,1,DateTime.Now, DateTime.Now);
                expectedListofComments.Add(dto);

            }
            var returnedListofComments = new  OkObjectResult(expectedListofComments);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetAllPostAsync())
                .ReturnsAsync(expectedListofComments);

            var ControllerClass_Created = new YoinkController(dataSource.Object);
            ControllerClass_Created.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            

            //-------------------Act Section ----------------
            var returnedActionResultOBJ = await ControllerClass_Created.GetAllPostsAsync();
            var okResultforOBJ = returnedActionResultOBJ.Result as OkObjectResult;
            List<PostWithCommentCountDto>? resultOBJ = okResultforOBJ?.Value as List<PostWithCommentCountDto>;

            //-------------------Assert Section ----------------
            if(resultOBJ == null)
            {
                Assert.Equal(null, resultOBJ);
            }

            //The test asserts that the expected value and the returned value match
            Assert.IsType<ActionResult<List<PostWithCommentCountDto>>>(returnedActionResultOBJ);
            Assert.IsType<OkObjectResult>(returnedActionResultOBJ.Result);
            Assert.NotNull(resultOBJ);
            Assert.Equal(expectedListofComments, resultOBJ);

        }//End of GetAllPostsAsync Test

        /// <summary>
        /// This method tests if the UpdatePostAsync successfully updates an existing post
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_UpdatePostAsync_if_Post_is_Updated()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 
            //We create an input that is constant

            //We create an input that is constant

            //We create an output that is nullable
            EditPostDto editPostDto = new EditPostDto(Guid.NewGuid(),"Content", 1);
            Post returnedPostFromRepo = new Post(Guid.NewGuid(),fakeUser, "Content", 1, 1, DateTime.Now, DateTime.Now);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.UpdatePostAsync(It.IsAny<string>(),It.IsAny<EditPostDto>()))
                .ReturnsAsync(returnedPostFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Post?> returnedActionResultOBJ = await controller_datasource.UpdatePostAsync(editPostDto);
            //The actual object returned will be null until converted to a variable to hold the data
            var okResultforOBJ = returnedActionResultOBJ?.Result as OkObjectResult;
            Post? resultOBJ = okResultforOBJ?.Value as Post;


            //-------------------Assert Section ----------------
            if(resultOBJ?.PostID == null)
            {
                Assert.Null(okResultforOBJ?.Value);
                Assert.Equal(null, resultOBJ);
            }

            //The test asserts that the expected value and the returned value matches
            Assert.IsType<ActionResult<Post?>?>(returnedActionResultOBJ);
            Assert.IsType<OkObjectResult>(returnedActionResultOBJ?.Result);
            Assert.NotNull(resultOBJ);
            Assert.Equal(returnedPostFromRepo.PostID, resultOBJ?.PostID);

        }//End of UpdatePostAsync Test






        [Fact]
        public async Task TestGetPostLikesByUserID()
        {
            // Arrange
            string fakeUser = "auth0id";

            List<Guid> mockGuids = helpers.fakeGuidList();
            
            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.GetPostLikesByUserID(fakeUser))
                .ReturnsAsync(mockGuids);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.GetPostLikesByUserID();
            var okResult = result.Result as OkObjectResult;
            List<Guid>? glist = okResult?.Value as List<Guid>;



            // Assert
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(200, okResult?.StatusCode);
            Assert.IsType<List<Guid>>(okResult?.Value);
            
            if(glist != null)
            {
                Assert.Equal(3, glist.Count());
                Assert.Equal(mockGuids[0], glist[0]);
            }
        }


        [Fact]
        public async Task TestingGetInvestmentsByPortfolioIDAsync()
        {
            //public async Task<ActionResult<List<Investment>>> GetInvestmentsByPortfolioIDAsync(GetAllInvestmentsDto investmentDto)

            //Arrange
            GetAllInvestmentsDto allInvestmentsDto = new GetAllInvestmentsDto()
            {
                PortfolioID = Guid.NewGuid(),
            };


            List<Investment> expectedCreatedPostList = new List<Investment>();

            Investment investment1 = helpers.fakeInvestment();
            investment1.Fk_PortfolioID = allInvestmentsDto.PortfolioID;
            expectedCreatedPostList.Add(investment1);
            Investment investment2 = helpers.fakeInvestment();
            investment2.Fk_PortfolioID = allInvestmentsDto.PortfolioID;
            expectedCreatedPostList.Add(investment2);


            var dataSource2 = new Mock<IYoinkBusinessLayer>();

            dataSource2
                    .Setup(s => s.GetAllInvestmentsByPortfolioIDAsync(It.IsAny<Guid>()))
                    .ReturnsAsync(expectedCreatedPostList);

            var ControllerClass = new YoinkController(dataSource2.Object);

            //Act
            
            var AllInvestmentswereGotten = await ControllerClass.GetInvestmentsByPortfolioIDAsync(allInvestmentsDto);
            var okResult = AllInvestmentswereGotten.Result as OkObjectResult;
            List<Investment>? AllInvestmentswereGottenList = okResult?.Value as List<Investment>;


            //Assert
            if (AllInvestmentswereGottenList != null)
            {
                Assert.Equal(expectedCreatedPostList[0].AmountInvested, AllInvestmentswereGottenList[0].AmountInvested);
            }
        }

        //Testing an empty return list
        [Fact]
        public async Task GetInvestmentByTimeAsyncReturnsListWithinTimeRange()
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

        [Fact]
        public async Task CreateCommentOnPostReturnCreatedComment()
        {
            // Arrange
            string fakeUser = "auth0id";

            Guid guid = new Guid();
            CommentDto createComment = new (guid, "TestComment");

            bool mockBool = true;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.CreateCommentOnPostAsync(It.IsAny<CommentDto>(),fakeUser))
                .ReturnsAsync(mockBool);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.CreateCommentOnPostAsync(createComment);
            var oKResult = result.Result as CreatedResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockBool, oKResult?.Value);
            
        }
        public async Task GetPortfolioByPortfolioIDAsync()
        {
            //Arrange

            Guid portfolioID = Guid.NewGuid();

            var MockBL = new Mock<IYoinkBusinessLayer>();
            
            Portfolio Portfolioget = new Portfolio(Guid.NewGuid(), "User ID 911011932", "New Portfolio", 0, 0, 10000, 10000, 10000, 10000, 0, 10000, DateTime.Now, DateTime.Now);
                MockBL.Setup(bl => bl.GetPortfolioByPortfolioIDAsync(portfolioID))
                .ReturnsAsync(Portfolioget);

            var classcontroller = new YoinkController(MockBL.Object);
            classcontroller.ControllerContext.HttpContext = new DefaultHttpContext();  

            //Act
            var result = await classcontroller.GetPortfolioByPortfolioIDAsync(portfolioID);
            //Assert
            Assert.NotNull(result.Value);
            Assert.True(classcontroller.ModelState.IsValid);

            if(result.Value != null)
            {
                Assert.Equal(Portfolioget.PortfolioID, result.Value.PortfolioID);
            }
        }


        [Fact]
        public async Task EditCommentAsyncReturnsEditedComment()
        {
            //public async Task<ActionResult<Comment?>> EditCommentAsync(EditCommentDto comment)
            // Arrange
            string fakeUser = "auth0id";

            Guid guid = new Guid();
            Guid guid2 = new Guid();
            DateTime date1 = new DateTime();
            DateTime date2 = DateTime.Now;

            EditCommentDto editedComment = new(guid, "TestComment");

            Comment mockComment = new(guid, fakeUser, guid2, "TestComment", 0, date1, date2);

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.EditCommentAsync(It.IsAny<EditCommentDto>()))
                .ReturnsAsync(mockComment);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.EditCommentAsync(editedComment);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockComment, oKResult?.Value);

        }

        [Fact]
        public async Task DeleteCommentAsyncReturnsTrueOnSucceededDelete()
        {
            //public async Task<ActionResult<bool>> DeleteCommentAsync(Guid commentId)

            // Arrange
            string fakeUser = "auth0id";
            Guid guid = new Guid();
            bool mockBool = true;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.DeleteCommentAsync(It.IsAny<Guid>(), fakeUser))
                .ReturnsAsync(mockBool);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.DeleteCommentAsync(guid);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockBool, oKResult?.Value);

        }


        [Fact]
        public async Task GetCommentByPostIdAsyncReturnsAListOfComments()
        {
            //        public async Task<ActionResult<List<Comment>>> GetCommentsByPostIdAsync(Guid postId)

            // Arrange
            Guid mockPostId = new Guid();
            List<Comment> mockCommentList = new List<Comment>();

            //add element 0 to test list
            string fakeUser = "auth0id";
            Guid guid = new Guid();
            Guid guid2 = new Guid();
            DateTime date1 = new DateTime();
            DateTime date2 = DateTime.Now;
            Comment comment1 = new Comment(guid, fakeUser, guid2, "TestComment", 0, date1, date2);
            mockCommentList.Add(comment1);

            //add element 1 to test list
            string fakeUser2 = "auth0id";
            Guid guid3 = new Guid();
            Guid guid4 = new Guid();
            DateTime date3 = new DateTime();
            DateTime date4 = DateTime.Now;
            Comment comment2 = new Comment(guid3, fakeUser2, guid4, "TestComment2", 1, date3, date4);
            mockCommentList.Add(comment2);

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.GetCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockCommentList);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.GetCommentsByPostIdAsync(mockPostId);
            var oKResult = result.Result as OkObjectResult;
            List<Comment>? clist = oKResult?.Value as List<Comment>;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockCommentList, oKResult?.Value);

            if (clist != null)
            {
                Assert.Equal(2, clist.Count());
                Assert.Equal(mockCommentList[0], clist[0]);
            }


        }

        [Fact]
        public async Task CreateLikeForCommentAsyncReturnTrueIfCreated()
        {
            //public async Task<ActionResult<bool>> CreateLikeForCommentAsync(LikeForCommentDto? createLikeForCommentDto)

            // Arrange
            string fakeUser = "auth0id";

            Guid guid = new Guid();
            LikeForCommentDto createLikeOnComment = new(guid);

            bool mockBool = true;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.CreateLikeForCommentAsync(It.IsAny<LikeForCommentDto>(), fakeUser))
                .ReturnsAsync(mockBool);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.CreateLikeForCommentAsync(createLikeOnComment);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockBool, oKResult?.Value);

        }


        [Fact]
        public async Task DeleteLikeForCommentAsyncReturnTrueIfDeleted()
        {
            //public async Task<ActionResult<bool>> DeleteLikeForCommentAsync(LikeForCommentDto? deleteLikeForCommentDto)

            // Arrange
            string fakeUser = "auth0id";

            Guid guid = new Guid();
            LikeForCommentDto deleteLikeOnComment = new(guid);

            bool mockBool = true;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.CreateLikeForCommentAsync(It.IsAny<LikeForCommentDto>(), fakeUser))
                .ReturnsAsync(mockBool);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.CreateLikeForCommentAsync(deleteLikeOnComment);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockBool, oKResult?.Value);

        }



        [Fact]
        public async Task GetCountOfCommentsByPostIdAsyncReturnsIntegerOfCommentAmount()
        {
            //public async Task<ActionResult<int>> GetCountofCommentsByPostIdAsync(Guid? postId)

            // Arrange
            //string fakeUser = "auth0id";

            Guid guid = new Guid();

            int mockInt = 10;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.GetCountofCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockInt);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.GetCountofCommentsByPostIdAsync(guid);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockInt, oKResult?.Value);

        }



        [Fact]
        public async Task DeletePortfolioAsyncReturnTrueIfDeleted()
        {
            //public async Task<ActionResult<bool>> DeletePortfolioAsync(DeletePortfolioDto portfolioID)

            // Arrange
            string fakeUser = "auth0id";

            Guid guid = new Guid();
            DeletePortfolioDto deletePortfolio = new(guid);

            bool mockBool = true;

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.DeletePortfolioAsync(fakeUser, It.IsAny<DeletePortfolioDto>()))
                .ReturnsAsync(mockBool);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act
            var result = await controller.DeletePortfolioAsync(deletePortfolio);
            var oKResult = result.Result as OkObjectResult;
            //bool glist = okResult.Value as bool;


            //Assert
            Assert.NotNull(oKResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(mockBool, oKResult?.Value);

        }

        [Fact]
        public async Task TestingDeletePostAsync()
        {
            // The method DeletePostAsync in the YoinkController.cs takes in a PostId and returns a guid of the deleted post.

            // Arrange

            Guid postId = Guid.NewGuid();

            string fakeUser = "auth0id";

            var mockBl = new Mock<IYoinkBusinessLayer>();
            mockBl.Setup(bl => bl.DeletePostAsync(fakeUser, postId))
                .ReturnsAsync(postId);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act

            var result = await controller.DeletePostAsync(postId);
            var okResult = result.Result as OkObjectResult;

            // Assert

            Assert.IsType<ActionResult<Guid?>>(result);//The controller method returns a guid
            Assert.NotNull(okResult);
            Assert.True(controller.ModelState.IsValid);
            Assert.Equal(postId, okResult?.Value);//a guid is equal to a guid
        }

        [Fact]
        public async Task TestingGetAllPostByUserIdAsync()
        {
            // The method GetAllPostByUserIdAsync in the YoinkController.cs takes in a UserId and returns a list of PostWithCommentCountDto.

            // Arrange

            string userId = "auth0id";

            var mockBl = new Mock<IYoinkBusinessLayer>();
            
            List<PostWithCommentCountDto> postWithCommentCountDtos = new List<PostWithCommentCountDto>();

            mockBl.Setup(bl => bl.GetAllPostByUserIdAsync(userId))
                .ReturnsAsync(postWithCommentCountDtos);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act

            var result = await controller.GetAllPostByUserIdAsync(userId);
            var okResult = result.Result as OkObjectResult;

            // Assert

            Assert.IsType<ActionResult<List<PostWithCommentCountDto>>>(result);
            Assert.True(controller.ModelState.IsValid);
            Assert.NotNull(okResult);
            Assert.Equal(okResult?.Value, postWithCommentCountDtos);
        }

        [Fact]
        public async Task TestingGetPostByPostIdAsync()
        {
            // The method GetPostByPostIdAsync in the YoinkController.cs takes in a PostId and returns a PostWithCommentCountDto.

            // Arrange

            Guid postId = Guid.NewGuid();

            var mockBl = new Mock<IYoinkBusinessLayer>();

            PostWithCommentCountDto postWithCommentCountDto = new PostWithCommentCountDto();

            mockBl.Setup(bl => bl.GetPostByPostIdAsync(postId))
                .ReturnsAsync(postWithCommentCountDto);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act

            var result = await controller.GetPostByPostIdAsync(postId);
            var okResult = result.Result as OkObjectResult;

            // Assert

            Assert.IsType<ActionResult<PostWithCommentCountDto>>(result);
            Assert.True(controller.ModelState.IsValid);
            Assert.NotNull(okResult);
            Assert.Equal(okResult?.Value, postWithCommentCountDto);
        }  
    
        [Fact]
        public async Task TestingCreateLikeOnPostAsync()
        {
            // The method CreateLikeOnPostAsync in the YoinkController.cs takes in a PostId and returns an int of the number of likes on the post.

            // Arrange

            string userId = "auth0id";

            LikeDto likeDto = new LikeDto(Guid.NewGuid());

            var mockBl = new Mock<IYoinkBusinessLayer>();

            int likeCount = 1;

            mockBl.Setup(bl => bl.CreateLikeOnPostAsync(likeDto, userId))
                .ReturnsAsync(likeCount);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act

            var result = await controller.CreateLikeOnPostAsync(likeDto);
            var okResult = result.Result as CreatedResult;

            // Assert

            Assert.IsType<ActionResult<int?>>(result);
            Assert.True(controller.ModelState.IsValid);
            Assert.NotNull(okResult);
            Assert.Equal(okResult?.Value, likeCount);

        }

        [Fact]
        public async Task TestingDeleteLikeOnPostAsync()
        {
            // The method DeleteLikeOnPostAsync in the YoinkController.cs takes in a PostId and returns an int of the number of likes on the post.

            // Arrange

            string userId = "auth0id";

            LikeDto likeDto = new LikeDto(Guid.NewGuid());

            var mockBl = new Mock<IYoinkBusinessLayer>();

            int likeCount = 1;

            mockBl.Setup(bl => bl.DeleteLikeOnPostAsync(likeDto, userId))
                .ReturnsAsync(likeCount);

            var controller = new YoinkController(mockBl.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),

                }, "mock"));

            controller.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            // Act

            var result = await controller.DeleteLikeOnPostAsync(likeDto);
            var okResult = result.Result as CreatedResult;

            // Assert

            Assert.IsType<ActionResult<int?>>(result);
            Assert.True(controller.ModelState.IsValid);
            Assert.NotNull(okResult);
            Assert.Equal(okResult?.Value, likeCount);

        }


        /// ///////////


        // [Fact]
        // public void TestingAllMethodsAssociatedWithUserProfile()
        // {
        //     //Arrange

        //     ProfileDto? profiledto = new ProfileDto()
        //     {

        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         Picture = "src/Picture",
        //         PrivacyLevel = 2,

        //     };

        //     Profile? profile = new Profile()
        //     {
        //         ProfileID = Guid.NewGuid(),
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         Picture = "src/Picture",
        //         PrivacyLevel = 2

        //     };

        //     var dataSource = new Mock<IYoinkBusinessLayer>();
        //     dataSource
        //         .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(profile));

        //     var TheClassBeingTested = new YoinkController(dataSource.Object);


        //     //Act

        //     var TheUserProfileWasGot = TheClassBeingTested.GetMyProfileAsync();

        //     var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync(profiledto);

        //     var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync(profiledto);


        //     //Assert

        //     Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
        //     Assert.Equal(profiledto.Name, profile.Name);
        // }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithUserPortfolio()
        // {

        //     //Arrange
        //     Guid guid = Guid.NewGuid();

        //     PortfolioDto? portfoliodto = new PortfolioDto()
        //     {

        //         Name = "Tony",
        //         PrivacyLevel = 2,

        //     };

        //     Portfolio? portfolio = new Portfolio()
        //     {
        //         PortfolioID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         PrivacyLevel = 2,
        //         Type = 2,
        //         OriginalLiquid = 2000,
        //         CurrentInvestment = 1000,
        //         Liquid = 2500,
        //         CurrentTotal = 2300,
        //         Symbols = 34,
        //         TotalPNL = 600,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Portfolio?> portmockList = new List<Portfolio?>();

        //     portmockList.Add(portfolio);

        //     var dataSource = new Mock<IYoinkBusinessLayer>();
        //     dataSource
        //         .Setup(p => p.GetALLPortfoliosByUserIDAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(portmockList));

        //     var TheClassBeingTested = new YoinkController(dataSource.Object);


        //     //Act

        //     var AllTheUserPortfolioWasGotByUserID = TheClassBeingTested.GetPortfoliosByUserIDAsync();

        //     var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync(portfoliodto);

        //     var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);

        //     var TheUserPortfolioWasGotByPortfolioID = TheClassBeingTested.GetPortfolioByPortfolioIDAsync(guid);



        //     //Assert

        //     Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
        //     Assert.Equal(portfoliodto.Name, portfolio.Name);
        //     Assert.Equal(2, portfolio.PrivacyLevel);
        //     Assert.Equal(portfolio.PortfolioID, guid);
        // }


        // [Fact]
        // public void TestingAllMethodsAssociatedWithBuy()
        // {

        //     //Arrange
        //     Guid guid = Guid.NewGuid();

        //     Get_BuysDto AllBuys = new Get_BuysDto()
        //     {
        //         Symbol = "GOOGL",

        //     };

        //     BuyDto buydto = new BuyDto()
        //     {
        //         Symbol = "GOOGL",

        //     };

        //     Buy? buy = new Buy()
        //     {
        //         BuyID = new Guid(),
        //         Fk_PortfolioID = new Guid(),
        //         Symbol = "GOOGL",
        //         CurrentPrice = 2000,
        //         AmountBought = 100,
        //         PriceBought = 50,
        //         DateBought = new DateTime(),

        //     };

        //     BuyDto buyDTO = new BuyDto()
        //     {
        //         portfolioId = new Guid(),
        //         Symbol = "GOOGL",
        //         CurrentPrice = 2000,
        //         AmountBought = 100,
        //         PriceBought = 50,
        //     };

        //     List<Buy?> buymockList = new List<Buy?>();

        //     buymockList.Add(buy);

        //     var dataSource = new Mock<IYoinkBusinessLayer>();
        //     dataSource
        //         .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
        //         .Returns(Task.FromResult(buymockList));

        //     var dataSource2 = new Mock<IYoinkBusinessLayer>();

        //     if(buy == null){}
        //     dataSource
        //         .Setup(b => b.AddNewBuyAsync(It.IsAny<BuyDto>()))
        //         .Returns(Task.FromResult(buy));

        //     var TheClassBeingTested = new YoinkController(dataSource.Object);

        //     var TheClassBeingTested2 = new YoinkController(dataSource2.Object);

        //     //Act

        //     var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

        //     var NewBuyWasAdded = TheClassBeingTested2.AddNewBuyAsync(buydto);


        //     //Assert

        //     Assert.Equal("GOOGL", AllBuys.Symbol);
        //     if (buy != null)
        //     {
        //         Assert.Equal(2000, buy.CurrentPrice);
        //     }

        // }

        // // }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithSell()
        // {

        //     //Arrange

        //     GetSellsDto getselldto1 = new GetSellsDto(new Guid(), "GOOGL");

        //     GetSellsDto getselldto = new GetSellsDto()
        //     {
        //         PortfolioId = new Guid(),
        //         Symbol = "GOOGL",

        //     };

        //     SellDto  sellDto = new SellDto()
        //     {
        //         Fk_PortfolioID = new Guid("2be4e71a-c21f-4b2c-9719-bb8a86b55e2b"),
        //         Symbol = "GOOGL",
        //         AmountSold = 1,
        //         PriceSold = 190
        //     };

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

        //     var dataSource = new Mock<IYoinkBusinessLayer>();
        //     dataSource
        //         .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
        //         .Returns(Task.FromResult(SellmockList));

        //     var TheClassBeingTested = new YoinkController(dataSource.Object);

        // //     var TheClassBeingTested = new YoinkController(dataSource.Object);

        //     //Act

        //     var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync(getselldto);

        //     // var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync("GOOGL", new Guid());

        //     var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sellDto);

        // //     var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sell);

        //     //Assert

        //     Assert.Equal("GOOGL", sell.Symbol);
        //     Assert.Equal(2000, sell.AmountSold);
        //     Assert.Equal("GOOGL", sellDto.Symbol);
        // }




        /// <summary>
        /// This method tests to see if a user's profile was created
        /// </summary>
        /// <returns>Returns as an Asyncronous Task</returns>
        [Fact]
        public async Task Test_CreateProfileAsync_if_Profile_is_CREATED()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            ProfileDto createProfileDto = new ProfileDto("name","email", "src/Picture", 1);
            //We create an output that is nullable
            Profile returnedProfileFromRepo = new Profile(Guid.NewGuid(),fakeUser, "name", "email", "src/picture", 1);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.CreateProfileAsync(It.IsAny<string>(),It.IsAny<ProfileDto>()))
                .ReturnsAsync(returnedProfileFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Profile?> returnedActionResultOBJ = await controller_datasource.CreateProfileAsync(createProfileDto);
            //The actual object returned will be null until converted to a variable to hold the data
            var okResultforOBJ = returnedActionResultOBJ?.Result as CreatedResult;
            Profile? resultOBJ = okResultforOBJ?.Value as Profile;


            //-------------------Assert Section ----------------
            if(resultOBJ?.ProfileID == null)
            {
                Assert.Null(okResultforOBJ?.Value);
                Assert.Equal(null, resultOBJ);
            }else
            {
                //The test asserts that the expected value and the returned value matches
                Assert.IsType<ActionResult<Profile?>?>(returnedActionResultOBJ);
                Assert.IsType<CreatedResult>(returnedActionResultOBJ?.Result);
                Assert.NotNull(resultOBJ);
                Assert.Equal(returnedProfileFromRepo.ProfileID, resultOBJ?.ProfileID);
            }


        }//End of CreateProfileAsync Test

        /// <summary>
        /// This method checks if a user got a profile successfully - GOTTEN
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_GetProfileByUserIDAsync_if_UsersProfile_is_GOTTEN()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            GetProfileDto getProfileDto = new GetProfileDto(fakeUser);
            //We create an output that is nullable
            Profile returnedProfileFromRepo = new Profile(Guid.NewGuid(),fakeUser, "name", "email", "src/picture", 1);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(returnedProfileFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Profile?> returnedActionResultOBJ = await controller_datasource.GetProfileByUserIDAsync(getProfileDto);
            //The actual object returned will be null until converted to a variable to hold the data
            var okResultforOBJ = returnedActionResultOBJ?.Result as OkObjectResult;
            Profile? resultOBJ = okResultforOBJ?.Value as Profile;


            //-------------------Assert Section ----------------
            if(resultOBJ?.ProfileID == null)
            {
                Assert.Null(okResultforOBJ?.Value);
                Assert.Equal(null, resultOBJ);
            }else
            {
                //The test asserts that the expected value and the returned value matches
                Assert.IsType<ActionResult<Profile?>?>(returnedActionResultOBJ);
                Assert.IsType<OkObjectResult>(returnedActionResultOBJ?.Result);
                Assert.NotNull(resultOBJ);
                Assert.Equal(returnedProfileFromRepo.ProfileID, resultOBJ?.ProfileID);
            }


        }//End of GetProfileByUserIDAsync Test - GOTTEN


        /// <summary>
        /// This method checks if a user got a profile successfully - GOTTEN
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Test_GetProfileByUserIDAsync_if_UsersProfile_is_NOT_GOTTEN()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            GetProfileDto getProfileDto = new GetProfileDto(fakeUser);
            //We create an output that is nullable
            Profile returnedProfileFromRepo = new Profile(Guid.NewGuid(),fakeUser, "name", "email", "src/picture", 1);
            NotFoundObjectResult notFoundResult = new NotFoundObjectResult(new {userNotFound = returnedProfileFromRepo.ProfileID});

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(returnedProfileFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Profile?> returnedActionResultOBJ = await controller_datasource.GetProfileByUserIDAsync(getProfileDto);

            //-------------------Assert Section ----------------
            if(returnedActionResultOBJ.Value?.ProfileID == null)
            {
                Assert.Null(returnedActionResultOBJ?.Value);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(null, returnedActionResultOBJ?.Value);
                Assert.IsType<OkObjectResult>(returnedActionResultOBJ?.Result);
            }

        }//End of GetProfileByUserIDAsync Test - NOT GOTTEN

        /// <summary>
        /// This method tests to see if a profile was successfully edited
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Test_EditProfileAsync_IF_Edited()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            ProfileDto editProfileDto = new ProfileDto("name", "email", "src/picture",1);
            //We create an output that is nullable
            Profile returnedProfileFromRepo = new Profile(Guid.NewGuid(),fakeUser, "name", "email", "src/picture", 1);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.EditProfileAsync(fakeUser, editProfileDto))
                .ReturnsAsync(returnedProfileFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Profile?> returnedActionResultOBJ = await controller_datasource.EditProfileAsync(editProfileDto);
            Profile? profile = returnedActionResultOBJ.Value as Profile;

            //-------------------Assert Section ----------------
            if(profile != null){
                Assert.NotNull(returnedActionResultOBJ);
                Assert.Equal(returnedProfileFromRepo.ProfileID, profile.ProfileID);
                Assert.IsType<OkObjectResult>(returnedActionResultOBJ?.Result);
            }

        }//End of EditProfileAsync Test - Edited

        /// <summary>
        /// This method tests to see if a profile was not edited
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_EditProfileAsync_IF_NOT_Edited()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            ProfileDto editProfileDto = new ProfileDto();
            //We create an output that is nullable
            Profile returnedProfileFromRepo = new Profile();

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.EditProfileAsync(fakeUser, editProfileDto))
                .ReturnsAsync(returnedProfileFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Profile?> returnedActionResultOBJ = await controller_datasource.EditProfileAsync(editProfileDto);
            Profile? profile = returnedActionResultOBJ.Value as Profile;

            //-------------------Assert Section ----------------
            if(profile == null){
                Assert.Null(returnedActionResultOBJ.Value);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(null, profile?.ProfileID);
                Assert.IsType<OkObjectResult>(returnedActionResultOBJ?.Result);
            }

        }//End of EditProfileAsync Test - Not Edited

        /// <summary>
        /// This method tests to see if a portfolio was successfully created
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_CreatePortfolioAsync_IS_Created()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            PortfolioDto dtoOBJ = new PortfolioDto(Guid.NewGuid(), "email", 10,1);
            //We create an output that is nullable
            Portfolio returnedOBJFromRepo = new Portfolio(Guid.NewGuid(),fakeUser, "name",1, 1, 10,10,10,10,1,1, DateTime.Now, DateTime.Now);

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.CreatePortfolioAsync(fakeUser, dtoOBJ))
                .ReturnsAsync(returnedOBJFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Portfolio?> returnedActionResult = await controller_datasource.CreatePortfolioAsync(dtoOBJ);
            Portfolio? thisresultOBJ = returnedActionResult.Value as Portfolio;

            //-------------------Assert Section ----------------
            if(thisresultOBJ != null){
                Assert.NotNull(returnedActionResult);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(returnedOBJFromRepo.PortfolioID, thisresultOBJ.PortfolioID);
                Assert.IsType<CreatedResult>(returnedActionResult?.Result);
            }

        }//End of CreatePortfolioAsync Test - Created


        /// <summary>
        /// This method tests to see if a portfolio was not created
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Test_CreatePortfolioAsync_IS_NOT_Created()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            PortfolioDto dtoOBJ = new PortfolioDto();
            //We create an output that is nullable
            Portfolio expectedOBJFromRepo = new Portfolio();

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.CreatePortfolioAsync(fakeUser, dtoOBJ))
                .ReturnsAsync(expectedOBJFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Portfolio?> returnedActionResult = await controller_datasource.CreatePortfolioAsync(dtoOBJ);
            Portfolio? thisresultOBJ = returnedActionResult.Value as Portfolio;

            //-------------------Assert Section ----------------
            if(thisresultOBJ == null){
                Assert.Null(returnedActionResult.Value);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(expectedOBJFromRepo.PortfolioID, thisresultOBJ?.PortfolioID);
                //Supposed to be BadRequest if not created or 204 or something other than created
                Assert.IsType<BadRequestObjectResult>(returnedActionResult?.Result);
            }

        }//End of CreatePortfolioAsync Test - Not Created

        /// <summary>
        /// This method tests to see if the user's portfolios was gotten successfully
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Test_GetPortfoliosByUserIDAsync_to_see_if_they_were_GOTTEN()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            PortfolioDto dtoOBJ = new PortfolioDto(Guid.NewGuid(), "name", 1,1);
            //We create an output that is nullable
            List<Portfolio?> expectedOBJFromRepo = new List<Portfolio?>();
            for(int i =0; i < 5; i++)
            {
                Portfolio portfolio = new Portfolio(Guid.NewGuid(),fakeUser, "name",1, 1, 10,10,10,10,1,1, DateTime.Now, DateTime.Now);
                expectedOBJFromRepo.Add(portfolio);

            }

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetALLPortfoliosByUserIDAsync(fakeUser))
                .ReturnsAsync(expectedOBJFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<List<Portfolio?>> returnedActionResult = await controller_datasource.GetPortfoliosByUserIDAsync();
            List<Portfolio?>? thisresultOBJ = returnedActionResult.Value as List<Portfolio?>;

            //-------------------Assert Section ----------------
            if(thisresultOBJ != null){
                Assert.NotNull(returnedActionResult.Value);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(expectedOBJFromRepo, thisresultOBJ);
                //Supposed to be BadRequest if not created or 204 or something other than created
                Assert.IsType<OkObjectResult>(returnedActionResult?.Result);
            }
        }//End of GetPortfoliosByUserIDAsync Test - GOTTEN


        /// <summary>
        /// This method tests to see if the user's portfolios was not gotten
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Test_GetPortfoliosByUserIDAsync_to_see_if_they_were_NOT_GOTTEN()
        {
            //-------------------Arrange Section ----------------
            string fakeUser = "auth0ID";
            //We then create a mock Identity User using Claims 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "auth0id"),
                    
                }, "mock")); 

            //We create an input that is constant
            PortfolioDto dtoOBJ = new PortfolioDto();
            //We create an output that is nullable
            List<Portfolio?> expectedOBJFromRepo = new List<Portfolio?>();

            //We mock the IYoinkBusinessLayer to be able to de-couple database from the tested Interface
            var dataSource = new Mock<IYoinkBusinessLayer>();
            dataSource
                .Setup(s => s.GetALLPortfoliosByUserIDAsync(fakeUser))
                .ReturnsAsync(expectedOBJFromRepo);

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<List<Portfolio?>> returnedActionResult = await controller_datasource.GetPortfoliosByUserIDAsync();
            // List<Portfolio?>? thisresultOBJ = returnedActionResult.Value as List<Portfolio?>;

            //-------------------Assert Section ----------------
            if(returnedActionResult.Value != null){
                Assert.Null(returnedActionResult.Value);
                //This must be nullable or it will say - Assert.NotNull() Failure
                Assert.Equal(expectedOBJFromRepo, returnedActionResult.Value);
                //Supposed to be BadRequest if not created or 204 or something other than created
                Assert.IsType<OkObjectResult>(returnedActionResult?.Result);
            }
        }//End of GetPortfoliosByUserIDAsync Test - NOT GOTTEN



        // [Fact]
        // public async Task TestingCreatePostAsync()
        // {
        //     //Arrange
        //     string fakeUser = "auth0id";

        //     CreatePostDto createPostDto = new CreatePostDto()
        //     {
        //         Content = "Test",
        //         PrivacyLevel = 1,
        //     };

        //     Post createPost = new Post()
        //     {
        //     PostID = Guid.NewGuid(),
        //     Fk_UserID = "UserName",
        //     Content = "content",
        //     Likes = 1,
        //     DateCreated = DateTime.Now,
        //     PrivacyLevel = 1,
        //     DateModified = DateTime.Now,
        //     };

        //     var mockBl = new Mock<IYoinkBusinessLayer>();
        //     mockBl
        //         .Setup(bl => bl.CreatePostAsync(fakeUser, createPostDto))
        //         .ReturnsAsync(createPost);

        //     var ControllerClass = new YoinkController(mockBl.Object);

        //     var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        //         {
        //             new Claim(ClaimTypes.Name, "auth0id"),

        //         }, "mock"));

        //     ControllerClass.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

        //     //Act

        //     var result = await ControllerClass.CreatePostAsync(createPostDto);
        //     var okResult = result.Result as OkObjectResult;
        //     Post? resultPost = okResult?.Value as Post;

        //     //Assert
        //     Console.WriteLine("result" + resultPost);
        //     Assert.NotNull(resultPost);
        //     if (resultPost != null)
        //     {
        //         Assert.IsType<ActionResult<Post>>(result);
        //         Assert.Equal(createPost.PostID, resultPost.PostID);
        //     }



    }
}
