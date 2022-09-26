using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ModelDTOs.FromFrontEnd
{
    /// <summary>
    /// This is the porfolio DTO to get updates from the front end
    /// </summary>
    public class Portfolio
    {
        // public Guid? porfolioID {get;set;}
        // public string? UserID {get;set;}
        public string? Name { get; set; } 
        // public decimal? CurrentInvestment { get; set; } //These three values will be used case by case - Just depending on which amount needs to be udated
        public decimal? OriginalLiquid { get; set; }// Each one is optional so we wont get a callback if its empty - original liquid value given
        public int? PrivacyLevel { get; set; } 
        // public decimal? Liquid { get; set; }// Current portfolio liquad value
    }//End of Portfolio from front end to update portfolio in DB

    /// <summary>
    /// This Buy DTO has everything back end will need to create a Buy table for a specific portfolio
    /// </summary>
    public class Buy
    {
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AmountBought { get; set; }
        public decimal? PriceBought { get; set; }
        public Buy(){}
        public Buy(Guid? Fk_PortfolioID, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought)
        {
            this.Fk_PortfolioID = Fk_PortfolioID;
            this.Symbol = Symbol;
            this.CurrentPrice = CurrentPrice;
            this.AmountBought  = AmountBought;
            this.PriceBought = PriceBought;
        }
    }//End of BUY


    /// <summary>
    /// This SELL DTO has everything back end will need to create a SELL table for a specific portfolio
    /// </summary>
    public class Sell
    {
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountSold { get; set; }
        public decimal? PriceSold { get; set; }
        public decimal? PNL { get; set; }
        public Sell(Guid? Fk_PortfolioID, string? Symbol, decimal? AmountSold, decimal? PriceSold, decimal? PNL)
        {
            this.Fk_PortfolioID = Fk_PortfolioID;
            this.Symbol = Symbol;
            this.AmountSold = AmountSold;
            this.PriceSold  = PriceSold;
            this.PNL = PNL;
        }
    }//End of SELL
}