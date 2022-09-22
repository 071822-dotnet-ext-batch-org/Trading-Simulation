using System;
namespace Models
{
    public class Comment
    {
        public Guid? CommentID { get; set; }
        public Guid? Fk_UserID { get; set; }
        public Guid? Fk_PostID { get; set; }
        public string? Content { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Comment()
        {
        }

        public Comment(Guid? commentID, Guid? fk_UserID, Guid? fk_PostID, string? content, DateTime? dateCreated, DateTime? dateModified)
        {
            this.CommentID = commentID;
            this.Fk_UserID = fk_UserID;
            this.Fk_PostID = fk_PostID;
            this.Content = content;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }
    }
}

