
using Models;

namespace Test.Yoink
{
    public class Yoink
    {
        [Fact]
        public void InvestmentWorksCorrectly()
        {

            //Arrange

            Guid guid = Guid.NewGuid();


            //Act

            Investment newinvestment = new Investment()
            {
                InvestmentID = guid,
                Fk_PortfolioID = guid,
                Symbol = "AAPL",
                AmountInvested = 1200,
                CurrentAmount = 100,
                TotalAmountBought =4,
                AveragedBuyPrice = 150,
                AveragedSellPrice = 200,
                TotalPNL = 50,

            };


            //Assert

            Assert.Equal(newinvestment.InvestmentID, guid);


        }





    }
}