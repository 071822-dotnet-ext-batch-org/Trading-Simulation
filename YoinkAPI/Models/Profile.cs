using System;

namespace Models
{
    /// <summary>
    /// This is the Model to create a new Profile - contains ProfileID, Fk_UserID, Name, Email, Picture, PrivacyLevel
    /// </summary>
    public class Profile
    {

        public Guid? ProfileID { get; set; }
        public string? Fk_UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public int? PrivacyLevel { get; set; }

        /// <summary>
        /// The default Constructor for a Profile that is empty
        /// </summary>
        public Profile()
        {
        }

        /// <summary>
        /// This is the Constructor to create a new Profile - contains ProfileID, Fk_UserID, Name, Email, Picture, PrivacyLevel
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="fk_UserID"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="picture"></param>
        /// <param name="privacyLevel"></param>
        public Profile(Guid? profileID, string? fk_UserID, string? name, string? email, string? picture, int? privacyLevel)
        {
            this.ProfileID = profileID;
            this.Fk_UserID = fk_UserID;
            this.Name = name;
            this.Email = email;
            this.Picture = picture;
            this.PrivacyLevel = privacyLevel;
        }
    }

}
