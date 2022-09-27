using Models;

namespace Test.Yoink
{
    public class ModelsTests
    {
        [Fact]
        public void InvestmentWorksCorrectly()
        {

            //Arrange

            Guid invt = Guid.NewGuid();

            DateTime DT = new DateTime();


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
            Guid TestFk_UserID = new Guid();

            //Act
            Post TestPost1 = new Post(TestpostID, TestFk_UserID, "Sold big", "1", new DateTime(), 2, new DateTime());
            Post TestPost = new Post 
            { PostID = TestpostID, 
              Fk_UserID = TestFk_UserID,
              Content = "Sold big",
              Likes = "1",
              DateCreated = new DateTime(),
              PrivacyLevel = 2,
              DateModified = new DateTime(),

        };

            //Assert
            Assert.Equal(TestpostID, TestPost.PostID);
            Assert.Equal(TestFk_UserID, TestPost.Fk_UserID);
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
            Comment? buy = new Comment(guid, guid, guid, "GOOGL", new DateTime(), new DateTime());
            Comment testComment = new Comment
            {
                CommentID = testCommentID,
                Fk_UserID = testFk_UserID,
                Fk_PostID = testFk_PostID,
                Content = "Hello World",
                DateCreated = new DateTime(),
                DateModified = new DateTime(),
            };

            //Assert
            Assert.Equal(testCommentID, testComment.CommentID);
            Assert.Equal(testFk_UserID, testComment.Fk_UserID);
            Assert.Equal(testFk_PostID, testComment.Fk_PostID);
        }



        [Fact]
        public void FriendsWorksCorrectly()
        {
            //Arrange
            Guid testFriendID = new Guid();
            DateTime testDateFriended = DateTime.Now;


            //Act
            Friend? buy = new Friend(testFriendID, testFriendID, testFriendID, new DateTime());

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

            DateTime DT = new DateTime();


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




    }



}