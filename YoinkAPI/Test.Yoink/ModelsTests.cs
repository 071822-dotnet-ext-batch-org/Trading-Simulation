

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
                CurrentPrice = 50,
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
            Post TestPost = new Post { PostID = TestpostID, Fk_UserID = TestFk_UserID };

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
            Guid testbuyID = new Guid();
            Guid testFk_PortfolioID = new Guid();
            string symbol = "Duke";
            //Act
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
            Guid testCommentID = new Guid();
            Guid testFk_UserID = new Guid();
            Guid testFk_PostID = new Guid();
            //Act
            Comment testComment = new Comment
            {
                CommentID = testCommentID,
                Fk_UserID = testFk_UserID,
                Fk_PostID = testFk_PostID

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
            Friend testFriend = new Friend
            {
                FriendID = testFriendID,
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
            User testUser = new User
            {
                DateCreated = testDateCreated,
                UserID = testUserID,
                Role = testRole
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
            LikeComment testLikeComment = new LikeComment
            {
                LikesCommentsID = testLikesCommentsID,
                DateCreated = testDateCreated

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
            LikePost testLikePost = new LikePost
            {
                LikesPostsID = testLikesPostsID,
                Fk_PostID = testFk_PostID,
                DateCreated = testDateCreated
            };
            //Assert
            Assert.Equal(testLikesPostsID, testLikePost.LikesPostsID);
            Assert.Equal(testFk_PostID, testLikePost.Fk_PostID);
            Assert.Equal(testDateCreated, testLikePost.DateCreated);
        }


        //to make sure watchlist model is working
        [Fact]
        public void watchlistWorksCorrectly()
        {
            //Arrange
            Guid testWatchListID = new Guid();
            string testsymbol = "Appl";
            DateTime testDateCreated = DateTime.Now;


            //Act
            Watchlist testWatchList = new Watchlist
            {
                WatchlistID = testWatchListID,
                Symbol = testsymbol,
                DateCreated = testDateCreated
            };


            //Assert
            Assert.Equal(testWatchListID, testWatchList.WatchlistID);
            Assert.Equal(testsymbol, testWatchList.Symbol);
            Assert.Equal(testDateCreated, testWatchList.DateCreated);
        }
        [Fact]
        public void TestAllBuy()
        {

            //Arrange

            Guid testBuyID = new Guid();
            Guid testFk_PortfolioID = new Guid();
            string testSymbol = "NIKE";
            decimal testCurrentPrice = 2300;
            decimal testAmountBought = 2400;
            decimal? testPriceBought = 1;
            DateTime testDateBought = new DateTime();


            //Act
            Buy testBuy1 = new Buy(testBuyID, testFk_PortfolioID, testSymbol, testCurrentPrice, testAmountBought, testPriceBought, testDateBought);

            Buy testbuy2 = new Buy()
            {
                BuyID = testBuyID,
                Fk_PortfolioID = testFk_PortfolioID,
                Symbol = testSymbol,
                CurrentPrice = testCurrentPrice,
                AmountBought = testAmountBought,
                PriceBought = testPriceBought,
                DateBought = testDateBought

            };


            //Assert

            Assert.Equal(testBuy1.BuyID, testBuyID);
            Assert.Equal(testbuy2.BuyID, testBuyID);

        }

        [Fact]
        public void TestAllSell()
        {

            //Arrange


            Guid testSellID = new Guid();
            Guid testFk_PortfolioID = new Guid();
            string testSymbol = "NIKE";
            decimal testAmountSold = 2300;
            decimal testPriceSold = 2400;
            DateTime testDateBought = new DateTime();


            //Act
            Sell testSell = new Sell(testSellID, testFk_PortfolioID, testSymbol, testAmountSold, testPriceSold, testDateBought);

            Sell testSell2 = new Sell()
            {
                SellID = testSellID,
                Fk_PortfolioID = testFk_PortfolioID,
                Symbol = testSymbol,
                AmountSold = testAmountSold,
                PriceSold = testPriceSold,
                DateSold = testDateBought

            };


            //Assert

            Assert.Equal(testSell.SellID, testSellID);
            Assert.Equal(testSell2.SellID, testSellID);

        }
        

        [Fact]
        public void PortfolioWorksCorrectly()

        {

            //Arrange


            Guid testCommentID = new Guid();
            Guid testFk_UserID = new Guid();
            Guid TestFk_PostID = new Guid();
            string testContent = "NIKE";
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();



            //Act
            Comment dummyComment = new Comment(testCommentID, testFk_UserID, TestFk_PostID, testContent, testDateCreated, testDateModi);

            Comment dummyComment2 = new Comment()
            {
                CommentID = testCommentID,
                Fk_UserID = testFk_UserID,
                Fk_PostID = TestFk_PostID,
                Content = testContent,
                DateCreated = testDateCreated,
                DateModified = testDateModi

            };


            //Assert

            Assert.Equal(dummyComment.CommentID, testCommentID);
            Assert.Equal(dummyComment2.CommentID, testCommentID);

        }
        [Fact]
        public void TestAllFriend()
        {

            //Arrange

            Guid testFriendID = new Guid();
            Guid testFk_UserID = new Guid();
            Guid TestFk_User2ID = new Guid();
            DateTime testDateFriended = new DateTime();
            //Act
            Friend dummyFriend = new Friend(testFriendID, testFk_UserID, TestFk_User2ID, testDateFriended);

            Friend dummyFriend2 = new Friend()
            {
                FriendID = testFriendID,
                Fk_User1ID = testFk_UserID,
                Fk_User2ID = TestFk_User2ID,
                DateFriended = testDateFriended

            };


            //Assert

            Assert.Equal(dummyFriend.FriendID, testFriendID);
            Assert.Equal(dummyFriend2.FriendID, testFriendID);

        }
        [Fact]
        public void TestAllPost()
        {

            //Arrange

            Guid testPostID = new Guid();
            Guid testFk_UserID = new Guid();
            string testcontent = "content";
            string testLikes = "Likes";
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();
            int privacyLevel = 1;
            //Act
            Post dummyPost = new Post(testPostID, testFk_UserID, testcontent, testLikes, testDateCreated, privacyLevel, testDateModi);

            Post dummyPost2 = new Post()
            {
                PostID = testPostID,
                Fk_UserID = testFk_UserID,
                Content = testcontent,
                Likes = testLikes,
                DateCreated = testDateCreated,
                PrivacyLevel = privacyLevel,
                DateModified = testDateModi

            };


            //Assert

            Assert.Equal(dummyPost.PostID, testPostID);
            Assert.Equal(dummyPost2.PostID, testPostID);

        }
        [Fact]
        public void TestAllLikeProfile()
        {

            //Arrange

            Guid testProfileID = new Guid();
            string testFk_UserID = "12";
            string testName = "content";
            string testemail = "Likes";
            string testPicture = "Likes";
            int privacyLevel = 1;
            //Act
            Profile dummyProfile = new Profile(testProfileID, testFk_UserID, testName, testemail, testPicture, privacyLevel);

            Profile dummyProfile2 = new Profile()
            {
                ProfileID = testProfileID,
                Fk_UserID = testFk_UserID,
                Name = testName,
                Email = testemail,
                Picture = testPicture,
                PrivacyLevel = privacyLevel

            };


            //Assert

            Assert.Equal(dummyProfile.Email, testemail);
            Assert.Equal(dummyProfile2.Email, testemail);

        }
        [Fact]
        public void TestAllLikeWatchlist()
        {

            //Arrange

            Guid testWatchlistID = new Guid();
            Guid testFk_UserID = new Guid();
            string testSymbol = "content";
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();
            //Act
            Watchlist dummyWatchlist = new Watchlist(testWatchlistID, testFk_UserID, testSymbol, testDateCreated, testDateModi);

            Watchlist dummyWatchlist2 = new Watchlist()
            {
                WatchlistID = testWatchlistID,
                FK_UserID = testFk_UserID,
                Symbol = testSymbol,
                DateCreated = testDateCreated,
                DateModified = testDateModi
            };


            //Assert

            Assert.Equal(dummyWatchlist.WatchlistID, testWatchlistID);
            Assert.Equal(dummyWatchlist2.WatchlistID, testWatchlistID);

        }
        [Fact]
        public void TestAllLikeUser()
        {

            //Arrange

            string testUserID = "Get";
            int testRole = 1;
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();
            //Act
            User dummyUser = new User(testUserID, testRole, testDateCreated, testDateModi);

            User dummyUser2 = new User()
            {
                UserID = testUserID,
                Role = testRole,
                DateCreated = testDateCreated,
                DateModified = testDateModi
            };


            //Assert

            Assert.Equal(dummyUser.UserID, testUserID);
            Assert.Equal(dummyUser2.UserID, testUserID);

        }
        [Fact]
        public void TestAllLikeComment()
        {

            //Arrange

            Guid testCommentID = new Guid();
            Guid testFk_CommentID = new Guid();
            string testUserID = "content";
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();
            //Act
            LikeComment dummyLikecomment = new LikeComment(testCommentID, testFk_CommentID, testUserID, testDateCreated, testDateModi);

            LikeComment dummylikeComment2 = new LikeComment()
            {
                LikesCommentsID = testCommentID,
                Fk_CommentID = testFk_CommentID,
                Fk_UserID = testUserID,
                DateCreated = testDateCreated,
                DateModified = testDateModi
            };


            //Assert

            Assert.Equal(dummyLikecomment.LikesCommentsID, testCommentID);
            Assert.Equal(dummylikeComment2.LikesCommentsID, testCommentID);

        }
        [Fact]
        public void TestAlllikePost()
        {

            //Arrange

            Guid testLikePostID = new Guid();
            Guid testFk_PostID = new Guid();
            string testUserID = "content";
            DateTime testDateCreated = new DateTime();
            DateTime testDateModi = new DateTime();
            //Act
            LikePost dummyLikepost = new LikePost(testLikePostID, testFk_PostID, testUserID, testDateCreated, testDateModi);

            LikePost dummylikepost2 = new LikePost()
            {
                LikesPostsID = testLikePostID,
                Fk_PostID = testFk_PostID,
                Fk_UserID = testUserID,
                DateCreated = testDateCreated,
                DateModified = testDateModi

            };


            //Assert


            Assert.Equal(dummyLikepost.LikesPostsID, testLikePostID);
            Assert.Equal(dummylikepost2.LikesPostsID, testLikePostID);

        }

            Guid guid = Guid.NewGuid();

            DateTime DT = new DateTime();


            //Act
            Portfolio portfolio = new Portfolio(guid, "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", 2, 2, 2000, 1000, 2500, 2300, 34,600, DT, DT);

          
            //Assert

            Assert.Equal(portfolio.PortfolioID, guid);
           

        }





    }



