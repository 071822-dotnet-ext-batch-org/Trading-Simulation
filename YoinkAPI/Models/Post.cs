using System;
namespace Models
{
    /// <summary>
    /// This is the Model to create a new Post 
    /// </summary>
    public class Post
    {
        public Guid? PostID { get; set; }
        public string? Fk_UserID { get; set; }
        // public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Likes { get; set; }
        public int? PrivacyLevel { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Buy that is empty
        /// </summary>
        public Post()
        {

        }

        /// <summary>
        /// This is the Constructor to create a new Post with porperties
        /// </summary>
        /// <param name="postID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="content"></param>
        /// <param name="likes"></param>
        /// <param name="privacyLevel"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        public Post(Guid? postID, string? fk_UserID,  string? content, int? likes, int? privacyLevel, DateTime? dateCreated,  DateTime? dateModified)
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

