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
                    Profile p = new Profile(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3),ret.GetString(4), ret.GetInt32(5));
                    return p;
                }
                _conn.Close();
                return null;
            }
        }

        public async Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture ,int? Privacy)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Profiles (fk_userID, name, email, picture, privacyLevel) VALUES (@userid, @name, @email , @picture , @privacy)", _conn))
            {
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@picture", Picture);
                command.Parameters.AddWithValue("@privacy", Privacy);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                _conn.Close();
                return false;
            }
        }

        public async Task<bool> EditProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy)
        {

            using (SqlCommand command = new SqlCommand($"UPDATE Profiles SET (fk_userID=@userid, name=@name, email=@email, picture=@picture, privacyLevel=@privacy)", _conn))
            {
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@picture", Picture);
                command.Parameters.AddWithValue("@privacy", Privacy);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                _conn.Close();
                return false;
            }
            
        }
        public async Task<List<Portfolio?>> GetALL_PortfoliosByUserIDAsync(string? userID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Portfolios WHERE fk_userID = @userid ", _conn))
            {
                List<Portfolio?> portList = new List<Portfolio?>();
                command.Parameters.AddWithValue("@userid", userID);
                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                // add list stuff
                while (ret.Read())
                {
                    Portfolio p = new Portfolio(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetInt32(9), ret.GetDecimal(10),ret.GetDateTime(11), ret.GetDateTime(12));
                    portList.Add(p);

                }
                
                _conn.Close();
                return portList;
            }
        }//End OF Get PORTFOLIO BY userID

        public async Task<Portfolio?> GetPortfolioByPorfolioIDAsync(Guid? porfolioID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Portfolios WHERE portfolioID=@portfolioID ", _conn))
            {
                command.Parameters.AddWithValue("@portfolioID", porfolioID);
                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                // add list stuff

                if(ret.Read())
                {
                    Portfolio p = new Portfolio(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetInt32(9), ret.GetDecimal(10),ret.GetDateTime(11), ret.GetDateTime(12));
                    _conn.Close();
                    return p;

                }
                _conn.Close();
                return null;
            }
        }

        public async Task<bool> CreatePortfolioAsync(string auth0Id, PortfolioDto p)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Portfolios (fk_userID, name, privacyLevel, type, originalLiquid, liquid, currentTotal) VALUES (@auth0Id, @name, @privacylevel, @type, @originalliquid, @liquid, @currenttotal)", _conn))
            {             
                command.Parameters.AddWithValue("@auth0Id", auth0Id);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@privacylevel", p.PrivacyLevel);
                command.Parameters.AddWithValue("@originalliquid", p.OriginalLiquid);
                command.Parameters.AddWithValue("@liquid", p.OriginalLiquid);
                // command.Parameters.AddWithValue("@currenttotal", p.CurrentInvestment);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                _conn.Close();
                return false;
            }
        }

        public async Task<bool> EditPortfolioAsync(Models.PortfolioDto p)
        {

            using (SqlCommand command = new SqlCommand($"UPDATE Portfolios SET (name = @name, privacyLevel = @privacylevel) WHERE portfolioID = @portfolioid", _conn))
            {            
                command.Parameters.AddWithValue("@portfolioid", p.PortfolioID);
                command.Parameters.AddWithValue("@name", p.Name); 
                command.Parameters.AddWithValue("@privacylevel", p.PrivacyLevel);
                _conn.Open();

                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                _conn.Close();
                return false;
            }
        }

        public async Task<Investment?> GetInvestmentByPortfolioIDAsync(Guid portfolioID, string symbol)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Investments WHERE fk_portfolioID = @portfolfioid AND symbol=@symbol", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", portfolioID);
                command.Parameters.AddWithValue("@symbol", symbol);
                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Investment i = new Investment(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetDecimal(9), ret.GetDateTime(10), ret.GetDateTime(11));
                    _conn.Close();
                    return i;
                }
                _conn.Close();
                return null;
            }
        }        
        
        public async Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought, DateTime? DateBought)
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
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    _conn.Close();
                    return true;
                }
                _conn.Close();
                return false;
            }
        }
        
        public async Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys)
        {
            List<Buy?> buyList = new List<Buy?>();
            using (SqlCommand command = new SqlCommand("Select * from Buys where symbol = @symbol and portfolioID = @portfolioid", _conn))
            {
                command.Parameters.AddWithValue("@symbol", AllBuys.Symbol);
                command.Parameters.AddWithValue("@portfolioid", AllBuys.Get_BuysID);
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


        public async Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold, DateTime? dateSold)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Sells (fk_Portfolio, symbol, amountSold, priceSold, dateSold) VALUES (@portfolioid, @symbol, @amountSold, @priceSold, @dateSold)", _conn))
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
                _conn.Close();
                return false;

            }


        }
        public async Task<List<Sell?>> GetAllSellBySymbolAsync(string symbol, Guid portfolioID)
        {
            List<Sell?> SellList = new List<Sell?>();
            using (SqlCommand command = new SqlCommand("Select * from Sells where symbol = @symbol and portfolioID = @portfolioid", _conn))
            {
                command.Parameters.AddWithValue("@symbol", symbol);
                command.Parameters.AddWithValue("@portfolioid", portfolioID);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Sell b = new Sell(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDateTime(5));

                    SellList.Add(b);

                }

                _conn.Close();
                return SellList;
            }
        }
    }
}