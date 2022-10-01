using System;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Sell - contains SellID, Fk_PortfolioID, Symbol, AmountSold, PriceSold, DateSold
    /// </summary>
    public class Sell
    {

        public Guid? SellID { get; set; }
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountSold { get; set; }
        public decimal? PriceSold { get; set; }
        public DateTime? DateSold { get; set; }

        /// <summary>
        /// This is the Model to create a new Sell that is empty
        /// </summary>
        public Sell()
        {
        }

        /// <summary>
        /// This is the Model to create a new Sell - contains SellID, Fk_PortfolioID, Symbol, AmountSold, PriceSold, DateSold
        /// </summary>
        /// <param name="sellID"></param>
        /// <param name="fk_PortfolioID"></param>
        /// <param name="symbol"></param>
        /// <param name="amountSold"></param>
        /// <param name="priceSold"></param>
        /// <param name="dateSold"></param>
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
