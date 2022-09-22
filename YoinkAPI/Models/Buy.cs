using System;

namespace Models
{
    public class Buy
    {
     
        public Guid? BuyID { get; set; }
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AmountBought { get; set; }
        public decimal? PriceBought { get; set; }
        public DateTime? DateBought { get; set; }

        public Buy()
        {
        }

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
