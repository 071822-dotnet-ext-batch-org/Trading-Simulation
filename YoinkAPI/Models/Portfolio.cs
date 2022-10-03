using System;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Portfolio - contains PortfolioID, Fk_UserID, Name, PrivacyLevel, Type, OriginalLiquid, CurrentInvestment, Liquid, CurrentTotal, Symbols, TotalPNL, DateCreated, DateModified
    /// </summary>
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
        public decimal? TotalPNL { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Portfolio that is empty
        /// </summary>
        public Portfolio()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new Portfolio - contains PortfolioID, Fk_UserID, Name, PrivacyLevel, Type, OriginalLiquid, CurrentInvestment, Liquid, CurrentTotal, Symbols, TotalPNL, DateCreated, DateModified
        /// </summary>
        /// <param name="portfolioID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="name"></param>
        /// <param name="privacyLevel"></param>
        /// <param name="type"></param>
        /// <param name="originalLiquid"></param>
        /// <param name="currentInvestment"></param>
        /// <param name="liquid"></param>
        /// <param name="currentTotal"></param>
        /// <param name="symbols"></param>
        /// <param name="TotalPNL"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        public Portfolio(Guid? portfolioID, string? fk_UserID, string? name, int? privacyLevel, int? type, decimal? originalLiquid, decimal? currentInvestment, decimal? liquid, decimal? currentTotal, int? symbols,  decimal? TotalPNL, DateTime? dateCreated, DateTime? dateModified)
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
            this.TotalPNL = TotalPNL;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }
    }



}
