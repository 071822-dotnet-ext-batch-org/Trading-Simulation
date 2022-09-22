using System;

namespace Models
{
    public class Buys
    {
     
     Guid? buyID;
     Guid? fk_portfolioID;
     string? symbol;
     decimal? currentPrice;
     decimal? amountBought;
     decimal? priceBought;
     DateTime? dateBought;
     decimal? PNL;

        public Buys()
        {
        }

        public Buys(Guid? buyID, Guid? fk_portfolioID, string? symbol, decimal? currentPrice, decimal? amountBought, decimal? priceBought, DateTime? dateBought, decimal? pNL)
        {
            this.buyID = buyID;
            this.fk_portfolioID = fk_portfolioID;
            this.symbol = symbol;
            this.currentPrice = currentPrice;
            this.amountBought = amountBought;
            this.priceBought = priceBought;
            this.dateBought = dateBought;
            PNL = pNL;
        }
    }
}
