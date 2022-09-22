using System;
namespace Models
{
    public class Friends
    {
        public Guid friendID { get; set; }
        public Guid fk_userID { get; set; }
        public Guid fk_user2ID { get; set; }
        public DateTime dateFriended { get; set; }
        public Friends()
        {

        }
    }
}

