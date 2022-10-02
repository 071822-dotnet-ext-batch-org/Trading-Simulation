using Models;
using System;

namespace Test.Yoink
{
    public class ModelsTests
    {

        // This method would test the Investment models 
        [Fact]
        public void InvestmentWorksCorrectly()
        {

            //Arrange

            Guid invt = Guid.NewGuid();

            DateTime DT = new DateTime();

            // The Investment constructors with arguments were also tested
            //Act
            Investment newinvestment1 = new Investment(invt, invt, "AAPL", 1200, 100, 50, 4, 2, 150, 50, DT, DT);

            Investment newinvestment = new Investment()
            {
                InvestmentID = invt,
                Fk_PortfolioID = invt,
                Symbol = "AAPL",
                AmountInvested = 1200,
                CurrentAmount = 100,
                CurrentPrice= 50,
                TotalAmountBought = 4,
                TotalAmountSold = 2,
                AveragedBuyPrice = 150,
                TotalPNL = 50,
                DateCreated = new DateTime(),
                DateModified = new DateTime(),

            };


            //Assert

            Assert.Equal(newinvestment.InvestmentID, invt);
            Assert.Equal(newinvestment1.InvestmentID, invt);

        }



        [Fact]
        public void postWorksCorrectly()
        {
            //Arrange
            Guid TestpostID = new Guid();

            //Act
            Post TestPost1 = new Post(TestpostID, "TestFk_UserID", "Sold big", 1, 2, new DateTime(), new DateTime());
            
            Post TestPost = new Post 
            { 

              PostID = TestpostID, 
              Fk_UserID = "TestFk_UserID",
              Content = "Sold big",
              Likes = 1,
              PrivacyLevel = 2,
              DateCreated = new DateTime(),
              DateModified = new DateTime(),


            };

            //Assert
            Assert.Equal(TestpostID, TestPost.PostID);
            Assert.Equal("TestFk_UserID", TestPost.Fk_UserID);
        }



        [Fact]
        public void sellWorksCorrectly()
        {
            //Arrange

            Guid guid = Guid.NewGuid();

            Sell? sell = new Sell(guid, guid, "GOOGL", 2000, 1000, new DateTime());
          

            Guid testSellID = new Guid();
            string testSymbol = "GOOGL";
            decimal testAmountSold = 250;



            //Act
            Sell Testsell = new Sell
            {
                SellID = testSellID,
                Symbol = testSymbol,
                AmountSold = testAmountSold
            };

            //Assert
            Assert.Equal(testSellID, Testsell.SellID);
            Assert.Equal(testSymbol, Testsell.Symbol);
            Assert.Equal(testAmountSold, Testsell.AmountSold);


        }



        [Fact]
        public void buysWorksCorrectly()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            Guid testbuyID = new Guid();
            Guid testFk_PortfolioID = new Guid();
            string symbol = "Duke";


            //Act

            Buy? buy = new Buy(guid, guid, "GOOGL", 2000, 100, 50, new DateTime());
            Buy testBuy = new Buy
            {
                BuyID = testbuyID,
                Fk_PortfolioID = testFk_PortfolioID,
                Symbol = symbol
            };
            //Assert
            Assert.Equal(testbuyID, testBuy.BuyID);
            Assert.Equal(testFk_PortfolioID, testBuy.Fk_PortfolioID);
            Assert.Equal(symbol, testBuy.Symbol);
        }



        [Fact]
        public void commentsWorksCorrectly()
        {
            //Arrange
            Guid guid = Guid.NewGuid();
            Guid testCommentID = new Guid();
            Guid testFk_UserID = new Guid();
            Guid testFk_PostID = new Guid();


            //Act
            Comment? comment = new Comment(guid,"guid", guid, "GOOGL", 5, new DateTime(), new DateTime());
            Comment testComment = new Comment
            {
                CommentID = testCommentID,
                Fk_UserID = "testFk_UserID",
                Fk_PostID = testFk_PostID,
                Content = "Hello World",
                Likes = 5,
                DateCreated = new DateTime(),
                DateModified = new DateTime(),
            };

            //Assert
            Assert.Equal(testCommentID, testComment.CommentID);
            Assert.Equal("testFk_UserID", testComment.Fk_UserID);
            Assert.Equal(testFk_PostID, testComment.Fk_PostID);
        }



