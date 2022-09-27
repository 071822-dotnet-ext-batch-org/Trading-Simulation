using System;

namespace Models
{
    public class Sell
    {

        public Guid? SellID { get; set; }
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountSold { get; set; }
        public decimal? PriceSold { get; set; }
        public DateTime? DateSold { get; set; }
        // public decimal? PNL { get; set; }

        public Sell()
        {
        }

        public Sell(Guid? sellID, Guid? fk_PortfolioID, string? symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold)
        {
            this.SellID = sellID;
            this.Fk_PortfolioID = fk_PortfolioID;
            this.Symbol = symbol;
            this.AmountSold = amountSold;
            this.PriceSold = priceSold;
        //     this.PNL = pnl;
            this.DateSold = dateSold;
            // this.PNL = pNL;
        }
    }


}
