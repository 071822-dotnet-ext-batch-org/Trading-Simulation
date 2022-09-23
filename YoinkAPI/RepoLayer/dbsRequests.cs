using System;
using Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;


namespace RepoLayer
{
    public class dbsRequests : IdbsRequests
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
<<<<<<< HEAD
=======

>>>>>>> c89bb4f050bb43b28f513ac1f0674c9b04469228
        public async Task<Buy?> AddNewBuyAsync(Guid PortfolioId, string Symbol, decimal CurrentPrice, decimal AmountBought, decimal PriceBought, DateTime DateBought)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Buys (fk_Portfolio, symbol, currentPrice, amountBought, priceBought, dateBought) VALUES (@portfolioid, @symbol, @currentprice, @amountbought, @pricebought, @datebought)", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", PortfolioId);
                command.Parameters.AddWithValue("@symbol", Symbol);
                command.Parameters.AddWithValue("@currentprice", CurrentPrice);
                command.Parameters.AddWithValue("@amountbought", AmountBought);
                command.Parameters.AddWithValue("@pricebought", PriceBought);
                command.Parameters.AddWithValue("@dateBought", DateBought);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Buy b = new Buy(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDateTime(6));
                    return b;
                }
                _conn.Close();
                return null;
            }
        }
        public async Task<List<Buy?>> GetAllBuyBySymbolAsync(string value)
        {
            List<Buy?> buyList = new List<Buy?>();
            using (SqlCommand command = new SqlCommand("Select * from Buy where symbol = @symbol", _conn))
            {
                command.Parameters.AddWithValue("@symbol", value);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Buy b = new Buy(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDateTime(6));

                    buyList.Add(b);

                }

                _conn.Close();
                return buyList;
            }
        }


        public async Task<bool?> AddNewSellAsync(Guid PortfolioId, string Symbol, decimal amountSold, decimal priceSold, DateTime dateSold)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Buys (fk_Portfolio, symbol, amountSold, priceSold, dateSold) VALUES (@portfolioid, @symbol, @amountSold, @priceSold, @dateSold)", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", PortfolioId);
                command.Parameters.AddWithValue("@symbol", Symbol);
                command.Parameters.AddWithValue("@amountSold", amountSold);
                command.Parameters.AddWithValue("@priceSold", priceSold);
                command.Parameters.AddWithValue("@dateSold", dateSold);

                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;

                }
                return false;

            }


        }
        public async Task<List<Sell?>> GetAllSellBySymbolAsync(string value)
        {
            List<Sell?> SellList = new List<Sell?>();
            using (SqlCommand command = new SqlCommand("Select * from Sell where symbol = @symbol", _conn))
            {
                command.Parameters.AddWithValue("@symbol", value);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Sell b = new Sell(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDateTime(5), ret.GetDecimal(6));

                    SellList.Add(b);

                }

                _conn.Close();
                return SellList;
            }
        }
<<<<<<< HEAD
=======

>>>>>>> c89bb4f050bb43b28f513ac1f0674c9b04469228
    }
}