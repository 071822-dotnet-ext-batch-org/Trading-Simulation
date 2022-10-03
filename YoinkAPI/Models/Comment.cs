using System;
namespace Models
{
    /// <summary>
    /// This is the Model to create a new Comment
    /// </summary>
    public class Comment
    {
        public Guid? CommentID { get; set; }
        public string? Fk_UserID { get; set; }
        public Guid? Fk_PostID { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; } 
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Buy that is empty
        /// </summary>
        public Comment()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new Comment with porperties
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="fk_PostID"></param>
        /// <param name="content"></param>
        /// <param name="likes"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        public Comment(Guid? commentID, string? fk_UserID, Guid? fk_PostID, string? content, int? likes, DateTime? dateCreated, DateTime? dateModified)
        {
            this.CommentID = commentID;
            this.Fk_UserID = fk_UserID;
            this.Fk_PostID = fk_PostID;
            this.Content = content;
            this.Likes = likes;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }
    }
}

