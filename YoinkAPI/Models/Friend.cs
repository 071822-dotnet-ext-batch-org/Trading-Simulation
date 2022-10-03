using System;
namespace Models
{
    /// <summary>
    /// This is the Model to create a new Friend
    /// </summary>
    public class Friend
    {
        public Guid? FriendID { get; set; }
        public Guid? Fk_User1ID { get; set; }
        public Guid? Fk_User2ID { get; set; }
        public DateTime? DateFriended { get; set; }

        /// <summary>
        /// This is the Constructor to create a new Friend that is empty
        /// </summary>
        public Friend()
        {

        }

        /// <summary>
        /// This is the Constructor to create a new Friend with porperties
        /// </summary>
        /// <param name="friendID"></param>
        /// <param name="fk_User1ID"></param>
        /// <param name="fk_User2ID"></param>
        /// <param name="dateFriended"></param>
        public Friend(Guid? friendID, Guid? fk_User1ID, Guid? fk_User2ID, DateTime? dateFriended)
        {
            this.FriendID = friendID;
            this.Fk_User1ID = fk_User1ID;
            this.Fk_User2ID = fk_User2ID;
            this.DateFriended = dateFriended;
        }
    }
}

