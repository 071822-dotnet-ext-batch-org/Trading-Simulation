using System;
namespace Models
{
    /// <summary>
    /// This is the Model to create a new LikePost - contains LikesPostsID, Fk_PostID, Fk_UserID, DateCreated, DateModified
    /// </summary>
    public class LikePost
    {
        public Guid? LikesPostsID { get; set; }
        public Guid? Fk_PostID { get; set; }
        public string? Fk_UserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// This is the Constructor to create a new LikePost that is empty
        /// </summary>
        public LikePost()
        {

        }

        /// <summary>
        /// This is the Constructor to create a new LikePost - contains LikesPostsID, Fk_PostID, Fk_UserID, DateCreated, DateModified
        /// </summary>
        /// <param name="likesPostsID"></param>
        /// <param name="fk_PostID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="dateCreated"></param>
        /// <param name="dateModified"></param>
        public LikePost(Guid? likesPostsID, Guid? fk_PostID, string? fk_UserID, DateTime? dateCreated, DateTime? dateModified)
        {
            this.LikesPostsID = likesPostsID;
            this.Fk_PostID = fk_PostID;
            this.Fk_UserID = fk_UserID;
            this.DateCreated = dateCreated;
            this.DateModified = dateModified;
        }
    }
}


