using System;
namespace Models
{
    public class LikesPosts
    {
        public Guid likesPostsID { get; set; }
        public Guid fk_postID { get; set; }
        public string fk_userID { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public LikesPosts()
        {

        }
    }
}


