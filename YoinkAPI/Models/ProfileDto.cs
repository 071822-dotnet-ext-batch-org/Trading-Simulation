using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(string? name, string? email, int privacyLevel)
        {
            Name = name;
            Email = email;
            PrivacyLevel = privacyLevel;
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public int PrivacyLevel { get; set; }


    }
}