        [Fact]
        public void FriendsWorksCorrectly()
        {
            //Arrange
            Guid testFriendID = new Guid();
            DateTime testDateFriended = DateTime.Now;


            //Act
            Friend? friend = new Friend(testFriendID, testFriendID, testFriendID, new DateTime());

            Friend testFriend = new Friend
            {
                FriendID = testFriendID,
                Fk_User1ID = testFriendID,
                Fk_User2ID = testFriendID,
                DateFriended = testDateFriended
            };

            //Assert
            Assert.Equal(testFriendID, testFriend.FriendID);
            Assert.Equal(testDateFriended, testFriend.DateFriended);
        }



        [Fact]
        public void usersWorksCorrectly()
        {
            //Arrange
            DateTime testDateCreated = DateTime.Now;
            string testUserID = "fdfdsafkoesaofesd";
            int testRole = 2;

            //Act
            User testUser1 = new User(testUserID, testRole, testDateCreated, testDateCreated);
            User testUser = new User
            {
                UserID = testUserID,
                Role = testRole,
                DateCreated = testDateCreated,
                DateModified = testDateCreated,
            };


            //Assert
            Assert.Equal(testDateCreated, testUser.DateCreated);
            Assert.Equal(testUserID, testUser.UserID);
            Assert.Equal(testRole, testUser.Role);
        }



        [Fact]
        public void likeCommentWorksCorrectly()
        {
            //Arrange
            Guid testLikesCommentsID = new Guid();
            DateTime testDateCreated = DateTime.Now;

            //Act
            LikeComment? likecomment = new LikeComment(testLikesCommentsID, testLikesCommentsID, "8990000000000", new DateTime(), new DateTime());

            LikeComment testLikeComment = new LikeComment
            {
                LikesCommentsID = testLikesCommentsID,
                Fk_CommentID = testLikesCommentsID,
                Fk_UserID = "8990000000000",
                DateCreated = testDateCreated,
                DateModified = testDateCreated,

        };
            //Assert
            Assert.Equal(testLikesCommentsID, testLikeComment.LikesCommentsID);
            Assert.Equal(testDateCreated, testLikeComment.DateCreated);
        }


        [Fact]
        public void likePostWorksCorrectly()
        {
            //Arrange
            Guid testLikesPostsID = new Guid();
            Guid testFk_PostID = new Guid();
            DateTime testDateCreated = DateTime.Now;

            //Act
            LikePost testLikePost1 = new LikePost(testLikesPostsID, testFk_PostID, "8990000000000", new DateTime(), new DateTime());

            LikePost testLikePost = new LikePost
            {
              LikesPostsID = testLikesPostsID,
              Fk_PostID = testFk_PostID,
              Fk_UserID = "908998899",
              DateCreated = testDateCreated,
              DateModified = testDateCreated,
            };

            //Assert
            Assert.Equal(testLikesPostsID, testLikePost.LikesPostsID);
            Assert.Equal(testFk_PostID, testLikePost.Fk_PostID);
            Assert.Equal(testDateCreated, testLikePost.DateCreated);
        }


