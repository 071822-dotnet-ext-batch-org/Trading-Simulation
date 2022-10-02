using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PostWithCommentCountDto
    {
        public Guid? PostID { get; set; }
        public string? Fk_UserID { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public int? Comments { get; set; }  
        public int? PrivacyLevel { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public PostWithCommentCountDto()
        {

        }

        public PostWithCommentCountDto(Guid? postID, string? fk_UserID, string? content, int? likes, int? comments, int? privacyLevel, DateTime? dateCreated, DateTime? dateModified)
        {
            this.PostID = postID;
            this.Fk_UserID = fk_UserID;
            this.Content = content;
            this.Likes = likes;
            this.Comments = comments;       
            this.DateCreated = dateCreated;
            this.PrivacyLevel = privacyLevel;
            this.DateModified = dateModified;
        }
    }

    public class AllUpdatedRowsDto
    {
        public AllUpdatedRowsDto()
        {
        }

        public AllUpdatedRowsDto(List<Investment> investments, List<Portfolio> portfolios, List<Buy> buys)
        {
            Investments = investments;
            Portfolios = portfolios;
            Buys = buys;
        }

        public List<Investment> Investments { get; set; } = new List<Investment>();
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<Buy> Buys { get; set; } = new List<Buy>();
    }
}