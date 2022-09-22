using System;
namespace Models
{
    public class Friend
    {
        public Guid? FriendID { get; set; }
        public Guid? Fk_User1ID { get; set; }
        public Guid? Fk_User2ID { get; set; }
        public DateTime? DateFriended { get; set; }
        public Friend()
        {

        }

        public Friend(Guid? friendID, Guid? fk_User1ID, Guid? fk_User2ID, DateTime? dateFriended)
        {
            this.FriendID = friendID;
            this.Fk_User1ID = fk_User1ID;
            this.Fk_User2ID = fk_User2ID;
            this.DateFriended = dateFriended;
        }
    }
}

