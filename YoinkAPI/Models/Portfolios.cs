using System;

namespace Models
{
    public class Portfolios
    {
        
         Guid? portfolioID;
         string? fk_userID;
         string? name;
         int? privacyLevel;
         int? type;
         decimal? originalLiquid;
         decimal? currentInvestment;
         decimal? liquid;  
         decimal? currentTotal; 
         int? symbols;
         DateTime? dateCreated;
         DateTime? dateModified;

        public Portfolios()
        {
        }

        public Portfolios(Guid? portfolioID, string? fk_userID, string? name, int? privacyLevel, int? type, decimal? originalLiquid, decimal? currentInvestment, decimal? liquid, decimal? currentTotal, int? symbols, DateTime? dateCreated, DateTime? dateModified)
        {
            this.portfolioID = portfolioID;
            this.fk_userID = fk_userID;
            this.name = name;
            this.privacyLevel = privacyLevel;
            this.type = type;
            this.originalLiquid = originalLiquid;
            this.currentInvestment = currentInvestment;
            this.liquid = liquid;
            this.currentTotal = currentTotal;
            this.symbols = symbols;
            this.dateCreated = dateCreated;
            this.dateModified = dateModified;
        }
    }



}
