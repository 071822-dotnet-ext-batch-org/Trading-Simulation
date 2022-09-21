using System;
namespace Models
{
    public class LikeComments
    {
        public Guid likesCommentsID { get; set; }
        public Guid fk_commentID { get; set; }
        public string fk_userID { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }



    }
}

