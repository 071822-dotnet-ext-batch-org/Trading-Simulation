using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the porfolio DTO to get updates from the front end
    /// </summary>
    public class PortfolioDto
    {
        public Guid? PortfolioID {get;set;}
        // public string? UserID {get;set;}
        public string? Name { get; set; } 
        // public decimal? CurrentInvestment { get; set; } //These three values will be used case by case - Just depending on which amount needs to be udated
        public decimal? OriginalLiquid { get; set; }// Each one is optional so we wont get a callback if its empty - original liquid value given
        public int? PrivacyLevel { get; set; } 
        public PortfolioDto(){}
        public PortfolioDto(Guid? portfolioID, string? name, decimal? originalLiquid, int? privacyLevel)
        {
            this.PortfolioID = portfolioID;
            this.Name = name;
            this.OriginalLiquid = originalLiquid;
            this.PrivacyLevel = privacyLevel;
        }
        // public decimal? Liquid { get; set; }// Current portfolio liquad value
    }//End of Portfolio from front end to update portfolio in DB

    public class ProfileDto{
        public Guid? PortfolioID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public int? PrivacyLevel { get; set; }
        public ProfileDto(){}
        public ProfileDto(Guid? PortfolioID, string? name, string? email, string? picture,int? privacyLevel)
        {
            this.PortfolioID = PortfolioID;
            this.Name = name;
            this.Email = email;
            this.Picture = picture;
            this.PrivacyLevel = privacyLevel;
        }

    }

    /// <summary>
    /// This Buy DTO has everything back end will need to create a Buy table for a specific portfolio
    /// </summary>
    public class BuyDto
    {
        public Guid? BuyID { get; set; }
        public string? Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AmountBought { get; set; }
        public decimal? PriceBought { get; set; }
        public BuyDto(){}
        public BuyDto(Guid? Fk_PortfolioID, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought)
        {
            this.BuyID = Fk_PortfolioID;
            this.Symbol = Symbol;
            this.CurrentPrice = CurrentPrice;
            this.AmountBought  = AmountBought;
            this.PriceBought = PriceBought;
        }
    }//End of BUY

    public class Get_BuysDto
    {
        public Guid? Get_BuysID { get; set; }
        public string? Symbol { get; set; }
        public Get_BuysDto(){}
        public Get_BuysDto(Guid? Get_BuysID, string? Symbol)
        {
            this.Get_BuysID = Get_BuysID;
            this.Symbol = Symbol;
        }
    }//End of GET Get_BuysDto


    /// <summary>
    /// This SELL DTO has everything back end will need to create a SELL table for a specific portfolio
    /// </summary>
    public class SellDto
    {
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountSold { get; set; }
        public decimal? PriceSold { get; set; }
        public decimal? PNL { get; set; }
        public SellDto(){}
        public SellDto(Guid? Fk_PortfolioID, string? Symbol, decimal? AmountSold, decimal? PriceSold, decimal? PNL)
        {
            this.Fk_PortfolioID = Fk_PortfolioID;
            this.Symbol = Symbol;
            this.AmountSold = AmountSold;
            this.PriceSold  = PriceSold;
            this.PNL = PNL;
        }
    }//End of SELL
}