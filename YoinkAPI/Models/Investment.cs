using System;

namespace Models
{
    public class Investment
    {
        
        public Guid? InvestmentID { get; set; }
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountInvested { get; set; }
        public decimal? CurrentAmount { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? TotalAmountBought { get; set; }
        public decimal? TotalAmountSold { get; set; }
        public decimal? AveragedBuyPrice { get; set; }
        public decimal? AveragedSellPrice { get; set; } 
        public decimal? PNL { get; set; }

        public Investment()
        {
        }

        public Investment(Guid? investmentID, Guid? fk_PortfolioID, string? symbol, decimal? amountInvested, decimal? currentAmount, decimal? currentPrice, decimal? totalAmountBought, decimal? totalAmountSold, decimal? averagedBuyPrice, decimal? pnl)
        {
            this.InvestmentID = investmentID;
            this.Fk_PortfolioID = fk_PortfolioID;
            this.Symbol = symbol;
            this.AmountInvested = amountInvested;
            this.CurrentAmount = currentAmount;
            this.CurrentPrice = currentPrice;
            this.TotalAmountBought = totalAmountBought;
            this.TotalAmountSold = totalAmountSold;
            this.AveragedBuyPrice = averagedBuyPrice;
            this.PNL = pnl;
        }
    }


}
