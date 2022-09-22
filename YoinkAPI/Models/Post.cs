using System;
namespace Models
{
    public class Posts
    {
        public Guid? PostID { get; set; }
        public Guid? Fk_UserID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Likes { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? PrivacyLevel { get; set; }
        public DateTime? DateModified { get; set; }
        public Posts()
        {

        }

        public Posts(Guid? postID, Guid? fk_UserID, string? title, string? content, string? likes, DateTime? dateCreated, int? privacyLevel, DateTime? dateModified)
        {
            this.PostID = postID;
            this.Fk_UserID = fk_UserID;
            this.Title = title;
            this.Content = content;
            this.Likes = likes;
            this.DateCreated = dateCreated;
            this.PrivacyLevel = privacyLevel;
            this.DateModified = dateModified;
        }
    }
}

