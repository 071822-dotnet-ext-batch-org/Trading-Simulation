using APILayer.Controllers;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Models;
using Moq;
using RepoLayer;
using System;
using System.Security.Claims;
using System.Security.Principal;

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
            Console.WriteLine($"\n\nThis is a returned obj ID: { dataSource.Object.UpdatePostAsync(fakeUser, editPostDto).Result?.PostID}\n\n");

            var controller_datasource = new YoinkController(dataSource.Object){};
            controller_datasource.ControllerContext.HttpContext = new DefaultHttpContext() { User = user };

            //-------------------Act Section ----------------
            ActionResult<Post?> returnedActionResultOBJ = await controller_datasource.UpdatePostAsync(editPostDto);
            //The actual object returned will be null until converted to a variable to hold the data
            Console.WriteLine($"\n\nThis is a returned obj ID from the controller: {returnedActionResultOBJ.Value?.PostID}\n\n");
            var okResultforOBJ = returnedActionResultOBJ?.Result as OkObjectResult;
            Console.WriteLine($"\n\nThis is a returned obj ID: {okResultforOBJ?.Value}\n\n");
            Post? resultOBJ = okResultforOBJ?.Value as Post;
            Console.WriteLine($"\n\nThis is a returned obj ID: {resultOBJ?.PostID}\n\n");


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




        private List<Guid> fakeGuidList(){
            List<Guid> newGuids = new List<Guid>();
            Guid newGuid = Guid.NewGuid();
            Guid newGuid2 = Guid.NewGuid();
            Guid newGuid3 = Guid.NewGuid();
            Console.WriteLine(newGuid);
            Console.WriteLine(newGuid2);
            Console.WriteLine(newGuid3);
            newGuids.Add(newGuid);
            newGuids.Add(newGuid2);
            newGuids.Add(newGuid3);
            
            return newGuids;
        }

        [Fact]
        public async Task TestGetPostLikesByUserID()
        {
            // Arrange
            string fakeUser = "auth0id";

            List<Guid> mockGuids = fakeGuidList();
            
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
}
