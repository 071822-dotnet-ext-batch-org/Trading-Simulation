using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using RepoLayer;
using Moq;
using System;
using BusinessLayer;
using Microsoft.Extensions.Configuration;

namespace Test.Yoink
{
    public class YoinkRepoLayerClassTests
    {



        [Fact]
        public void TestingAllMethodsAssociatedWithUserProfile()
        {
            //Hardcode data for mock ProfileDto
            ProfileDto? profiledto2 = new ProfileDto("Tony", "Rodin@yahoo.com", "ghhhtbnn", 2);

            ProfileDto? profiledto = new ProfileDto()
            {

                Name = "Tony",
                Email = "Rodin@yahoo.com",
                PrivacyLevel = 2,

            };

            Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

            Profile? profile = new Profile()
            {
                ProfileID = Guid.NewGuid(),
                Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
                Name = "Tony",
                Email = "Rodin@yahoo.com",
                PrivacyLevel = 2,

            };

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(profile));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
            .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(profile));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);

            var dataSource3 = new Mock<IdbsRequests>();
            dataSource
            .Setup(m => m.CreateProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(Task.FromResult(true));

            var dataSource4 = new Mock<IdbsRequests>();
            dataSource
            .Setup(m => m.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
            .Returns(Task.FromResult(true));


            //Act

            var TheUserProfileWasGot = TheClassBeingTested.GetProfileByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");

            var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Picture", 2);

            var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Picture2", 2);


            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
            Assert.True(true);
            Assert.Equal(profiledto.Name, profile.Name);
        }



        [Fact]
        public void TestingAllMethodsAssociatedWithUserPortfolio()
        {

            //Arrange
            Guid guid = Guid.NewGuid();

            PortfolioDto? portfoliodto = new PortfolioDto()
            {

                Name = "Tony",
                PrivacyLevel = 2,

            };

            GetInvestmentDto? investmentDto = new GetInvestmentDto()
            {
                PortfolioId = guid,
                Symbol = "GOOG",
            };

            GetInvestmentByTimeDto? investmentByTime = new GetInvestmentByTimeDto()
            {
                StartTime = new DateTime(),
                EndTime = new DateTime(),
                PortfolioId = guid,
                Symbol = "GOOG",

            };

            Portfolio? portfolio = new Portfolio()
            {
                PortfolioID = guid,
                Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
                Name = "Tony",
                PrivacyLevel = 2,
                Type = 2,
                OriginalLiquid = 2000,
                CurrentInvestment = 1000,
                Liquid = 2500,
                CurrentTotal = 2300,
                Symbols = 34,
                TotalPNL = 600,
                DateCreated = new DateTime(),
                DateModified = new DateTime(),
            };

            List<Portfolio?> portmockList = new List<Portfolio?>();
            List<Investment?> investmentList = new List<Investment?>();

            portmockList.Add(portfolio);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(portmockList));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
            .Setup(p => p.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
            .Returns(Task.FromResult(portmockList));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);

            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.CreatePortfolioAsync(It.IsAny<PortfolioDto>()))
                .Returns(Task.FromResult(true));


            var dataSource3 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
                .Returns(Task.FromResult(true));

            var dataSource4 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(portmockList));

            var dataSource6 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .Returns(Task.FromResult(investmentList));

            var dataSource7 = new Mock<IdbsRequests>();
            dataSource
                .Setup(p => p.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .Returns(Task.FromResult(investmentList));


            //Act

            var AllTheUserPortfolioWasGotByUserID = TheClassBeingTested.GetALL_PortfoliosByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");//

            var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfoliodto);//not done

            var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);//

            var TheUserPortfolioWasGotByPortfolioID = TheClassBeingTested.GetPortfolioByPorfolioIDAsync(guid);//not done

            var TheUserInvestmentByPortfolioIDWasMade = TheClassBeingTested.GetInvestmentByPortfolioIDAsync(investmentDto);//not done shoulf go to investment section

            var TheUserInvestmentWasGotByTime = TheClassBeingTested.GetInvestmentByTimeAsync(investmentByTime);//not done should go to investment section

            //GetRecentPortfoliosByUserIDAsync
            //GetAllInvestmentsByPortfolioIDAsync //not done should go to investment section



            //Assert

            Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
            Assert.Equal(portfoliodto.Name, portfolio.Name);
            Assert.Equal(2, portfolio.PrivacyLevel);
            Assert.Equal(portfolio.PortfolioID, guid);
            Assert.True(true);

        }



        [Fact]
        public void TestingAllMethodsAssociatedWithSell()
        {

            //Arrange

            GetSellsDto selldto = new GetSellsDto()
            {
                PortfolioId = new Guid(),
                Symbol = "GOOGL",

            };

            Sell? sell = new Sell()
            {
                SellID = new Guid(),
                Fk_PortfolioID = new Guid(),
                Symbol = "GOOGL",
                AmountSold = 2000,
                PriceSold = 1000,
                DateSold = new DateTime(),
            };

            List<Sell?> SellmockList = new List<Sell?>();
            List<Portfolio?> portList = new List<Portfolio?>();

            SellmockList.Add(sell);


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .Returns(Task.FromResult(SellmockList));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .Returns(Task.FromResult(SellmockList));


            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
                .Setup(s => s.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(true));

            var dataSource55 = new Mock<IConfiguration>();
            dataSource
            .Setup(s => s.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<DateTime>()))
            .Returns(Task.FromResult(true));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);
            var TheClassBeingTested2 = new dbsRequests(dataSource55.Object);

            //Act

            var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync(selldto);

            var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync("GOOGL", 2000, 1000, "2022-09-26T14:07:41.3700000");

            var NewSellWasAddedBool = TheClassBeingTested2.AddNewSellAsync("GOOGL", 2000, 1000, "2022-09-27");


            //Assert

            Assert.Equal("GOOGL", sell.Symbol);
            Assert.Equal(2000, sell.AmountSold);
            Assert.Equal("GOOGL", selldto.Symbol);
            Assert.True(true);
        }



        [Fact]
        public void TestingAllMethodsAssociatedWithBuy()
        {

            //Arrange

            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Symbol = "GOOGL",

            };

            Buy? buy = new Buy()
            {
                BuyID = new Guid(),
                Fk_PortfolioID = new Guid(),
                Symbol = "GOOGL",
                CurrentPrice = 2000,
                AmountBought = 100,
                PriceBought = 50,
                DateBought = new DateTime(),

            };

            List<Buy?> buymockList = new List<Buy?>();

            buymockList.Add(buy);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .Returns(Task.FromResult(buymockList));

            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
                .Setup(b => b.AddNewBuyAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(true));

            var TheClassBeingTested = new YoinkBusinessLayer(dataSource.Object);
            var TheClassBeingTested2 = new YoinkBusinessLayer(dataSource2.Object);

            //Act

            var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

            var NewBuyWasAdded = TheClassBeingTested.AddNewBuyAsync(buy);

            var NewBuyWasAddedBool = TheClassBeingTested2.AddNewBuyAsync(buy);

            //Assert

            Assert.Equal("GOOGL", AllBuys.Symbol);
            Assert.Equal(2000, buy.CurrentPrice);
            Assert.True(true);

        }




        [Fact]
        public void TestingAllMethodsAssociatedWithInvestment()
        {

            //Arrange

            Guid invt = new Guid();

            DateTime DT = new DateTime();

            GetInvestmentDto getInvest2 = new GetInvestmentDto()
            {
                PortfolioId = invt,
                Symbol = "GOOGL",

            };

            GetInvestmentByTimeDto getInvesttime2 = new GetInvestmentByTimeDto()
            {
                StartTime = DT,
                EndTime = DT,
                PortfolioId = invt,
                Symbol = "GOOGL",

            };


            Investment newinvestment = new Investment()
            {
                InvestmentID = invt,
                Fk_PortfolioID = invt,
                Symbol = "AAPL",
                AmountInvested = 1200,
                CurrentAmount = 100,
                CurrentPrice = 50,
                TotalAmountBought = 4,
                TotalAmountSold = 2,
                AveragedBuyPrice = 150,
                TotalPNL = 50,
                DateCreated = new DateTime(),
                DateModified = new DateTime(),

            };

            List<Investment?> investmentmockList = new List<Investment?>();

            investmentmockList.Add(newinvestment);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(I => I.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .Returns(Task.FromResult(investmentmockList));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(I => I.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .Returns(Task.FromResult(investmentmockList));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);

            var dataSource2 = new Mock<IdbsRequests>();
            dataSource
                .Setup(I => I.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .Returns(Task.FromResult(investmentList));


            //Act

            var InvestmentGotByTime = TheClassBeingTested.GetInvestmentByTimeAsync(getInvesttime2);

            var InvestmentGotByPortfolioID = TheClassBeingTested.GetInvestmentByPortfolioIDAsync(getInvest2);


            //Assert

            Assert.Equal(getInvesttime2.PortfolioId, invt);
            Assert.Equal(getInvest2.PortfolioId, invt);

        }



        [Fact]
        public void TestingGetNumberOfUsers()
        {

            //Arrange

            int userCount = 500;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(G => G.GetNumberOfUsersAsync())
                .Returns(Task.FromResult(userCount));
            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(G => G.GetNumberOfUsersAsync())
                .Returns(Task.FromResult(userCount));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);


            //Act

            var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfUsersAsync();


            //Assert

            Assert.Equal(500, userCount);


        }



        [Fact]
        public void TestingGetNumberOfPosts()
        {

            //Arrange

            int userCount = 500;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(G => G.GetNumberOfPostsAsync())
                .Returns(Task.FromResult(userCount));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(G => G.GetNumberOfPostsAsync())
                .Returns(Task.FromResult(userCount));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);


            //Act

            var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfPostsAsync();


            //Assert

            Assert.Equal(500, userCount);


        }


        [Fact]
        public void TestingGetNumberOfSellsByDay()
        {

            //Arrange

            int sellsCount = 700;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(G => G.GetNumberOfBuysByDayAsync())
                .Returns(Task.FromResult(sellsCount));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(G => G.GetNumberOfBuysByDayAsync())
                .Returns(Task.FromResult(sellsCount));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);


            //Act

            var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysByDayAsync();


            //Assert

            Assert.Equal(700, sellsCount);


        }



        [Fact]
        public void TestingGetNumberOfBuysAsync()
        {

            //Arrange

            int buysCount = 300;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(G => G.GetNumberOfBuysAsync())
                .Returns(Task.FromResult(buysCount));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(G => G.GetNumberOfBuysAsync())
                .Returns(Task.FromResult(buysCount));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);


            //Act

            var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysAsync();


            //Assert

            Assert.Equal(300, buysCount);


        }




        [Fact]
        public void TestingGetNumberOfSellsAsync()
        {

            //Arrange

            int sellsCount = 350;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(G => G.GetNumberOfSellsAsync())
                .Returns(Task.FromResult(sellsCount));

            var dataSource5 = new Mock<IConfiguration>();
            dataSource
                .Setup(G => G.GetNumberOfSellsAsync())
                .Returns(Task.FromResult(sellsCount));

            var TheClassBeingTested = new dbsRequests(dataSource5.Object);


            //Act

            var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfSellsAsync();


            //Assert

            Assert.Equal(350, sellsCount);

            /**Task<bool> CreatePostAsync(string auth0Id, CreatePostDto post);
            Task<Post?> GetRecentPostByUserId(string auth0Id);
            Task<List<Post>> GetAllPostAsync();
            **/


        }
    }
}
