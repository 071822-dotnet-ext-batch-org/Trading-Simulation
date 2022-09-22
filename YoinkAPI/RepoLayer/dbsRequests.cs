using System;
using Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace RepoLayer
{
    public class dbsRequests
    {
        private readonly IConfiguration _config;
        private readonly SqlConnection _conn;

        public dbsRequests(IConfiguration config)
        {
            _config = config;
            _conn = new SqlConnection(_config["ConnectionStrings:DefaultConnection"]);
        }
        
        public async Task<Profile?> GetProfileByUserIDAsync(string userID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Profiles WHERE fk_userID = @userid ", _conn))
            {
                command.Parameters.AddWithValue("@userid", userID);
                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Profile p = new Profile(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetInt32(4));
                    return p;
                }
                _conn.Close();
                return null;
            }
        }

        public async Task<Profile?> CreateProfileAsync(string userID, string Name, string Email, int Privacy)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Profiles (fk_userID, name, email, privacyLevel) VALUES (@userid, @name, @email, @privacy)", _conn))
            {
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@privacy", Privacy);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 1)
                {
                    Profile p = new Profile();
                    return p;
                }
                _conn.Close();
                return null;
            }
        }

        public async Task<Profile?> EditProfileAsync(string userID, string Name, string Email, int Privacy)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Profiles SET (fk_userID = @userid, name =@name, email = @email, privacyLevel = @privacy)", _conn))
            {
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@privacy", Privacy);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 1)
                {
                    Profile p = new Profile();
                    return p;
                }
                _conn.Close();
                return null;
            }
            
        }
    
    }
}