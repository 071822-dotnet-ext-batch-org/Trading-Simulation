using System;
namespace Models
{
    public class LikeComment
    {
        public LikeComment()
        {
        }

        public LikeComment(Guid? likesCommentsID, Guid? fk_CommentID, string? fk_UserID, DateTime? dateCreated, DateTime? dateModified)
        {
            this.LikesCommentsID = likesCommentsID;
            this.Fk_CommentID = fk_CommentID;
            this.Fk_UserID = fk_UserID;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }

        public Guid? LikesCommentsID { get; set; }
        public Guid? Fk_CommentID { get; set; }
        public string? Fk_UserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }



    }
}

