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


            //Act
            Investment newinvestment1 = new Investment(invt, invt, "AAPL", 1100, 50, 2, 100, 150, 40, 10, 20);

            Investment newinvestment = new Investment()
            {
                InvestmentID = invt,
                Fk_PortfolioID = invt,
                Symbol = "AAPL",
                AmountInvested = 1200,
                CurrentAmount = 100,
                TotalAmountBought = 4,
                AveragedBuyPrice = 150,
                AveragedSellPrice = 200,
                TotalPNL = 50,

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



    }
}