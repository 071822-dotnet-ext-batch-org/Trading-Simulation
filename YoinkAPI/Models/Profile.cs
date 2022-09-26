using System;

namespace Models
{
    public class Profile
    {

        public Guid? ProfileID { get; set; }
        public string? Fk_UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public int? PrivacyLevel { get; set; }

        public Profile()
        {
        }

        public Profile(Guid? profileID, string? fk_UserID, string? name, string? email, string? image, int? privacyLevel)
        {
            this.ProfileID = profileID;
            this.Fk_UserID = fk_UserID;
            this.Name = name;
            this.Email = email;
            this.Image = image;
            this.PrivacyLevel = privacyLevel;
        }
    }


}
