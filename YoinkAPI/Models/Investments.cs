using System;

namespace Models
{
    public class Investments
    {
        
        Guid? investmentID;
        Guid? fk_portfolioID;
        string? symbol;
        decimal? amountInvested;
        decimal? currentAmount;
        decimal? currentPrice;
        decimal? totalAmountBought;
        decimal? totalAmountSold;
        decimal? averagedBuyPrice;
        decimal? averagedSellPrice; 
        decimal? totalPNL;

        public Investments()
        {
        }

        public Investments(Guid? investmentID, Guid? fk_portfolioID, string? symbol, decimal? amountInvested, decimal? currentAmount, decimal? currentPrice, decimal? totalAmountBought, decimal? totalAmountSold, decimal? averagedBuyPrice, decimal? averagedSellPrice, decimal? totalPNL)
        {
            this.investmentID = investmentID;
            this.fk_portfolioID = fk_portfolioID;
            this.symbol = symbol;
            this.amountInvested = amountInvested;
            this.currentAmount = currentAmount;
            this.currentPrice = currentPrice;
            this.totalAmountBought = totalAmountBought;
            this.totalAmountSold = totalAmountSold;
            this.averagedBuyPrice = averagedBuyPrice;
            this.averagedSellPrice = averagedSellPrice;
            this.totalPNL = totalPNL;
        }
    }


}
