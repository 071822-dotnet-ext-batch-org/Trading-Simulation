using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Test.Yoink
{
    public class Helpers
    {

        private Random random = new Random();


// ------Models--------------------

        public User fakeUser()
        {
            return new User(
                $"UserID{random.Next(100)}",
                random.Next(5),
                DateTime.Now,
                DateTime.Now
            );
        }

        public Profile fakeProfile()
        {
            return new Profile(
                Guid.NewGuid(),
                $"UserID{random.Next(100)}",
                $"Random Name {random.Next(100)}",
                $"random{random.Next(1000)}@email.com",
                $"https://placekitten.com/{random.Next(200)}/{random.Next(200)}",
                random.Next(10)
            );
        }

        public Portfolio fakePortfolio()
        {
            return new Portfolio(
                Guid.NewGuid(), 
                $"User{random.Next(100)}", 
                $"New Portfolio{random.Next(100)}",
                random.Next(5),
                random.Next(5),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(100),
                random.Next(10000),
                DateTime.Now,
                DateTime.Now
            );
        }

        public Investment fakeInvestment()
        {
            return new Investment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "AAPL",
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                DateTime.Now,
                DateTime.Now
            );
        }

        public Buy fakeBuy()
        {
            return new Buy(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "GOOG",
                random.Next(10000),
                random.Next(10000),
                random.Next(10000),
                DateTime.Now
            );
        }

        public Sell fakeSell()
        {
            return new Sell(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "NOK",
                random.Next(10000),
                random.Next(10000),
                DateTime.Now
            );
        }

        public Post fakePost()
        {
            return new Post(
                Guid.NewGuid(),
                $"User{random.Next(100)}", 
                $"Random content {random.Next(100)}",
                random.Next(10000),
                random.Next(5),
                DateTime.Now,
                DateTime.Now
            );
        }

        public LikePost fakeLikePost()
        {
            return new LikePost(
                Guid.NewGuid(),
                Guid.NewGuid(),
                $"User{random.Next(100)}", 
                DateTime.Now,
                DateTime.Now
            );
        }


        public Comment fakeComment()
        {
            return new Comment(
                Guid.NewGuid(),
                $"User{random.Next(100)}",
                Guid.NewGuid(),
                $"Random content {random.Next(100)}",
                random.Next(5),
                DateTime.Now,
                DateTime.Now
            );
        }


        public LikeComment fakeLikeComment()
        {
            return new LikeComment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                $"User{random.Next(100)}",
                DateTime.Now,
                DateTime.Now
            );
        }


//---------- DTOS-----------------------


        public PostWithCommentCountDto fakePostWithCommentCountDto()
        {
            return new PostWithCommentCountDto(
                Guid.NewGuid(),
                $"User{random.Next(100)}",
                $"Random content {random.Next(100)}",
                random.Next(1000),
                random.Next(1000),
                random.Next(5),
                DateTime.Now,
                DateTime.Now                
            );
        }


        public AllUpdatedRowsDto fakeAllUpdatedRowsDto()
        {
            List<Investment> IList = new List<Investment>();
            List<Portfolio?> PList = new List<Portfolio?>();
            List<Buy> BList = new List<Buy>();


            for(int i = 0; i < random.Next(10); i++)
            {
                IList.Add(fakeInvestment());
            }

            for(int i = 0; i < random.Next(10); i++)
            {
                PList.Add(fakePortfolio());
            }

            for(int i = 0; i < random.Next(10); i++)
            {
                BList.Add(fakeBuy());
            }

            return new AllUpdatedRowsDto(
                IList,
                PList,
                BList
            );
        }


        public PortfolioDto fakePortfolioDto()
        {
            return new PortfolioDto(
                Guid.NewGuid(),
                $"Random name {random.Next(100)}",
                random.Next(1000),
                random.Next(5)
            );
        }


        public ProfileDto fakeProfileDto()
        {
            return new ProfileDto(
                $"Random name {random.Next(100)}",
                $"random{random.Next(1000)}@email.com",
                $"https://placekitten.com/{random.Next(200)}/{random.Next(200)}",
                random.Next(1000)
            );
        }


        public BuyDto fakeBuyDto()
        {
            return new BuyDto(
                Guid.NewGuid(),
                "AMZN",
                random.Next(10000),
                random.Next(10000),
                random.Next(10000)
            );
        }



        public GetInvestmentByTimeDto fakeGetInvestmentByTimeDto()
        {
            return new GetInvestmentByTimeDto(
                DateTime.Now,
                DateTime.Now,
                Guid.NewGuid(),
                "TSLA"
            );
        }



        public SellDto fakeSellDto()
        {
            return new SellDto(
                Guid.NewGuid(),
                "DSNY",
                random.Next(10000),
                random.Next(10000)
            );
        }

        public List<Guid> fakeGuidList()
        {
            List<Guid> newGuids = new List<Guid>();
            Guid newGuid = Guid.NewGuid();
            Guid newGuid2 = Guid.NewGuid();
            Guid newGuid3 = Guid.NewGuid();

            newGuids.Add(newGuid);
            newGuids.Add(newGuid2);
            newGuids.Add(newGuid3);
            
            return newGuids;
        }

        public async Task<bool> TruncateTableAsync(SqlCommand command, SqlConnection conn)
        {
            using (command)
            {
                conn.Open();
                int ret = await command.ExecuteNonQueryAsync();
                if (ret > 0)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
                return false;
            }
        }

    }
}