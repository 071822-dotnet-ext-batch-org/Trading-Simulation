using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new PortfolioDto - contains PortfolioID, Name, OriginalLiquid, PrivacyLevel
    /// </summary>
    public class PortfolioDto
    {
        public Guid? PortfolioID {get;set;}
        // public string? UserID {get;set;}
        public string? Name { get; set; } 
        // public decimal? CurrentInvestment { get; set; } //These three values will be used case by case - Just depending on which amount needs to be udated
        public decimal? OriginalLiquid { get; set; }// Each one is optional so we wont get a callback if its empty - original liquid value given
        public int? PrivacyLevel { get; set; } 

        /// <summary>
        /// This is the Constructor to create a new PortfolioDto that is empty
        /// </summary>
        public PortfolioDto(){}

        /// <summary>
        /// This is the Constructor to create a new PortfolioDto - contains PortfolioID, Name, OriginalLiquid, PrivacyLevel
        /// </summary>
        /// <param name="portfolioID"></param>
        /// <param name="name"></param>
        /// <param name="originalLiquid"></param>
        /// <param name="privacyLevel"></param>
        public PortfolioDto(Guid? portfolioID, string? name, decimal? originalLiquid, int? privacyLevel)
        {
            this.PortfolioID = portfolioID;
            this.Name = name;
            this.OriginalLiquid = originalLiquid;
            this.PrivacyLevel = privacyLevel;
        }
        // public decimal? Liquid { get; set; }// Current portfolio liquad value
    }//End of Portfolio from front end to update portfolio in DB

    /// <summary>
    /// This is the Model to create a new ProfileDto - contains  Name, Email, Picture, PrivacyLevel
    /// </summary>
    public class ProfileDto{
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public int? PrivacyLevel { get; set; }

        /// <summary>
        /// This is the Constructor to create a new ProfileDto that is empty
        /// </summary>
        public ProfileDto(){}

        /// <summary>
        /// This is the Constructor to create a new ProfileDto - contains  Name, Email, Picture, PrivacyLevel
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="picture"></param>
        /// <param name="privacyLevel"></param>
        public ProfileDto(string? name, string? email, string? picture,int? privacyLevel)
        {
            this.Name = name;
            this.Email = email;
            this.Picture = picture;
            this.PrivacyLevel = privacyLevel;
        }

    }

    /// <summary>
    /// This is the Model to create a new BuyDto - contains  portfolioId, Symbol, CurrentPrice, AmountBought, PriceBought
    /// </summary>
    public class BuyDto
    {
        public Guid? portfolioId { get; set; }  
        public string? Symbol { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? AmountBought { get; set; }
        public decimal? PriceBought { get; set; }

        /// <summary>
        /// This is the Constructor to create a new BuyDto thats empty
        /// </summary>
        public BuyDto(){}

        /// <summary>
        /// This is the Constructor to create a new BuyDto - contains  portfolioId, Symbol, CurrentPrice, AmountBought, PriceBought
        /// </summary>
        /// <param name="portfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="CurrentPrice"></param>
        /// <param name="AmountBought"></param>
        /// <param name="PriceBought"></param>
        public BuyDto(Guid? portfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought)
        {
            this.portfolioId = portfolioId; 
            this.Symbol = Symbol;
            this.CurrentPrice = CurrentPrice;
            this.AmountBought  = AmountBought;
            this.PriceBought = PriceBought;
        }
    }//End of BUY

    /// <summary>
    /// This is the Model to create a new BuyDto - contains  Get_BuysID, Symbol
    /// </summary>
    public class Get_BuysDto
    {
        public Guid? Get_BuysID { get; set; }
        public string? Symbol { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Get_BuysDto thats empty
        /// </summary>
        public Get_BuysDto(){}

        /// <summary>
        /// This is the Constructor to create a new BuyDto - contains  Get_BuysID, Symbol
        /// </summary>
        /// <param name="Get_BuysID"></param>
        /// <param name="Symbol"></param>
        public Get_BuysDto(Guid? Get_BuysID, string? Symbol)
        {
            this.Get_BuysID = Get_BuysID;
            this.Symbol = Symbol;
        }
    }//End of GET Get_BuysDto

    /// <summary>
    /// This is the Model to create a new GetSellsDto - contains  PortfolioId, Symbol
    /// </summary>
    public class GetSellsDto
    {
        public Guid? PortfolioId { get; set; }
        public string? Symbol { get; set; }

        /// <summary>
        /// This is the Constructor to create a new GetSellsDto that is empty
        /// </summary>
        public GetSellsDto() { }

        /// <summary>
        /// This is the Constructor to create a new GetSellsDto - contains  PortfolioId, Symbol
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        public GetSellsDto(Guid? PortfolioId, string? Symbol)
        {
            this.PortfolioId = PortfolioId;
            this.Symbol = Symbol;
        }
    }//End of GET SellsDto

    /// <summary>
    /// This is the Model to create a new GetInvestmentDto - contains  PortfolioId, Symbol
    /// </summary>
    public class GetInvestmentDto
    {
        public Guid? PortfolioId { get; set; }
        public string? Symbol { get; set; }

        /// <summary>
        /// This is the Constructor to create a new GetInvestmentDto
        /// </summary>
        public GetInvestmentDto() { }

        /// <summary>
        /// This is the Contructor to create a new GetInvestmentDto - contains  PortfolioId, Symbol
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        public GetInvestmentDto(Guid? PortfolioId, string? Symbol)
        {
            this.PortfolioId = PortfolioId;
            this.Symbol = Symbol;
        }
    }//End of GET InvestmentDto

    /// <summary>
    /// This is the Model to create a new GetInvestmentByTimeDto - contains  PortfolioId, Symbol, StartTime, EndTime
    /// </summary>
    public class GetInvestmentByTimeDto
    {
        public Guid? PortfolioId { get; set; }
        public string? Symbol { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }   

        /// <summary>
        /// This is the Constructor to create a new GetInvestmentByTimeDto that is Empty
        /// </summary>
        public GetInvestmentByTimeDto() { }

        /// <summary>
        /// This is the Constructor to create a new GetInvestmentByTimeDto - contains  PortfolioId, Symbol, StartTime, EndTime
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        public GetInvestmentByTimeDto(DateTime StartTime, DateTime EndTime, Guid? PortfolioId, string? Symbol)
        {
            this.StartTime = StartTime; 
            this.EndTime = EndTime; 
            this.PortfolioId = PortfolioId;
            this.Symbol = Symbol;
        }
    }//End of GET InvestmentByTimeDto


    /// <summary>
    /// This is the Model to create a new SellDto - contains FK_PortfolioID, Symbol, Amountsold, Pricesold
    /// </summary>
    public class SellDto
    {
        public Guid? Fk_PortfolioID { get; set; }
        public string? Symbol { get; set; }
        public decimal? AmountSold { get; set; }
        public decimal? PriceSold { get; set; }

        /// <summary>
        /// This is the Constructor to create a new SellDto that is empty
        /// </summary>
        public SellDto(){}

        /// <summary>
        /// This is the Constructor to create a new SellDto - contains FK_PortfolioID, Symbol, Amountsold, Pricesold
        /// </summary>
        /// <param name="Fk_PortfolioID"></param>
        /// <param name="Symbol"></param>
        /// <param name="AmountSold"></param>
        /// <param name="PriceSold"></param>
        public SellDto(Guid? Fk_PortfolioID, string? Symbol, decimal? AmountSold, decimal? PriceSold)
        {
            this.Fk_PortfolioID = Fk_PortfolioID;
            this.Symbol = Symbol;
            this.AmountSold = AmountSold;
            this.PriceSold  = PriceSold;
        }
    }//End of SELL

    /// <summary>
    /// This is the Model to create a new CreatePostDto - contains Content, PrivacyLevel
    /// </summary>
    public class CreatePostDto
    {
        public string? Content { get; set; }
        public int? PrivacyLevel { get; set; }

        /// <summary>
        /// This is the Constructor to create a new CreatePostDto that is empty
        /// </summary>
        public CreatePostDto() { }

        /// <summary>
        /// This is the Constructor to create a new CreatePostDto - contains Content, PrivacyLevel
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="PrivacyLevel"></param>
        public CreatePostDto(string? Content, int? PrivacyLevel)
        {
            this.Content = Content;
            this.PrivacyLevel = PrivacyLevel;
        }
    }

    /// <summary>
    /// This is the Model to create a new GetProfileDto - contains UserID
    /// </summary>
    public class GetProfileDto
    {
        public string? UserID { get; set; }

        /// <summary>
        /// This is the Constructor to create a new GetProfileDto that is empty
        /// </summary>
        public GetProfileDto()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new GetProfileDto - contains UserID
        /// </summary>
        /// <param name="userID"></param>
        public GetProfileDto(string? userID)
        {
            UserID = userID;
        }

    }

    /// <summary>
    /// This is the Model to create a new GetAllInvestmentsDto - contains PortfolioID
    /// </summary>
    public class GetAllInvestmentsDto 
    {
        public Guid? PortfolioID { get; set; }

        /// <summary>
        /// This is the Constructor to create a new GetAllInvestmentsDto that is empty
        /// </summary>
        public GetAllInvestmentsDto()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new GetAllInvestmentsDto - contains PortfolioID
        /// </summary>
        /// <param name="portfolioID"></param>
        public GetAllInvestmentsDto(Guid? portfolioID)
        {
            PortfolioID = portfolioID;
        }

    }

    /// <summary>
    /// This is the Model to create a new EditPostDto - contains PostId, Content, PrivacyLevel
    /// </summary>
    public class EditPostDto
    {
        public Guid? PostId { get; set; }
        public string? Content { get; set; }
        public int? PrivacyLevel { get; set; }

        /// <summary>
        /// This is the Constructor to create a new EditPostDto that is empty
        /// </summary>
        public EditPostDto() { }

        /// <summary>
        /// This is the Constructor to create a new EditPostDto - contains PostId, Content, PrivacyLevel
        /// </summary>
        /// <param name="PostId"></param>
        /// <param name="Content"></param>
        /// <param name="PrivacyLevel"></param>
        public EditPostDto(Guid? PostId, string? Content, int? PrivacyLevel)
        {
            this.PostId = PostId;
            this.Content = Content;
            this.PrivacyLevel = PrivacyLevel;
        }
    }

    /// <summary>
    /// This is the Model to create a new LikeDto - contains PostId
    /// </summary>
    public class LikeDto
    {
        public Guid PostId { get; set; }

        /// <summary>
        /// This is the Constructor to create a new LikeDto that is empty
        /// </summary>
        public LikeDto() { }

        /// <summary>
        /// This is the Constructor to create a new LikeDto - contains PostId
        /// </summary>
        /// <param name="PostId"></param>
        public LikeDto(Guid PostId)
        {
            this.PostId = PostId;
        }
    }

}