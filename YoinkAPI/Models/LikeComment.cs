using System;
namespace Models
{
    /// <summary>
    /// This is the Model to create a new LikeComment - contains LikeCommentsID, fk_CommentID, fk_UserID, DateCreated, DateModified
    /// </summary>
    public class LikeComment
    {
        public Guid? LikesCommentsID { get; set; }
        public Guid? Fk_CommentID { get; set; }
        public string? Fk_UserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// This is the Constructor to create a new LikeComment that is empty
        /// </summary>
        public LikeComment()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new LikeComment - contains LikeCommentsID, fk_CommentID, fk_UserID, DateCreated, DateModified
        /// </summary>
        /// <param name="likesCommentsID"></param>
        /// <param name="fk_CommentID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        public LikeComment(Guid? likesCommentsID, Guid? fk_CommentID, string? fk_UserID, DateTime? dateCreated, DateTime? dateModified)
        {
            this.LikesCommentsID = likesCommentsID;
            this.Fk_CommentID = fk_CommentID;
            this.Fk_UserID = fk_UserID;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }




    }
}

