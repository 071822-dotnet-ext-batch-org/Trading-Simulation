using System;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Buy - contains BuyID, Fk_PortfolioID, Symbol, CurrentPrice, AmountBought, PriceBought, DateBought
    /// </summary>
    public class Buy
    {

        public Guid? BuyID { get; set; }
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AmountBought { get; set; }
        public decimal? PriceBought { get; set; }
        public DateTime? DateBought { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Buy that is empty
        /// </summary>
        public Buy()
        {
        }
        
        /// <summary>
        /// This is the Constructor to create a new Buy - contains BuyID, Fk_PortfolioID, Symbol, CurrentPrice, AmountBought, PriceBought, DateBought
        /// </summary>
        /// <param name="buyID"></param>
        /// <param name="fk_portfolioID"></param>
        /// <param name="symbol"></param>
        /// <param name="currentPrice"></param>
        /// <param name="amountBought"></param>
        /// <param name="priceBought"></param>
        /// <param name="dateBought"></param>
        public Buy(Guid? buyID, Guid? fk_portfolioID, string? symbol, decimal? currentPrice, decimal? amountBought, decimal? priceBought, DateTime? dateBought)
        {
            this.BuyID = buyID;
            this.Fk_PortfolioID = fk_portfolioID;
            this.Symbol = symbol;
            this.CurrentPrice = currentPrice;
            this.AmountBought = amountBought;
            this.PriceBought = priceBought;
            this.DateBought = dateBought;
        }
    }
}
