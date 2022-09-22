using System;
namespace Models
{
    public class Comments
    {
        public Guid commentID { get; set; }
        public Guid fk_userID { get; set; }
        public Guid fk_postID { get; set; }
        public string content { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public Comments()
        {
        }
    }
}

