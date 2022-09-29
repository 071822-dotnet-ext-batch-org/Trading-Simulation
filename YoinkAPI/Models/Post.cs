using System;
namespace Models
{
    public class Post
    {
        public Guid? PostID { get; set; }
        public Guid? Fk_UserID { get; set; }
        // public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }//Changed from string to int
        public DateTime? DateCreated { get; set; }
        public int? PrivacyLevel { get; set; }
        public DateTime? DateModified { get; set; }
        public Post()
        {

        }

        public Post(Guid? postID, Guid? fk_UserID,  string? content, int? likes, DateTime? dateCreated, int? privacyLevel, DateTime? dateModified)
        {
            this.PostID = postID;
            this.Fk_UserID = fk_UserID;
            // this.Title = title;
            this.Content = content;
            this.Likes = likes;
            this.DateCreated = dateCreated;
            this.PrivacyLevel = privacyLevel;
            this.DateModified = dateModified;
        }
    }
}

