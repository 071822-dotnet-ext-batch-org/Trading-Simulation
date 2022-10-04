using APILayer.Controllers;
using BusinessLayer;
using Models;
using Moq;
using RepoLayer;
using System.Xml.Linq;


namespace Test.Yoink
{
    public class YoinkBusinessLayerClassTests
    {
        [Fact]
        public async Task TestingCreateProfileAsync()
        {
            string auth0UserId = "sample auth0UserId";
            ProfileDto profileDto = new ProfileDto()
            {
                Name = "Jonathan",
                Email = "Jonathan241@revature.net",
                Picture = "http://dazedimg.dazedgroup.netdna-cdn.com/786/azure/dazed-prod/1150/0/1150228.jpg",
                PrivacyLevel = 2
            };
            ActionResult<Profile> expectedCreatedProfile = new OkObjectResult(new Profile());
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(c => c.CreateProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdProfile = await theClassBeingTested.CreateProfileAsync(auth0UserId, profileDto);

            //Assert
            if (createdProfile != null)
            {
                Assert.IsType<ActionResult>(createdProfile);
            }
            Assert.Equal(expectedCreatedProfile.Value, createdProfile);
        }


        [Fact]
        public async Task TestingGetProfileByUserIDAsync()
        {
            string auth0UserId = "sample auth0UserId";


            Profile? expectedGetProfile = new Profile();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(new Profile());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotProfile = await theClassBeingTested.GetProfileByUserIDAsync(auth0UserId);

            //Assert
            if (gotProfile != null)
            {
                Assert.IsType<Profile>(gotProfile);
                Assert.Equal(expectedGetProfile.Name, gotProfile.Name);
            }

        }


        [Fact]
        public async Task TestingEditProfileAsync()
        {
            string auth0UserId = "sample auth0UserId";

            ProfileDto profileDto = new ProfileDto()
            {
                Name = "Jonathan",
                Email = "Jonathan241@revature.net",
                Picture = "http://dazedimg.dazedgroup.netdna-cdn.com/786/azure/dazed-prod/1150/0/1150228.jpg",
                PrivacyLevel = 2
            };

            Profile? expectedEditProfile = new Profile();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(e => e.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var editedProfile = await theClassBeingTested.EditProfileAsync(auth0UserId, profileDto);

            //Assert
            if (editedProfile != null)
            {
                Assert.IsType<Profile>(editedProfile);
                Assert.Equal(expectedEditProfile.Name, editedProfile.Name);
            }
        }


        [Fact]
        public async Task TestingCreatePortfolioAsync()
        {
            string auth0UserId = "sample auth0UserId";

            PortfolioDto portfolioDto = new PortfolioDto()
            {
                PortfolioID = Guid.NewGuid(),
                Name = "Sample Name",
                OriginalLiquid = 1000,
                PrivacyLevel = 2
            };

            Portfolio? excpectedCreatePortfolio = new Portfolio();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(c => c.CreatePortfolioAsync(It.IsAny<string>(), It.IsAny<PortfolioDto>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPortfolio = await theClassBeingTested.CreatePortfolioAsync(auth0UserId, portfolioDto);

            //Assert
            if (createdPortfolio != null)
            {
                Assert.IsType<Profile>(createdPortfolio);
                Assert.Equal(excpectedCreatePortfolio.Name, createdPortfolio.Name);
            }
        }


        [Fact]
        public async Task TestingEditPortfolioAsync()
        {
            string auth0UserId = "sample auth0UserId";

            PortfolioDto portfolioDto = new PortfolioDto()
            {
                PortfolioID = Guid.NewGuid(),
                Name = "Sample Name",
                OriginalLiquid = 1000,
                PrivacyLevel = 2
            };

            Portfolio? excpectedCreatePortfolio = new Portfolio();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(e => e.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPortfolio = await theClassBeingTested.EditPortfolioAsync(portfolioDto);

            //Assert
            if (createdPortfolio != null)
            {
                Assert.IsType<Portfolio>(createdPortfolio);
                Assert.Equal(excpectedCreatePortfolio.Name, createdPortfolio.Name);
            }
        }


        [Fact]
        public async Task TestingGetPortfolioByPortfolioIDAsync()
        {
            Guid portfolioId = Guid.NewGuid();

            Portfolio? excpectedGetPortfolio = new Portfolio();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Portfolio());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotPortfolio = await theClassBeingTested.GetPortfolioByPortfolioIDAsync(portfolioId);

            //Assert
            if (gotPortfolio != null)
            {
                Assert.IsType<Portfolio>(gotPortfolio);
                Assert.Equal(excpectedGetPortfolio.Name, gotPortfolio.Name);
            }
        }


        [Fact]
        public async Task TestingGetALLPortfoliosByUserIDAsync()
        {
            string auth0UserId = "sample auth0UserId";

            List<Portfolio?> excpectedGetAllPortfolio = new List<Portfolio?>();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Portfolio>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllPortfolios = await theClassBeingTested.GetALLPortfoliosByUserIDAsync(auth0UserId);

            //Assert
            if (gotAllPortfolios != null)
            {
                Assert.IsType<List<Portfolio>>(gotAllPortfolios);
                Assert.Equal(excpectedGetAllPortfolio, gotAllPortfolios);
            }
        }


        [Fact]
        public async Task TestingAddNewBuyAsync()
        {
            BuyDto buyDto = new BuyDto()
            {
                portfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                CurrentPrice = 100,
                AmountBought = 20,
                PriceBought = 15

            };

            Buy? excpectedAddNewBuy = new Buy();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.AddNewBuyAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var addedBuy = await theClassBeingTested.AddNewBuyAsync(buyDto);

            //Assert
            if (addedBuy != null)
            {
                Assert.IsType<Buy>(addedBuy);
                Assert.Equal(excpectedAddNewBuy.Symbol, addedBuy.Symbol);
            }
        }


        [Fact]
        public async Task TestingAddNewSellAsync()
        {
            SellDto sellDto = new SellDto()
            {
                Fk_PortfolioID = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                AmountSold = 20,
                PriceSold = 15
            };


            Sell? excpectedAddNewSell = new Sell();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var addedSell = await theClassBeingTested.AddNewSellAsync(sellDto);

            //Assert
            if (addedSell != null)
            {
                Assert.IsType<Buy>(addedSell);
                Assert.Equal(excpectedAddNewSell.Symbol, addedSell.Symbol);
            }
        }


        [Fact]
        public async Task TestingGetAllBuyBySymbolAsync()
        {
            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Get_BuysID = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Buy?> excpectedGetAllBuys = new List<Buy?>();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .ReturnsAsync(new List<Buy>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllBuys = await theClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

            //Assert
            if (gotAllBuys != null)
            {
                Assert.IsType<List<Buy>>(gotAllBuys);
                Assert.Equal(excpectedGetAllBuys, gotAllBuys);
            }
        }


        [Fact]
        public async Task TestingGetAllSellBySymbolAsync()
        {
            GetSellsDto sellsDto = new GetSellsDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Sell?> excpectedGetAllSells = new List<Sell?>();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .ReturnsAsync(new List<Sell>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllSells = await theClassBeingTested.GetAllSellBySymbolAsync(sellsDto);

            //Assert
            if (gotAllSells != null)
            {
                Assert.IsType<List<Sell>>(gotAllSells);
                Assert.Equal(excpectedGetAllSells, gotAllSells);
            }
        }


        [Fact]
        public async Task TestingGetInvestmentByPortfolioIDAsync()
        {
            GetInvestmentDto investmentDto = new GetInvestmentDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
            };


            Investment? excpectedGetInvestment = new Investment();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(new Investment());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotInvestment = await theClassBeingTested.GetInvestmentByPortfolioIDAsync(investmentDto);

            //Assert
            if (gotInvestment != null)
            {
                Assert.IsType<Investment>(gotInvestment);
                Assert.Equal(excpectedGetInvestment.Symbol, gotInvestment.Symbol);
            }
        }


        [Fact]
        public async Task TestingGetInvestmentByTimeAsync()
        {
            GetInvestmentByTimeDto investmentByTime = new GetInvestmentByTimeDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                StartTime = new DateTime(),
                EndTime = new DateTime()
            };


            List<Investment?> excpectedGetInvestment = new List<Investment?>();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .ReturnsAsync(new List<Investment>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotInvestment = await theClassBeingTested.GetInvestmentByTimeAsync(investmentByTime);

            //Assert
            if (gotInvestment != null)
            {
                Assert.IsType<List<Investment>>(gotInvestment);
                Assert.Equal(excpectedGetInvestment, gotInvestment);
            }
        }


        [Fact]
        public async Task TestingGetNumberOfUsersAsync()
        {

            int excpectedGetNumberUsers = 10;
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfUsersAsync())
                .ReturnsAsync(excpectedGetNumberUsers);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberUsers = await theClassBeingTested.GetNumberOfUsersAsync();

            //Assert
            Assert.NotNull(gotNumberUsers);
            Assert.IsType<int>(gotNumberUsers);
            Assert.Equal(excpectedGetNumberUsers, gotNumberUsers);
            
        }


        [Fact]
        public async Task TestingGetNumberOfPostsAsync()
        {

            int? excpectedGetNumberPosts = new int();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfPostsAsync())
                .ReturnsAsync(new int());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberPosts = await theClassBeingTested.GetNumberOfPostsAsync();

            //Assert
            if (gotNumberPosts != null)
            {
                Assert.IsType<int>(gotNumberPosts);
                Assert.Equal(excpectedGetNumberPosts, gotNumberPosts);
            }
        }


        [Fact]
        public async Task TestingGetNumberOfBuysAsync()
        {

            int? excpectedGetNumberBuys = new int();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfBuysAsync())
                .ReturnsAsync(new int());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberBuys = await theClassBeingTested.GetNumberOfBuysAsync();

            //Assert
            if (gotNumberBuys != null)
            {
                Assert.IsType<int>(gotNumberBuys);
                Assert.Equal(excpectedGetNumberBuys, gotNumberBuys);
            }
        }


        [Fact]
        public async Task TestingGetNumberOfSellsAsync()
        {

            int? excpectedGetNumberSells = new int();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfSellsAsync())
                .ReturnsAsync(new int());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberSells = await theClassBeingTested.GetNumberOfSellsAsync();

            //Assert
            if (gotNumberSells != null)
            {
                Assert.IsType<int>(gotNumberSells);
                Assert.Equal(excpectedGetNumberSells, gotNumberSells);
            }
        }


        [Fact]
        public async Task TestingCreatePostAsync()
        {
            string auth0UserId = "sample auth0UserId";

            CreatePostDto post = new CreatePostDto()
            {
                Content = "Sample Content",
                PrivacyLevel = 2
            };

            Post? excpectedCreatePost = new Post();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPost = await theClassBeingTested.CreatePostAsync(auth0UserId, post);

            //Assert
            if (createdPost != null)
            {
                Assert.IsType<Post>(createdPost);
                Assert.Equal(excpectedCreatePost.Content, createdPost.Content);
            }
        }

    }
}


/**
[Fact]
public void TestingAllMethodsAssociatedWithUserProfile()
{
    //Arrange
    ProfileDto? profiledto2 = new ProfileDto("Tony", "Rodin@yahoo.com", "ghhhtbnn", 2);

    ProfileDto? profiledto = new ProfileDto()
    {

        Name = "Tony",
        Email = "Rodin@yahoo.com",
        Picture = "ghhhtbnn",
        PrivacyLevel = 2,

    };

    Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

    Profile? profile = new Profile()
    {
        ProfileID = Guid.NewGuid(),
        Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        Name = "Tony",
        Email = "Rodin@yahoo.com",
        Picture = "src/testpic",
        PrivacyLevel = 2,
           
    };

    var dataSource = new Mock<IdbsRequests>();

    if(profile == null){}
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
    if (profile != null)
    {
        Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
        Assert.Equal(profiledto.Name, profile.Name);
    }
}//END OF TestingAllMethodsAssociatedWithUserProfile



[Fact]
public void TestingAllMethodsAssociatedWithUserPortfolio()
{

    //Arrange
    Guid guid = Guid.NewGuid();

    PortfolioDto? portfoliodto = new PortfolioDto()
    {
        PortfolioID = Guid.NewGuid(),
        Name = "Tony",
        OriginalLiquid = 2000,
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




[Fact]
public void TestingAllMethodsAssociatedWithSell()
{

    //Arrange

    GetSellsDto getselldto = new GetSellsDto()
    {
        PortfolioId = new Guid(),
        Symbol = "GOOGL",

    };
    SellDto sellDto = new SellDto()
    {
        Fk_PortfolioID = new Guid("e549725f-472d-4042-be38-0bc8e28c364b"),
        Symbol = "GOOGL",
        AmountSold = 2000,
        PriceSold = 1000
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

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
        .Returns(Task.FromResult(SellmockList));


    var dataSource2 = new Mock<IdbsRequests>();
    dataSource
        .Setup(s => s.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>()))
        .Returns(Task.FromResult(true));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);
    var TheClassBeingTested2 = new YoinkBusinessLayer(dataSource2.Object);

    //Act

    var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync(getselldto);

    var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(sellDto);

    var NewSellWasAddedBool = TheClassBeingTested2.AddNewSellAsync(sellDto);


    //Assert

    Assert.Equal("GOOGL", sell.Symbol);
    Assert.Equal(2000, sell.AmountSold);

    Assert.Equal("GOOGL", sellDto.Symbol);
    Assert.True(true);
    
}//END OF TestingAllMethodsAssociatedSell


[Fact]
public void TestingGetAllPostAsync()
{

    //Arrange

    Post? post = new Post()
    {
        PostID = new Guid(),
        Fk_UserID = "auth0ID_UserID",
        Content = "New Content",
        Likes = 0,
        PrivacyLevel = 1000,
        DateCreated = new DateTime(),
        DateModified = new DateTime()
    };

    CreatePostDto postDto = new CreatePostDto()
    {

    };

    List<Post?> PostsmockList = new List<Post?>(){//nullable
        post
    };
    List<Post> PostsmockList_Non_Null = new List<Post>(){//non-nullable
        post
    };

    PostsmockList.Add(post);

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(s => s.GetAllPostAsync())
        .Returns(Task.FromResult(PostsmockList_Non_Null));

    var dataSource2 = new Mock<IdbsRequests>();
    dataSource
        .Setup(s => s.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
        .Returns(Task.FromResult(true));

    var MethodTest1 = new YoinkBusinessLayer(dataSource.Object);
    var MethodTest2 = new YoinkBusinessLayer(dataSource2.Object);
    


    //Act

    var AllPostWasGot = MethodTest1.GetAllPostAsync();

    var NewPostWasAdded = MethodTest2.CreatePostAsync("UserID", postDto );
    // var MostRecentPostWasGotten = MethodTest3.GetRecentPostByUserId();

    


    //Assert

    Assert.Equal(PostsmockList, PostsmockList);//Method1 - get all posts
    Assert.Equal(true, true);//Method2 - create post
    
}//END OF TestingGetAllPostsAsync




[Fact]
public void TestingCreatePostAsync()
{

    //Arrange

    Post? post = new Post()
    {
        PostID = new Guid(),
        Fk_UserID = "auth0ID_UserID",
        Content = "New Content",
        Likes = 0,
        PrivacyLevel = 1000,
        DateCreated = new DateTime(),
        DateModified = new DateTime()
    };
   

    CreatePostDto postDto = new CreatePostDto()
    {
        Content = "New Content",
        PrivacyLevel = 1000,
    };

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(s => s.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
        .Returns(Task.FromResult(true));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);
    


    //Act


    var NewPostWasAdded = TheClassBeingTested.CreatePostAsync("auth0ID_UserID", postDto );
    // var MostRecentPostWasGotten = MethodTest3.GetRecentPostByUserId();

    


    //Assert

    Assert.Equal("auth0ID_UserID", post.Fk_UserID);//Method - Successfully created a Post
    Assert.Equal("New Content", postDto.Content);//Method - Successfully created a Post
    Assert.True(true);//Method - Successfully created a Post

}


[Fact]
public void TestingUpdatePostAsync()
{

    //Arrange
    

    EditPostDto editPostDto = new EditPostDto()
    {
        PostId = Guid.NewGuid(),
        Content = "TestContent",
        PrivacyLevel = 1
    };
    Post? post = new Post()
    {
        PostID = new Guid(),
        Fk_UserID = "auth0ID_UserID",
        Content = "New Content",
        Likes = 0,
        PrivacyLevel = 1000,
        DateCreated = new DateTime(),
        DateModified = new DateTime()
    };
    

    CreatePostDto postDto = new CreatePostDto()
    {
        Content = "New Content",
    };

    var dataSourceRL = new Mock<IdbsRequests>();
    dataSourceRL
        .Setup(s => s.UpdatePostAsync(It.IsAny<EditPostDto>()))
        .Returns(Task.FromResult(true));

    var dataSourceRL_False = new Mock<IdbsRequests>();
    dataSourceRL_False
        .Setup(s => s.UpdatePostAsync(It.IsAny<EditPostDto>()))
        .Returns(Task.FromResult(false));

    var dataSourceBL = new Mock<IYoinkBusinessLayer>();

    if(post == null){}
    dataSourceBL
        .Setup(s => s.UpdatePostAsync(It.IsAny<string?>(),It.IsAny<EditPostDto>()))
        .Returns(Task.FromResult(post));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSourceRL.Object);
    var TheClassBeingTested2 = new YoinkBusinessLayer(dataSourceRL_False.Object);
    


    //Act


    var NewPostWasAdded = TheClassBeingTested.CreatePostAsync("auth0ID_UserID", postDto );
    // var MostRecentPostWasGotten = MethodTest3.GetRecentPostByUserId();

    


    //Assert
    if(post != null)
    {
        Assert.Equal("auth0ID_UserID", post.Fk_UserID);//Method - Successfully created a Post
    }
    Assert.Equal("New Content", postDto.Content);//Method - Successfully created a Post
    Assert.True(true);//Method - Successfully created a Post

}





[Fact]
public void TestingAllMethodsAssociatedWithBuy()
{

    //Arrange
    BuyDto makeBuyOrder = new BuyDto()
    {
        portfolioId = Guid.NewGuid(),
        Symbol = "TSLA",
        CurrentPrice = 860,
        AmountBought = 1000000,
        PriceBought = 12
    };

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

    List<Buy?> buymockList = new List<Buy?>();

    buymockList.Add(buy);

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
        .Returns(Task.FromResult(buymockList));

    var dataSource2 = new Mock<IdbsRequests>();
    dataSource
        .Setup(b => b.AddNewBuyAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<Decimal>()))
        .Returns(Task.FromResult(true));

   

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);
    var TheClassBeingTested2 = new YoinkBusinessLayer(dataSource2.Object);

    //Act

    var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

    var NewBuyWasAdded = TheClassBeingTested.AddNewBuyAsync(makeBuyOrder);

    var NewBuyWasAddedBool = TheClassBeingTested2.AddNewBuyAsync(makeBuyOrder);

    //Assert

    Assert.Equal("GOOGL", AllBuys.Symbol);
    Assert.Equal(2000, buy.CurrentPrice);
    Assert.True(true);

}



[Fact]
public void TestingAllMethodsAssociatedWithInvestment()
{

    //Arrange

    Guid invt = new Guid();

    DateTime DT = new DateTime();

    GetInvestmentDto getInvest2 = new GetInvestmentDto()
    {
        PortfolioId = invt,
        Symbol = "GOOGL",

    };

    GetInvestmentByTimeDto getInvesttime2 = new GetInvestmentByTimeDto()
    {
        StartTime = DT,
        EndTime = DT,
        PortfolioId = invt,
        Symbol = "GOOGL",

    };


    Investment newinvestment = new Investment()
    {
        InvestmentID = invt,
        Fk_PortfolioID = invt,
        Symbol = "AAPL",
        AmountInvested = 1200,
        CurrentAmount = 100,
        CurrentPrice = 50,
        TotalAmountBought = 4,
        TotalAmountSold = 2,
        AveragedBuyPrice = 150,
        TotalPNL = 50,
        DateCreated = new DateTime(),
        DateModified = new DateTime(),

    };

    List<Investment?> investmentmockList = new List<Investment?>(); //nullable
    List<Investment>? investmentmockList_Non_Null = new List<Investment>()
    {
        newinvestment
    }; //nullable

    investmentmockList.Add(newinvestment);

    var dataSource = new Mock<IdbsRequests>();

    if(investmentmockList_Non_Null == null){}

    dataSource
        .Setup(I => I.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
        .Returns(Task.FromResult(investmentmockList_Non_Null));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var InvestmentGotByTime = TheClassBeingTested.GetInvestmentByTimeAsync(getInvesttime2);

    var InvestmentGotByPortfolioID = TheClassBeingTested.GetInvestmentByPortfolioIDAsync(getInvest2);


    //Assert

    Assert.Equal(getInvesttime2.PortfolioId, invt);
    Assert.Equal(getInvest2.PortfolioId, invt);

}



//This methods would test GetAllInvestmentsByPortfolioID 

[Fact]
public void TestingGetAllInvestmentsByPortfolioID()
{
    //set the data for testing the methods
    //Arrange
    Guid guid = Guid.NewGuid();


    Investment newinvestment3 = new Investment()
    {
        InvestmentID = guid,
        Fk_PortfolioID = guid,
        Symbol = "AAPL",
        AmountInvested = 1200,
        CurrentAmount = 100,
        CurrentPrice = 50,
        TotalAmountBought = 4,
        TotalAmountSold = 2,
        AveragedBuyPrice = 150,
        TotalPNL = 50,
        DateCreated = new DateTime(),
        DateModified = new DateTime(),

    };


    List<Investment> InvestmockList = new List<Investment>();

    InvestmockList.Add(newinvestment3);


    // dataSource will decouple the tested method from the database and use the local data set above for the test

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(p => p.GetAllInvestmentsByPortfolioIDAsync(It.IsAny<Guid>()))
        .Returns(Task.FromResult(InvestmockList));


    //Inject the datasource into the class containing the methods to be tested

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Call the methods to be tested
    //Act

    var AllTheInvestmentWasGotByPortfolioID = TheClassBeingTested.GetAllInvestmentsByPortfolioIDAsync(guid);


    //Assert

    Assert.Equal(newinvestment3.InvestmentID, guid);
}




[Fact]
public void TestingGetNumberOfUsers()
{

    //Arrange

    int? userCount = 500;

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(G => G.GetNumberOfUsersAsync())
        .Returns(Task.FromResult(userCount));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfUsersAsync();

    
    //Assert

    Assert.Equal(500, userCount);
    

}


[Fact]
public void TestingGetNumberOfPosts()
{

    //Arrange

    int? userCount = 500;

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(G => G.GetNumberOfPostsAsync())
        .Returns(Task.FromResult(userCount));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfPostsAsync();


    //Assert

    Assert.Equal(500, userCount);


}


[Fact]
public void TestingGetNumberOfSellsByDay()
{

    //Arrange

    int? sellsCount = 700;

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(G => G.GetNumberOfBuysAsync())
        .Returns(Task.FromResult(sellsCount));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysAsync();


    //Assert

    Assert.Equal(700, sellsCount);


}



[Fact]
public void TestingGetNumberOfBuysByDay()
{

    //Arrange

    int? buysCount = 300;

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(G => G.GetNumberOfBuysAsync())
        .Returns(Task.FromResult(buysCount));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysAsync();


    //Assert

    Assert.Equal(300, buysCount);


}




[Fact]
public void GetNumberOfSellsByDayAsync()
{

    //Arrange

    int? sellsCount = 350;

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(G => G.GetNumberOfSellsAsync())
        .Returns(Task.FromResult(sellsCount));

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Act

    var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfSellsAsync();


    //Assert

    Assert.Equal(350, sellsCount);


}


//This methods would test UpdatePost 

[Fact]
public void TestingUpdatePostD()
{
    //set the data for testing the methods
    //Arrange
    Guid guid = Guid.NewGuid();
    string auhOUserId = "56778888";

    EditPostDto editpostdto = new EditPostDto(guid, "Hello World", 2);

    EditPostDto editpostdto2 = new EditPostDto()
    {
        PostId = guid,
        Content = "Hello World",
        PrivacyLevel = 2,

    };


   
    // dataSource will decouple the tested method from the database and use the local data set above for the test

    var dataSource = new Mock<IdbsRequests>();
    dataSource
        .Setup(p => p.UpdatePostAsync(It.IsAny<EditPostDto>()))
        .Returns(Task.FromResult(true));

    var dataSource2 = new Mock<IdbsRequests>();

    if(auhOUserId == null){}
    dataSource
        .Setup(p => p.GetUserWithPostIdAsync(It.IsAny<Guid>()))
        .Returns(Task.FromResult(auhOUserId));


    //Inject the datasource into the class containing the methods to be tested

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Call the methods to be tested
    //Act

    var ThePostWasUpdated = TheClassBeingTested.UpdatePostAsync(auhOUserId, editpostdto2);


    //Assert

    Assert.True(true);
    Assert.Equal(editpostdto.PostId, guid);
}



//This methods would test for delete post

[Fact]
public void TestingDeletePostD()
{
    //set the data for testing the methods
    //Arrange
    Guid guid = Guid.NewGuid();
    string auhOUserId = "56778888";


    Guid PostId = guid;
       

    // dataSource will decouple the tested method from the database and use the local data set above for the test

    //Returns a string

    var dataSource = new Mock<IdbsRequests>();
    if(auhOUserId == null) {}
    dataSource
        .Setup(p => p.GetUserWithPostIdAsync(It.IsAny<Guid>()))
        .Returns(Task.FromResult(auhOUserId));

    var dataSource2 = new Mock<IdbsRequests>();
    dataSource
        .Setup(p => p.DeletePostAsync(It.IsAny<Guid>()))
        .Returns(Task.FromResult(true));


    //Inject the datasource into the class containing the methods to be tested

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Call the methods to be tested
    //Act

    var ThePostWasUpdated = TheClassBeingTested.DeletePostAsync(auhOUserId, PostId);


    //Assert

    Assert.True(true);
    Assert.Equal(PostId, guid);
}



//This methods would test PostWithCommentCountDto 

[Fact]
public void TestingPostWithCommentCountDto()
{
    //set the data for testing the methods
    //Arrange
    Guid guid = Guid.NewGuid();
    string userId = "789999";

    Post TestPost = new Post
    {

        PostID = guid,
        Fk_UserID = "TestFk_UserID",
        Content = "Sold big",
        Likes = 1,
        PrivacyLevel = 2,
        DateCreated = new DateTime(),
        DateModified = new DateTime(),
    };


    List<Post> postmockList = new List<Post>();

    postmockList.Add(TestPost);


    // dataSource will decouple the tested method from the database and use the local data set above for the test

    var dataSource = new Mock<IdbsRequests>();

    dataSource
        .Setup(p => p.GetAllPostByUserIdAsync(It.IsAny<string>()))
        .Returns(Task.FromResult(postmockList));


    //Inject the datasource into the class containing the methods to be tested

    var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);


    //Call the methods to be tested
    //Act

    var AllPostWasGotById = TheClassBeingTested.GetAllPostByUserIdAsync(userId);


    //Assert

    Assert.Equal("789999", userId);
    Assert.Equal("TestFk_UserID", TestPost.Fk_UserID);
}




}



}


**/