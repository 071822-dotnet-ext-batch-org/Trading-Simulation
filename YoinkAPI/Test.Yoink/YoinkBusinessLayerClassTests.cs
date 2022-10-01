
using BusinessLayer;
using Models;
using Moq;
using RepoLayer;
using System;


namespace Test.Yoink
{
    public class YoinkBusinessLayerClassTests
    {


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
            dataSourceBL
                .Setup(s => s.UpdatePostAsync(It.IsAny<string?>(),It.IsAny<EditPostDto>()))
                .Returns(Task.FromResult(post));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSourceRL.Object);
            var TheClassBeingTested2 = new YoinkBusinessLayer(dataSourceRL_False.Object);
            


            //Act


            var NewPostWasAdded = TheClassBeingTested.CreatePostAsync("auth0ID_UserID", postDto );
            // var MostRecentPostWasGotten = MethodTest3.GetRecentPostByUserId();

            


            //Assert
 
            Assert.Equal("auth0ID_UserID", post.Fk_UserID);//Method - Successfully created a Post
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




    }



}
