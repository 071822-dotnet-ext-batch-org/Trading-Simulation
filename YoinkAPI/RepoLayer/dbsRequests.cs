using System;
using Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;


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


        //--------------------------Profile Section-----------------------

        /// <summary>
        /// This creates a new profile for a new user.
        /// Takes nullable ProfileDto (name, email, picture, privacyLevel)
        /// Requires logged in user via Auth0.  
        /// <param name="userID"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Picture"></param>
        /// <param name="Privacy"></param>
        /// <returns>true/false</returns>
        public async Task<bool> CreateProfileAsync(string? userID, string? Name, string? Email, string? Picture, int? Privacy)
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
        }//End of Create Profile Async


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
                    Profile p = new Profile(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5));
                    return p;
                }
                _conn.Close();
                return null;
            }
        }

        /// <summary>
        /// Allows user to edit their profile - Needs userID, Name, Email, Picture, Privacy
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        /// <param name="Picture"></param>
        /// <param name="Privacy"></param>
        /// <returns>true/false</returns>
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

        }//End of Edit Profile Async



        //------------------------------Portfolio Section------------------------

        /// <summary>
        /// Retrieves ALL portfolios from the database which match the User's ID.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>Returns a List of Portfolios</returns>
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
                    Portfolio p = new Portfolio(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetInt32(9), ret.GetDecimal(10), ret.GetDateTime(11), ret.GetDateTime(12));
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

                if (ret.Read())
                {
                    Portfolio p = new Portfolio(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetInt32(3), ret.GetInt32(4), ret.GetDecimal(5), ret.GetDecimal(6), ret.GetDecimal(7), ret.GetDecimal(8), ret.GetInt32(9), ret.GetDecimal(10), ret.GetDateTime(11), ret.GetDateTime(12));
                    _conn.Close();
                    return p;

                }
                _conn.Close();
                return null;
            }
        }//End of Get Portfolio by Portfolio ID

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
        }//End of Create Portfolio

        /// <summary>
        /// Allows user to get all of their portfolios - Needs auth0userID
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <returns>Returns a Portfolio</returns>
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
        }//End of Get Recent Portfolio by User ID


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
        }//End of Edit Portfolio







        //--------------------------------Buy and Sell Section----------------------------

        /// <summary>
        /// Adds user's purchase as a buy in the database
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="CurrentPrice"></param>
        /// <param name="AmountBought"></param>
        /// <param name="PriceBought"></param>
        /// <returns>true or false</returns>           
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
        }//End of Add new Buy Order

        /// <summary>
        /// Returns all of user's buys for a particular Stock option (by symbol).
        /// Sendes really likes underscores.
        /// </summary>
        /// <param name="AllBuys"></param>
        /// <returns>Returns a list of buy orders</returns>
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
        }//End of Get all Buys by Symbol

        /// <summary>
        /// Allows a user to create a Buy Order
        /// </summary>
        /// <param name="PortfolioId"></param>
        /// <param name="Symbol"></param>
        /// <param name="amountSold"></param>
        /// <param name="priceSold"></param>
        /// <returns> A new Buy Order</returns>
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


        }//End of Add new Sell order

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
        }//End of Get All Sells by Symbol

        /// <summary>
        /// Allows user to get their most recent buy in the portfolio - Needs portfolioID
        /// </summary>
        /// <param name="portfolioId"></param>
        /// <returns>The most recent Buy Order</returns>
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
        }//End of Get Recent Buy by Portfolio ID


        /// <summary>
        /// Allows user to get their most recent buy in the portfolio - Needs portfolioID
        /// </summary>
        /// <param name="fk_PortfolioID"></param>
        /// <returns>The most recent Sell Order</returns>
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
        }//End of Get recent Sells by Portfolio



        public async Task<bool> UpdateCurrentPriceAsync(Models.GetInvestmentDto investmentDto, decimal currentPrice)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Investments SET currentPrice = @currentPrice Where fk_PortfolioID = @portfolioId AND symbol = @symbol", _conn))
            {
                command.Parameters.AddWithValue("@portfolioId", investmentDto.PortfolioId);
                command.Parameters.AddWithValue("@symbol", investmentDto.Symbol);
                command.Parameters.AddWithValue("@currentPrice", currentPrice);
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



        //--------------------------------Investment Section-----------------------------

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
        }//End of Get Investment by Portfolio ID

        /// <summary>
        /// Retrieves (potentially) a list of Investment objects from the database by time.
        /// </summary>
        /// <param name="investmentByTime">GetInvestmentByTimeDto</param>
        /// <returns>a list of Investment objects named returnedInvestment</returns>
        public async Task<List<Investment>?> GetInvestmentByTimeAsync(GetInvestmentByTimeDto investmentByTime)
        {
            List<Investment> investmentList = new List<Investment>();
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
        }//End of Get Investment by Time




        //--------------------------------HomePage Section-----------------------

        /// <summary>
        /// Allows user to Get number of total users
        /// </summary>
        /// <returns>int number</returns>
        public async Task<int?> GetNumberOfUsersAsync()
        {
            string stmt = "SELECT COUNT(userID) FROM Users";
            int? count = 0;

            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;

        }//End of Get number of total Users

        /// <summary>
        /// Allows user to get total number of Posts
        /// </summary>
        /// <returns>int number</returns>
        public async Task<int?> GetNumberOfPostsAsync()
        {
            string stmt = "SELECT COUNT(postID) FROM Posts";
            int? count = 0;

            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;

        }//End of Get number of total posts

        /// <summary>
        /// Allows user to get total number of Buy Orders
        /// </summary>
        /// <returns>int number</returns>
        public async Task<int?> GetNumberOfBuysAsync()
        {
            string stmt = "SELECT COUNT(buyID) FROM Buys";
            int? count = 0;
            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;

        }//End of Get number of total Buy Orders

        /// <summary>
        /// Allows user to get total number of Sell Orders
        /// </summary>
        /// <returns>int number</returns>
        public async Task<int?> GetNumberOfSellsAsync()
        {

            string stmt = "SELECT COUNT(sellID) FROM Sells";
            int? count = 0;
            using (SqlCommand cmdCount = new SqlCommand(stmt, _conn))
            {
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;

        }//End of Get number of Sell Orders






        //-----------------------------Posts Section----------------------------

        /// <summary>
        /// Allows user to create a Post - Needs auth0userID, and a Post
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <param name="post"></param>
        /// <returns>true/false</returns>
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
        }//End of Create Post

        /// <summary>
        /// Allows user to get 1 recent post by userID - Needs auth0userID
        /// </summary>
        /// <param name="auth0Id"></param>
        /// <returns>Returns a Post</returns>
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
        }//End of Get of Recent Post by User ID


        /// <summary>
        /// Allows user to get all of Posts
        /// </summary>
        /// <returns>List of Posts</returns>
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
        }//End of Get all Posts

        /// <summary>
        /// Retrieves all investments by the Portfolio's ID number.
        /// </summary>
        /// <param name="investmentDto">GetAllInvestmentsDto</param>
        /// <returns>A list of Investment objects populated with data from investmentDto named investment.</returns>
        public async Task<List<Investment>> GetAllInvestmentsByPortfolioIDAsync(Guid? portfolioID)
        {
            List<Investment> invList = new List<Investment>();
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
        }//End of Get all investment by Portfolio ID

        /// <summary>
        /// Allows user to get the number of total post comments in a post - Needs postID
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns>int as the number of comments</returns>
        public async Task<int?> GetNumberOfCommentsByPostIdAsync(Guid? PostId)
        {
            //string stmt = "SELECT COUNT(fk_postID) FROM Comments";
            int? count = 0;
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(commentID) FROM Comments WHERE fk_postID=@postId", _conn))
            {
                cmdCount.Parameters.AddWithValue("@postId", PostId);
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;

        }//End of Get number of comments of Post

        /// <summary>
        /// Retrieves the userID of the post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>string as userID</returns>
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
        }//End of Get user with Post ID

        /// <summary>
        /// Allows user to update a post - Needs Edit Post Dto
        /// </summary>
        /// <param name="editPostDto"></param>
        /// <returns>true/false</returns>
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
        }//End of Update a Post

        /// <summary>
        /// Allows user to get a nullable post by postID - Needs postID
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns>Post?</returns>
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
        }//End of Get Post by Post ID


        /// <summary>
        /// Allows user to delete a post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>true/false</returns>
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
        }//End of Delete Post


        /// <summary>
        /// Allows user to get all of their posts - Needs auth0userID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of Posts</returns>
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
        }//End of Get all posts by User ID

        /// <summary>
        /// Allows user to get the number of total post comments in a post - Needs postID
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Post</returns>
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
        }//End of Get Post by Post ID

        /// <summary>
        /// Allows user to add a like to a post - Needs an auth0userID and a likeDto
        /// </summary>
        /// <param name="like"></param>
        /// <param name="auth0UserId"></param>
        /// <returns>true/false</returns>
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
        }//End of Add a Like to Post

        /// <summary>
        /// Allows user to remove their like from a post - Needs an auth0userID and a likeDto
        /// </summary>
        /// <param name="unlike"></param>
        /// <param name="auth0UserId"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DeleteLikeOnPostAsync(LikeDto unlike, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"DELETE TOP (1) FROM LikesPosts WHERE fk_postID=@PostId AND fk_userID=@UserId", _conn))
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
        }//End of Remove like from a Post

        /// <summary>
        /// Checks if a specific user already has a like on a post - Needs an auth0userID, and a post ID
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <param name="fk_postID"></param>
        /// <returns>true/false</returns>
        public async Task<bool> CheckIfUserAlreadyHasLike_OnPost(string? auth0UserId, Guid postID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP (1) * FROM LikesPosts WHERE fk_postID = @fk_postID AND fk_userID = @fk_userID", _conn))
            {
                command.Parameters.AddWithValue("@fk_userID", auth0UserId);
                command.Parameters.AddWithValue("@fk_postID", postID);
                

                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    //A like is already made by this user to this post
                    _conn.Close();
                    return true;
                }
                // This user does not have a like on this post
                _conn.Close();
                return false;
            }   
        }//End of the Check if User has like on a post

        /// <summary>
        /// Checks if a specific user already has a like on a comment - Needs an auth0userID, and a comment ID
        /// </summary>
        /// <param name="auth0UserId"></param>
        /// <param name="fk_postID"></param>
        /// <returns>true/false</returns>
        public async Task<bool> CheckIfUserAlreadyHasLike_OnComment(string? auth0UserId, Guid commentID)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP (1) * FROM LikesComments WHERE fk_userID = @UserId AND fk_commentID = @fk_commentID", _conn))
            {
                command.Parameters.AddWithValue("@UserId", auth0UserId);
                command.Parameters.AddWithValue("@fk_commentID", commentID);
                

                _conn.Open();

                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    //A like is already made by this user to this post
                    _conn.Close();
                    return true;
                }
                // This user does not have a like on this post
                _conn.Close();
                return false;
            }   
        }//End of the Check if User has a like on a comment

        /// <summary>
        /// Allows user to update the current prices of their ivestment by symbol - Needs Sybmol, Update Price, and Portfolio ID
        /// </summary>
        /// <param name="Symbol"></param>
        /// <param name="UpdatePrice"></param>
        /// <param name="portfolioID"></param>
        /// <returns>true/false</returns>
        public async Task<bool> UpdateSymbol_CurrentPrice_ofBuy(string? Symbol, decimal? UpdatePrice, Guid portfolioID)
        {
            using (SqlCommand command = new SqlCommand($"Update Investments SET currentPrice = @UpdatePrice Where fk_portfolioID = @fk_portfolioID AND symbol = @symbol", _conn))
            {
                command.Parameters.AddWithValue("@UpdatePrice", UpdatePrice);
                command.Parameters.AddWithValue("@fk_portfolioID", portfolioID);
                command.Parameters.AddWithValue("@symbol", Symbol);
                

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
        }//End of Update Symbol's Current Price of Buy

        /// <summary>
        /// Edit a comment's content.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="comment">EditCommentDto</param>
        /// <returns>True if edited, false if not edited.</returns>
        public async Task<bool> EditCommentAsync(EditCommentDto comment)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Comments SET content=@content WHERE commentID=@commentId", _conn))
            {
                command.Parameters.AddWithValue("@commentId", comment.CommentId);
                command.Parameters.AddWithValue("@content", comment.Content);
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
        }//End of Edit Comment

        /// <summary>
        /// Get a comment searching with the commentId.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="commentId">Guid commentId</param>
        /// <returns>Comment object of the updated comment.</returns>
        public async Task<Comment?> GetCommentByCommentIdAsync(Guid? commentId)
        {
            Comment? comment = null;
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Comments WHERE commentID=@commentId ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@commentId", commentId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if (ret.Read())
                {
                    comment = new Comment(ret.GetGuid(0), ret.GetString(1), ret.GetGuid(2), ret.GetString(3), ret.GetInt32(4), ret.GetDateTime(5), ret.GetDateTime(6));

                }

                _conn.Close();
                return comment;
            }
        }//End of Get Comment by Comment ID

        /// <summary>
        /// Gets a userId that is associated with a specific comment.
        /// </summary>
        /// <param name="commentId">Id of comment</param>
        /// <returns>UserId string.</returns>
        public async Task<string?> GetUserWithCommentIdAsync(Guid commentId)
        {
            string? User = "";
            using (SqlCommand command = new SqlCommand($"SELECT fk_userID FROM Comments WHERE commentID=@commentId", _conn))
            {
                command.Parameters.AddWithValue("@commentId", commentId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                if (ret.Read())
                {
                    User = ret.GetString(0);

                }

                _conn.Close();
                return User;
            }
        }//End of Get User with Comment ID

        /// <summary>
        /// Delete a comment and ensures user can delete only their own comment.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="commentId">Id of comment to be deleted</param>
        /// <returns>True if deleted, false if not.</returns>
        public async Task<bool> DeleteCommentAsync(Guid commentId)
        {
            using (SqlCommand command = new SqlCommand($"DELETE TOP (1) FROM Comments WHERE commentID=@commentId", _conn))
            {
                command.Parameters.AddWithValue("@commentId", commentId);

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
        }//End of Delete Comment


        /// <summary>
        /// Create a comment on a specific post.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="comment">CommentDto</param>
        /// <returns>True if created, false if not.</returns>
        public async Task<bool> CreateCommentOnPostAsync(CommentDto comment, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Comments (fk_userID, fk_postID, content) VALUES (@auth0Id, @postId, @content)", _conn))
            {
                command.Parameters.AddWithValue("@auth0Id", auth0UserId);
                command.Parameters.AddWithValue("@content", comment.Content);
                command.Parameters.AddWithValue("@postId", comment.PostId);

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
        }//End of Create a Comment on Post



        /// <summary>
        /// Get a lits of comment on a specific post.
        /// Requires logged in user via Auth0.
        /// </summary>
        /// <param name="postId">postId</param>
        /// <returns>A list of comments.</returns>
        public async Task<List<Comment>> GetCommentsByPostIdAsync(Guid postId)
        {
            List<Comment> commList = new List<Comment>();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Comments WHERE fk_postID = @postId ORDER BY dateModified DESC", _conn))
            {
                command.Parameters.AddWithValue("@postId", postId);
                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Comment c = new Comment(
                        ret.GetGuid(0),
                        ret.GetString(1),
                        ret.GetGuid(2),
                        ret.GetString(3),
                        ret.GetInt32(4),
                        ret.GetDateTime(5),
                        ret.GetDateTime(6));

                    commList.Add(c);
                }

                _conn.Close();
                return commList;
            }
        }


        public async Task<bool> CreateLikeForCommentAsync(LikeForCommentDto createLikeForCommentDto, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO LikesComments (fk_commentID, fk_userID) VALUES (@commentId, @auth0Id) Select TOP (1) * FROM LikesComments WHERE fk_userID = @auth0Id ORDER BY dateCreated DESC", _conn))
            {
                command.Parameters.AddWithValue("@commentId", createLikeForCommentDto.CommentId);
                command.Parameters.AddWithValue("@auth0Id", auth0UserId);

                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                _conn.Close();

                
                return (ret > 0);
            }
        }



        public async Task<bool> DeleteLikeForCommentAsync(LikeForCommentDto deleteLikeForCommentDto, string? auth0UserId)
        {
            using (SqlCommand command = new SqlCommand($"DELETE TOP (1) FROM LikesComments WHERE likesCommentsID = @likecommentId AND fk_userID = @userId", _conn))
            {
                command.Parameters.AddWithValue("@likecommentId", deleteLikeForCommentDto.CommentId);
                command.Parameters.AddWithValue("@userId", auth0UserId);

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


        public async Task<int?> GetCountofCommentsByPostIdAsync(Guid? postId)
        {
            int? count = 0;
            using (SqlCommand cmdCount = new SqlCommand("SELECT COUNT(commentID) FROM Comments WHERE fk_postID=@postId", _conn))
            {
                cmdCount.Parameters.AddWithValue("@postId", postId);
                _conn.Open();
                count = (int?)(await cmdCount.ExecuteScalarAsync());
                _conn.Close();
            }

            return count;
        }



        public async Task<bool> UpdateBuysCurrentPriceAsync(UpdatePriceDto u)
        {
            string sql = @"
                UPDATE Buys
                SET currentPrice = @currentPrice
                WHERE symbol = @symbol
            ";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@currentPrice", u.Price);
                command.Parameters.AddWithValue("@symbol", u.Symbol);

                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                _conn.Close();

                return (ret > 0);
            }
        }

        public async Task<List<Buy>> GetAllBuyBySymbolNoPortfolioAsync(string symbol)
        {
            List<Buy> buys = new List<Buy>();

            string sql = @"
                SELECT *
                FROM Buys
                WHERE symbol = @symbol
            ";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@symbol", symbol);

                _conn.Open();
                
                SqlDataReader ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    Buy b = new Buy(ret.GetGuid(0), ret.GetGuid(1), ret.GetString(2), ret.GetDecimal(3), ret.GetDecimal(4), ret.GetDecimal(5), ret.GetDateTime(6));
                    buys.Add(b);
                }

                _conn.Close();
                return buys;
            }
        }

        public async Task<bool> UpdateInvestmentAsync(Investment i)
        {
            string sql = @"
                UPDATE Investments
                SET currentPrice = @currentPrice,
                    pnl = @pnl
                WHERE investmentID = @investmentID
            ";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@currentPrice", i.CurrentPrice);
                command.Parameters.AddWithValue("@pnl", i.TotalPNL);
                command.Parameters.AddWithValue("@investmentID", i.InvestmentID);
                
                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                _conn.Close();

                return (ret > 0);
            }
        }

        public async Task<bool> UpdateInvestmentsCurrentPriceAsync(UpdatePriceDto u)
        {
            string sql = @"
                UPDATE Investments
                SET currentPrice = @currentPrice,
                    pnl = (@currentPrice * currentAmount) - moneyInvested
                WHERE symbol = @symbol
            ";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@currentPrice", u.Price);
                command.Parameters.AddWithValue("@symbol", u.Symbol);
                
                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                _conn.Close();

                return (ret > 0);
            }
        }

        public async Task<bool> UpdatePortfoliosCurrentPriceAsync(List<Guid?> uniquePortfolioIDs)
        {
            string sql = @"
                UPDATE Portfolios
                SET currentInvestment = (SELECT SUM(currentAmount * currentPrice) FROM Investments WHERE fk_portfolioID = @portfolioID),
                    currentTotal = liquid + (SELECT SUM(currentAmount * currentPrice) FROM Investments WHERE fk_portfolioID = @portfolioID),
                    pnl = liquid + (SELECT SUM(currentAmount * currentPrice) FROM Investments WHERE fk_portfolioID = @portfolioID) - originalLiquid
                WHERE portfolioID = @portfolioID
            ";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                _conn.Open();
                foreach(Guid? pid in uniquePortfolioIDs)
                {
                    command.Parameters.Clear();
                    if (pid != null) 
                    {
                        command.Parameters.AddWithValue("@portfolioID", pid);
                        int ret = await command.ExecuteNonQueryAsync();

                        if (ret == 0) 
                        {
                            _conn.Close();
                            return false;
                        }
                    }
                }
                
                _conn.Close();
                return true;
            }
        }

        public async Task<bool> DeletePortfolioByPortfolioIDAsync(string auth0id, DeletePortfolioDto dp)
        {
            string sql = "DELETE FROM Portfolios WHERE portfolioID = @portfolioID AND fk_userID = @auth0id";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@portfolioID", dp.PortfolioID);
                command.Parameters.AddWithValue("@auth0id", auth0id);

                _conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                _conn.Close();

                return (ret > 0);
            }
        }

        public async Task<List<Guid>> GetPostLikesByUserID(string auth0id)
        {
            List<Guid> myLikes = new List<Guid>();
            string sql = $"SELECT fk_postID FROM LikesPosts WHERE fk_userID = @auth0id";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@auth0id", auth0id);

                _conn.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();

                while (ret.Read())
                {
                    myLikes.Add(ret.GetGuid(0));
                }

                _conn.Close();
                return myLikes;
            } 
        }
    }
}