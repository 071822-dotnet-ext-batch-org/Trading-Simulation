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

        /// <summary>
        /// Presents profile information to the user.
        /// Retrieves user info for posts.
        /// Requires logged in user via Auth0.        
        /// </summary>
        /// <returns>retrievedProfile Profile object</returns>
        public async Task<Profile?> GetProfileByUserIDAsync(string userID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Profiles WHERE fk_userID=@userid ", _conn))
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

        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">ProfileDto</param>
        /// <returns>new portfolio object</returns>
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

            using (SqlCommand command = new SqlCommand($"UPDATE Profiles SET name=@name, email=@email, picture=@picture, privacyLevel=@privacy WHERE fk_userID=@userid", _conn))
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

        /// <summary>
        /// Retrieves ALL portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <returns>new portfolio object</returns>
        public async Task<List<Portfolio?>> GetALL_PortfoliosByUserIDAsync(string? userID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Portfolios WHERE fk_userID = @userid ORDER BY dateModified DESC", _conn))
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

        /// <summary>
        /// Retrieves Portfolio based on PortfolioID. 
        /// Takes Guid of PortfolioID
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="portfolioID">Guid from database</param>
        /// <returns>new portfolio object, named retrievedPortfolio</returns>
        public async Task<Portfolio?> GetPortfolioByPorfolioIDAsync(Guid? porfolioID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Portfolios WHERE portfolioID=@portfolioID", _conn))
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

        /// <summary>
        /// Creates a new Portfolio for the user's profile.
        /// Takes PortfolioDto (portfolioID, name, originalLiquid, and privacyLevel)
        /// Requires logged in user via Auth0.      
        /// </summary>
        /// <param name="auth0Id">contains authentication credentials</param>
        /// <param name="p">PortfolioDto</param>
        /// <returns>new portfolio object</returns>
        public async Task<bool> CreatePortfolioAsync(string auth0Id, PortfolioDto p)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Portfolios (fk_userID, name, privacyLevel, originalLiquid, liquid) VALUES (@auth0Id, @name, @privacylevel, @originalliquid, @liquid)", _conn))
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

        /// <summary>
        /// Allows user to edit their portfolio, things like name, privacyLevel, etc.
        /// </summary>
        /// <param name="p">PortfolioDto</param>
        /// <returns>updated portfolio object, named editedPortfolio</returns>
        public async Task<bool> EditPortfolioAsync(Models.PortfolioDto p)
        {

            using (SqlCommand command = new SqlCommand($"UPDATE Portfolios SET name = @name, privacyLevel = @privacylevel WHERE portfolioID = @portfolioid", _conn))
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

        /// <summary>
        /// Retrieves an investment by its associated PortfolioID.
        /// </summary>
        /// <param name="investmentDto"></param>
        /// <returns></returns>
        public async Task<Investment?> GetInvestmentByPortfolioIDAsync(Models.GetInvestmentDto investmentDto)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Investments WHERE fk_portfolioID = @portfolioid AND symbol=@symbol", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", investmentDto.PortfolioId);
                command.Parameters.AddWithValue("@symbol", investmentDto.Symbol);
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
        
        /// <summary>
        /// Adds user's purchase as a buy in the database.
        /// </summary>
        /// <param name="buy">BuyDto</param>
        /// <returns>Newly created Buy object</returns>        
        public async Task<bool> AddNewBuyAsync(Guid? PortfolioId, string? Symbol, decimal? CurrentPrice, decimal? AmountBought, decimal? PriceBought)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Buys (fk_portfolioID, symbol, currentPrice, amountBought, priceBought) VALUES (@portfolioid, @symbol, @currentprice, @amountbought, @pricebought)", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", PortfolioId);
                command.Parameters.AddWithValue("@symbol", Symbol);
                command.Parameters.AddWithValue("@currentprice", CurrentPrice);
                command.Parameters.AddWithValue("@amountbought", AmountBought);
                command.Parameters.AddWithValue("@pricebought", PriceBought);
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
        
        /// <summary>
        /// Returns all of user's buys for a particular Stock option (by symbol).
        /// Sendes really likes underscores.
        /// </summary>
        /// <param name="buysDto">Get_BuysDto</param>
        /// <returns>A list of Buy objects, named buyList.</returns>
        public async Task<List<Buy?>> GetAllBuyBySymbolAsync(Models.Get_BuysDto AllBuys)
        {
            List<Buy?> buyList = new List<Buy?>();
            using (SqlCommand command = new SqlCommand("Select * from Buys where symbol = @symbol and portfolioID = @portfolioid ORDER BY dateBought DESC", _conn))
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


        public async Task<bool> AddNewSellAsync(Guid? PortfolioId, string? Symbol, decimal? amountSold, decimal? priceSold)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Sells (fk_portfolioID, symbol, amountSold, priceSold) VALUES (@portfolioid, @symbol, @amountSold, @priceSold)", _conn))
            {
                command.Parameters.AddWithValue("@portfolioid", PortfolioId);
                command.Parameters.AddWithValue("@symbol", Symbol);
                command.Parameters.AddWithValue("@amountSold", amountSold);
                command.Parameters.AddWithValue("@priceSold", priceSold);

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

        /// <summary>
        /// Returns all of user's sells for a particular Stock option (by symbol).
        /// </summary>
        /// <param name="sellsDto">GetSellsDto</param>
        /// <returns>A list of sell objects, named sellList.</returns>
        public async Task<List<Sell?>> GetAllSellBySymbolAsync(Models.GetSellsDto sellsDto)
        {
            List<Sell?> SellList = new List<Sell?>();
            using (SqlCommand command = new SqlCommand("Select * from Sells where symbol = @symbol and portfolioID = @portfolioid ORDER BY dateSold DESC", _conn))
            {
                command.Parameters.AddWithValue("@symbol", sellsDto.Symbol);
                command.Parameters.AddWithValue("@portfolioid", sellsDto.PortfolioId);
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

        /// <summary>
        /// Retrieves (potentially) a list of Investment objects from the database by time.
        /// </summary>
        /// <param name="investmentByTime">GetInvestmentByTimeDto</param>
        /// <returns>a list of Investment objects named returnedInvestment</returns>
        public async Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
        {
            List<Investment?> investmentList = new List<Investment?>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Investments WHERE fk_portfolioID = @portfolioid AND symbol=@symbol AND dateCreated BETWEEN @startTime AND @endTime ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@startTime", investmentByTime.StartTime);
                command.Parameters.AddWithValue("@endTime", investmentByTime.EndTime);
                command.Parameters.AddWithValue("@symbol", investmentByTime.Symbol);
                command.Parameters.AddWithValue("@portfolioid", investmentByTime.PortfolioId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Investment i = new Investment(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetDecimal(9), ret.GetDateTime(10), ret.GetDateTime(11));
                    investmentList.Add(i);

                }

                _conn.Close();
                return investmentList;
            }
        }

        public async Task<int> GetNumberOfUsersAsync()
        {
            string stmt = "SELECT COUNT(userID) FROM Users";
            int count = 0;
           
                using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
                {
                    _conn.Open();
                    count = (int)cmdCount.ExecuteScalar();
                    _conn.Close();
                }
            
            return count;

        }

        public async Task<int> GetNumberOfPostsAsync()
        {
            string stmt = "SELECT COUNT(postID) FROM Posts";
            int count = 0;

            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int)cmdCount.ExecuteScalar();
                _conn.Close();
            }

            return count;

        }

        public async Task<int> GetNumberOfBuysAsync()
        {
            string stmt = "SELECT COUNT(buyID) FROM Buys";
            int count = 0;
            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int)cmdCount.ExecuteScalar();
                _conn.Close();
            }

            return count;

        }

        public async Task<int> GetNumberOfSellsAsync()
        {
            
            string stmt = "SELECT COUNT(sellID) FROM Sells";
            int count = 0;
            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int)cmdCount.ExecuteScalar();
                _conn.Close();
            }

            return count;

        }

        public async Task<bool> CreatePostAsync(string auth0Id, CreatePostDto post)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Posts (fk_userID, content, privacyLevel) VALUES (@auth0Id, @content, @privacylevel)", _conn))
            {
                command.Parameters.AddWithValue("@auth0Id", auth0Id);
                command.Parameters.AddWithValue("@content", post.Content);
                command.Parameters.AddWithValue("@privacylevel", post.PrivacyLevel);
                
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

        public async Task<Post?> GetRecentPostByUserId(string auth0Id)
        {
            using (SqlCommand command = new SqlCommand($"Select TOP (1) * FROM Posts WHERE fk_userID = @userId ORDER BY dateCreated DESC", _conn))
            {
                command.Parameters.AddWithValue("@userId", auth0Id);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                Post? post = null;
                if (ret.Read())
                {
                    post = new Post(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));

                }

                _conn.Close();
                return post;
            }
        }
        public async Task<Portfolio?> GetRecentPortfoliosByUserIDAsync(string auth0Id)
        {
            using (SqlCommand command = new SqlCommand($"Select TOP (1) * FROM Portfolios WHERE fk_userID = @userId ORDER BY dateCreated DESC", _conn))
            {
                command.Parameters.AddWithValue("@userId", auth0Id);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                Portfolio? portfolio = null;
                if (ret.Read())
                {
                    portfolio = new Portfolio(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetInt32(9), ret.GetDecimal(10), ret.GetDateTime(11), ret.GetDateTime(12));

                }

                _conn.Close();
                return portfolio;
            }
        }

        public async Task<List<Post>> GetAllPostAsync()
        {
            List<Post> postList = new List<Post>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Posts ORDER BY dateModified DESC", _conn))
            {
                
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Post p = new Post(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));
                    postList.Add(p);

                }

                _conn.Close();
                return postList;
            }
        }

        /// <summary>
        /// Retrieves all investments by the Portfolio's ID number.
        /// </summary>
        /// <param name="investmentDto">GetAllInvestmentsDto</param>
        /// <returns>A list of Investment objects populated with data from investmentDto named investment.</returns>
        public async Task<List<Investment?>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID)
        {
            List<Investment?> invList = new List<Investment?>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Investments WHERE fk_portfolioID = @portfolioID", _conn))
            {
                command.Parameters.AddWithValue("@portfolioID", portfolioID);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Investment i = new Investment(
                        ret.GetGuid(0), 
                        ret.GetGuid(1), 
                        ret.GetString(2), 
                        ret.GetDecimal(3),
                        ret.GetDecimal(4),
                        ret.GetDecimal(5),
                        ret.GetDecimal(6),
                        ret.GetDecimal(7),
                        ret.GetDecimal(8),
                        ret.GetDecimal(9),
                        ret.GetDateTime(10),
                        ret.GetDateTime(11)
                    );
                    
                    invList.Add(i);
                }

                _conn.Close();
                return invList;
            }
        }

        public async Task<int> GetNumberOfCommentsByPostIdAsync(Guid? PostId)
        {
            //string stmt = "SELECT COUNT(fk_postID) FROM Comments";
            int count = 0;
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(commentID) FROM Comments WHERE fk_postID=@postId", _conn))
            {
                cmdCount.Parameters.AddWithValue("@postId", PostId);
                _conn.Open();
                count = (int)cmdCount.ExecuteScalar();
                _conn.Close();
            }

            return count;

        }

        public async Task<string?> GetUserWithPostIdAsync(Guid? postId)
        {
            string? postUser = "";
            using (SqlCommand command = new SqlCommand($"SELECT fk_userID FROM Posts WHERE postID=@postId", _conn))
            {
                command.Parameters.AddWithValue("@postId", postId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if (ret.Read())
                {
                    postUser = ret.GetString(0);

                }

                _conn.Close();
                return postUser;
            }
        }

        public async Task<bool> UpdatePostAsync(EditPostDto editPostDto)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Posts SET content=@Content, privacyLevel=@privacylevel WHERE postID=@PostId", _conn))
            {
                command.Parameters.AddWithValue("@PostId", editPostDto.PostId);
                command.Parameters.AddWithValue("@Content", editPostDto.Content);
                command.Parameters.AddWithValue("@privacylevel", editPostDto.PrivacyLevel);
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

        public async Task<Post?> GetPostByPostId(Guid? PostId)
        {
            Post? p = null;  
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Posts WHERE postID=@PostId ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@PostId", PostId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    p = new Post(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));

                }

                _conn.Close();
                return p;
            }
        }

        public async Task<Buy?> GetRecentBuyByPortfolioId(Guid? portfolioId)
        {
            using (SqlCommand command = new SqlCommand($"Select TOP (1) * FROM Buys WHERE fk_portfolioID = @portfolioId ORDER BY dateBought DESC", _conn))
            {
                command.Parameters.AddWithValue("@portfolioId", portfolioId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                Buy? recentBuy = null;
                if (ret.Read())
                {
                    recentBuy = new Buy(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDateTime(6));

                }

                _conn.Close();
                return recentBuy;
            }
        }

        public async Task<bool> DeletePostAsync(Guid? postId)
        {
            using (SqlCommand command = new SqlCommand($"DELETE TOP (1) FROM Posts WHERE postID=@PostId", _conn))
            {
                command.Parameters.AddWithValue("@PostId", postId);
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

        public async Task<Sell?> GetRecentSellByPortfolioId(Guid? fk_PortfolioID)
        {
            using (SqlCommand command = new SqlCommand($"Select TOP (1) * FROM Sells WHERE fk_portfolioID = @portfolioId ORDER BY dateSold DESC", _conn))
            {
                command.Parameters.AddWithValue("@portfolioId", fk_PortfolioID);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                Sell? recentSell = null;
                if (ret.Read())
                {
                    recentSell = new Sell(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDateTime(5));

                }

                _conn.Close();
                return recentSell;
            }
        }


        public async Task<List<Post>> GetAllPostByUserIdAsync(string userId)
        {
            List<Post> postList = new List<Post>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Posts WHERE fk_userID=@userId ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@userId", userId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Post p = new Post(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));
                    postList.Add(p);

                }

                _conn.Close();
                return postList;
            }
        }

        public async Task<Post?> GetPostByPostIdAsync(Guid? postId)
        {
            Post? post = null;
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Posts WHERE postID=@postId ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@postId", postId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    post = new Post(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));

                }

                _conn.Close();
                return post;
            }
        }


        public async Task<bool> CreateLikeOnPostAsync(LikeDto like, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO LikesPosts (fk_postID, fk_userID) VALUES (@PostId, @UserId)", _conn))
            {
                command.Parameters.AddWithValue("@PostId", like.PostId);
                command.Parameters.AddWithValue("@UserId", auth0UserId);

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

        public async Task<bool> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"DELETE TOP (1) FROM LikesPosts WHERE fk_postID=@PostId AND fk_userId=@UserId", _conn))
            {
                command.Parameters.AddWithValue("@PostId", unlike.PostId);
                command.Parameters.AddWithValue("@UserId", auth0UserId);

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
    }
}