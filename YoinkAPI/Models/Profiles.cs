using System;

namespace Models
{
    public class Profiles
    {

         Guid? profileID;
         string? fk_userID;
         string? name;
         string? email;
         int? privacyLevel;

        public Profiles()
        {
        }

        public Profiles(Guid? profileID, string? fk_userID, string? name, string? email, int? privacyLevel)
        {
            this.profileID = profileID;
            this.fk_userID = fk_userID;
            this.name = name;
            this.email = email;
            this.privacyLevel = privacyLevel;
        }
    }


}
