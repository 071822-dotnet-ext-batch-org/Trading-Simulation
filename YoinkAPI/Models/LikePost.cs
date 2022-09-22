using System;
namespace Models
{
    public class LikePost
    {
        public Guid? LikesPostsID { get; set; }
        public Guid? Fk_PostID { get; set; }
        public string? Fk_UserID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public LikePost()
        {

        }

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


