using System;
namespace Models
{
    public class Posts
    {
        public Guid postID { get; set; }
        public Guid fk_userID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string likes { get; set; }
        public DateTime dateCreated { get; set; }
        public int privacyLevel { get; set; }
        public DateTime dateModified { get; set; }
        public Posts()
        {

        }
    }
}

