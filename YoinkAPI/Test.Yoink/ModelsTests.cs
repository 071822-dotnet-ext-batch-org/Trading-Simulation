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
          
        }



    }
}