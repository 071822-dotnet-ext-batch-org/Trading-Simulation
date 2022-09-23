using System;

namespace Models
{
    public class Portfolio
    {
        
        public Guid? PortfolioID { get; set; }
        public string? Fk_UserID { get; set; }
        public string? Name { get; set; }
        public int? PrivacyLevel { get; set; }
        public int? Type { get; set; }
        public decimal? OriginalLiquid { get; set; }
        public decimal? CurrentInvestment { get; set; }
        public decimal? Liquid { get; set; }
        public decimal? CurrentTotal { get; set; }
        public int? Symbols { get; set; }
        public decimal? PNL { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public Portfolio()
        {
        }

        public Portfolio(Guid? portfolioID, string? fk_UserID, string? name, int? privacyLevel, int? type, decimal? originalLiquid, decimal? currentInvestment, decimal? liquid, decimal? currentTotal, int? symbols, decimal? pnl, DateTime? dateCreated, DateTime? dateModified)
        {
            this.PortfolioID = portfolioID;
            this.Fk_UserID = fk_UserID;
            this.Name = name;
            this.PrivacyLevel = privacyLevel;
            this.Type = type;
            this.OriginalLiquid = originalLiquid;
            this.CurrentInvestment = currentInvestment;
            this.Liquid = liquid;
            this.CurrentTotal = currentTotal;
            this.Symbols = symbols;
            this.PNL = pnl;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }
    }



}