        //To make sure watchlist model is working
        [Fact]
        public void watchlistWorksCorrectly()
        {
            //Arrange
            Guid testWatchListID = new Guid();
            string testsymbol = "Appl";
            DateTime testDateCreated = DateTime.Now;


            //Act
            Watchlist testWatchList1 = new Watchlist(testWatchListID, testWatchListID, testsymbol, testDateCreated, testDateCreated);
            
            Watchlist testWatchList = new Watchlist
            {
                WatchlistID = testWatchListID,
                FK_UserID = testWatchListID,
                Symbol = testsymbol,
                DateCreated = testDateCreated,
                DateModified = testDateCreated,

            };


            //Assert
            Assert.Equal(testWatchListID, testWatchList.WatchlistID);
            Assert.Equal(testsymbol, testWatchList.Symbol);
            Assert.Equal(testDateCreated, testWatchList.DateCreated);
        }


        [Fact]
        public void PortfolioWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            Portfolio portfolio = new Portfolio(guid, "d44d63fc-ffa8-4eb7-b81d-644547136d30", "John", 2, 2, 2000, 1000, 2500, 2300, 34,600, DT, DT);

          
            //Assert

            Assert.Equal(portfolio.PortfolioID, guid);
           

        }

        [Fact]
        public void PortfolioDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            // DateTime DT = new DateTime();


            //Act
            PortfolioDto portfolio1 = new PortfolioDto(guid, "John", 2000, 2);

            PortfolioDto portfolio = new PortfolioDto()
            {
                PortfolioID = guid,
                Name = "John",
                OriginalLiquid = 1500,
                PrivacyLevel = 2,
            };


            //Assert

            Assert.Equal(portfolio.PortfolioID, guid);


        }

        [Fact]
        public void BuyDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            // DateTime DT = new DateTime();


            //Act
            BuyDto buydto1 = new BuyDto(guid, "GOOGL", 500, 2000,250);

            BuyDto buydto = new BuyDto()
            {
                portfolioId = guid,
                Symbol = "GOOGL",
                CurrentPrice = 500,
                AmountBought = 1500,
                PriceBought = 2,
            };


            //Assert

            Assert.Equal(buydto.portfolioId, guid);


        }


        [Fact]
        public void buyWorksCorrectly()
        {
            //Arrange
            Guid guid = Guid.NewGuid();

            Guid testbuyID = new Guid();
            Guid testFk_PortfolioID = new Guid();
            string symbol = "Duke";


            //Act

            Buy? buy = new Buy(guid, guid, "GOOGL", 2000, 100, 50, new DateTime());
            Buy testBuy = new Buy
            {
                BuyID = testbuyID,
                Fk_PortfolioID = testFk_PortfolioID,
                Symbol = symbol
            };
            //Assert
            Assert.Equal(testbuyID, testBuy.BuyID);
            Assert.Equal(testFk_PortfolioID, testBuy.Fk_PortfolioID);
            Assert.Equal(symbol, testBuy.Symbol);
        }


        [Fact]
        public void Get_BuysDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            // DateTime DT = new DateTime();


            //Act
            Get_BuysDto get_buydto1 = new Get_BuysDto(guid, "GOOGL");

            Get_BuysDto get_buydto = new Get_BuysDto()
            {
                Get_BuysID = guid,
                Symbol = "GOOGL",
               
            };


            //Assert

            Assert.Equal(get_buydto.Get_BuysID, guid);
            Assert.Equal(get_buydto1.Get_BuysID, guid);

        }

        
        [Fact]
        public void GetInvestmentDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            // DateTime DT = new DateTime();


            //Act
            GetInvestmentDto getInvest = new GetInvestmentDto(guid, "GOOGL");

            GetInvestmentDto getInvest2 = new GetInvestmentDto()
            {
                PortfolioId = guid,
                Symbol = "GOOGL",

            };


            //Assert

            Assert.Equal(getInvest.PortfolioId, guid);
            Assert.Equal(getInvest2.PortfolioId, guid);

        }


        [Fact]
        public void GetInvestmentByTimeDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            GetInvestmentByTimeDto getInvesttime = new GetInvestmentByTimeDto(DT, DT, guid, "GOOGL");

            GetInvestmentByTimeDto getInvesttime2 = new GetInvestmentByTimeDto()
            {
                StartTime = DT,
                EndTime = DT,
                PortfolioId = guid,
                Symbol = "GOOGL",
               
            };


            //Assert

            Assert.Equal(getInvesttime.PortfolioId, guid);
            Assert.Equal(getInvesttime2.PortfolioId, guid);

        }



        [Fact]
        public void SellDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            // DateTime DT = new DateTime();


            //Act
            SellDto getInvesttime = new SellDto(guid, "GOOGL", 30, 700);

            SellDto getInvesttime2 = new SellDto()
            {
                Fk_PortfolioID = guid,
                Symbol = "GOOGL",
                AmountSold = 30,
                PriceSold = 700,
                

            };


            //Assert

            Assert.Equal(getInvesttime.Fk_PortfolioID, guid);
            Assert.Equal(getInvesttime2.Fk_PortfolioID, guid);

        }


        [Fact]
        public void CreatPostDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            CreatePostDto createpostdto = new CreatePostDto("Hello World", 2);

            CreatePostDto createpostdto2 = new CreatePostDto()
            {
                Content = "Hello World",
                PrivacyLevel= 2,
             
            };


            //Assert

            Assert.Equal(2, createpostdto.PrivacyLevel);
            Assert.Equal(2, createpostdto2.PrivacyLevel);

        }



        [Fact]
        public void EditPostDTOWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            EditPostDto editpostdto = new EditPostDto(guid, "Hello World", 2);

            EditPostDto editpostdto2 = new EditPostDto()
            { 
                PostId = guid,
                Content = "Hello World",
                PrivacyLevel = 2,

            };


            //Assert

            Assert.Equal(2, editpostdto.PrivacyLevel);
            Assert.Equal(2, editpostdto.PrivacyLevel);

        }


        [Fact]
        public void GetAllInvestmentsDtoWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            GetAllInvestmentsDto getallInvestmentdto = new GetAllInvestmentsDto(guid);

            GetAllInvestmentsDto getallInvestmentdto2 = new GetAllInvestmentsDto()
            {
                PortfolioID = guid,
               
            };


            //Assert

            Assert.Equal(getallInvestmentdto.PortfolioID, guid);
            Assert.Equal(getallInvestmentdto.PortfolioID, guid);

        }


        [Fact]
        public void GetProfileDtoDtoWorksCorrectly()
        {

            //Arrange

            String UserID = "45678788";


            //Act
            GetProfileDto getProfileDto = new GetProfileDto(UserID);

            GetProfileDto getProfileDto2 = new GetProfileDto()
            {
                UserID = UserID,

            };


            //Assert

            Assert.Equal(UserID, getProfileDto.UserID);
            Assert.Equal(UserID, getProfileDto2.UserID);

        }


        [Fact]
        public void PostWithCommentCountDtoWorksCorrectly()
        {

            //Arrange
            Guid guid = new Guid();
            DateTime DT = new DateTime();


            //Act
            PostWithCommentCountDto postcommentcountDto = new PostWithCommentCountDto(guid, "7899999", "Hello World", 6, 7, 3, DT, DT);

            PostWithCommentCountDto postcommentcountDto2 = new PostWithCommentCountDto()
            {
                PostID = guid,
                Fk_UserID = "7899999",
                Content = "Hello World",
                Likes = 6,
                Comments = 7,
                PrivacyLevel = 3,
                DateCreated = DT,
                DateModified = DT,



            };


            //Assert

            Assert.Equal(postcommentcountDto.PostID, guid);
            Assert.Equal(postcommentcountDto2.PostID, guid);

        }


        [Fact]
        public void LikeDtoWorksCorrectly()
        {

            //Arrange

            Guid guid = new Guid();


            //Act
            LikeDto likeDto = new LikeDto(guid);

            LikeDto likeDto2 = new LikeDto()
            {
                PostId = guid,

            };


            //Assert

            Assert.Equal(likeDto.PostId , guid);
            Assert.Equal(likeDto2.PostId, guid);

        }





    }



}