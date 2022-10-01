using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.ModelDTOs.BackToFrontEnd
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
}