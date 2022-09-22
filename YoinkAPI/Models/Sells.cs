using System;

namespace Models
{
    public class Sells
    {

        Guid? sellID;
        Guid? fk_portfolioID;
        string? symbol;
        decimal? amountSold;
        decimal? priceSold;
        DateTime? dateSold;
        decimal? PNL;

        public Sells()
        {
        }

        public Sells(Guid? sellID, Guid? fk_portfolioID, string? symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold, decimal? PNL)
        {
            this.sellID = sellID;
            this.fk_portfolioID = fk_portfolioID;
            this.symbol = symbol;
            this.amountSold = amountSold;
            this.priceSold = priceSold;
            this.dateSold = dateSold;
            this.PNL = PNL;
        }
    }


}
