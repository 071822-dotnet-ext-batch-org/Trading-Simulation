using System;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Investment - contains InvestmentID, Fk_PortfolioID, Symbol, AmountIvested, CurrentAmount, CurrentPrice, TotalAmountBought, TotalAmountSold, AverageBuyPrice, TotalPNL, DateCreated, DateModified
    /// </summary>
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
        // public decimal? AveragedSellPrice { get; set; } 
        public decimal? TotalPNL { get; set; }
        public DateTime? DateCreated {get;set;}
        public DateTime? DateModified {get;set;}

        /// <summary>
        /// This is the Constructor to create a new Investment that is empty
        /// </summary>
        public Investment()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new Investment - contains InvestmentID, Fk_PortfolioID, Symbol, AmountIvested, CurrentAmount, CurrentPrice, TotalAmountBought, TotalAmountSold, AverageBuyPrice, TotalPNL, DateCreated, DateModified
        /// </summary>
        /// <param name="investmentID"></param>
        /// <param name="fk_PortfolioID"></param>
        /// <param name="symbol"></param>
        /// <param name="amountInvested"></param>
        /// <param name="currentAmount"></param>
        /// <param name="currentPrice"></param>
        /// <param name="totalAmountBought"></param>
        /// <param name="totalAmountSold"></param>
        /// <param name="averagedBuyPrice"></param>
        /// <param name="totalPNL"></param>
        /// <param name="DateCreated"></param>
        /// <param name="DateModified"></param>
        public Investment(Guid? investmentID, Guid? fk_PortfolioID, string? symbol, decimal? amountInvested, decimal? currentAmount, decimal? currentPrice, decimal? totalAmountBought, decimal? totalAmountSold, decimal? averagedBuyPrice, decimal? totalPNL, DateTime? DateCreated, DateTime? DateModified)
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
            // this.AveragedSellPrice = averagedSellPrice;
            this.TotalPNL = totalPNL;
            this.DateCreated = DateCreated;
            this.DateModified = DateModified;
        }
    }


}
