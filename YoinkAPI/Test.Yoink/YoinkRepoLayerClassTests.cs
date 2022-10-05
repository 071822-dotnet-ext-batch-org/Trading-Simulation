
using System.Threading.Tasks;
using Models;
using RepoLayer;
using Moq;
using System;
using BusinessLayer;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Test.Yoink
{
    public class YoinkRepoLayerClassTests
    {

        
        private Helpers helpers = new Helpers();

        // This method would test the CreateUserProfile 

        [Fact]
        public async Task TestingCreateUserProfileReturnsBool()
        {

            // Arrange
            bool expectedReturn = true;
            Profile profile = helpers.fakeProfile();

            var fakeConfig = new Mock<IConfiguration>();

            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns("Server=tcp:yoink.database.windows.net,1433;Initial Catalog=yoinkrepotesting;Persist Security Info=False;User ID=yoinkers;Password=Revature2022!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            string sql = "DELETE FROM Profiles WHERE fk_userID = @test1";

            SqlConnection conn = new SqlConnection(fakeConfig.Object["ConnectionStrings:DefaultConnection"]);

            bool? result = null;
            
            // Act

            using(SqlCommand command = new SqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@test1", "test1");

                bool truncated = await helpers.TruncateTableAsync(command, conn);

                if(truncated)
                {
                    result = await TheClassBeingTested.CreateProfileAsync("test1", profile.Name, profile.Email, profile.Picture, profile.PrivacyLevel);
                }
            }


            // Assert
            if(result != null)
            {
                Assert.Equal(expectedReturn, result);
                
            }
        }

        public async Task TestingGetProfileByUserIDReturnsProfile()
        {
            // Arrange

            Profile expectedReturn = helpers.fakeProfile();
            expectedReturn.Fk_UserID = "test1";

            var fakeConfig = new Mock<IConfiguration>();

            fakeConfig.SetupGet(fConf => fConf["ConnectionStrings:DefaultConnection"])
                .Returns("Server=tcp:yoink.database.windows.net,1433;Initial Catalog=yoinkrepotesting;Persist Security Info=False;User ID=yoinkers;Password=Revature2022!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");


            var TheClassBeingTested = new dbsRequests(fakeConfig.Object);

            // Act
            Profile? result = await TheClassBeingTested.GetProfileByUserIDAsync(expectedReturn.Fk_UserID);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReturn.ProfileID, result?.ProfileID);
        }

        
        // [Fact]
        // public void TestingCreateUserProfile()
        // {
        //     //Hardcode data for mock ProfileDto

        //     int ret = 1;

        //     ProfileDto? profiledto2 = new ProfileDto("Tony", "Rodin@yahoo.com", "ghhhtbnn", 2);

        //     ProfileDto? profiledto = new ProfileDto()
        //     {

        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };

        //     Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

        //     Profile? profile = new Profile()
        //     {
        //         ProfileID = Guid.NewGuid(),
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };


        //     // dataSource will decouple the tested method from the database and use the local data set above for the test
            
        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(m => m.CreateProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
        //         .Returns(Task.FromResult(false));


        //     var dataSource3 = new Mock<IConfiguration>();
        //     dataSource
        //     .Setup(m => m.CreateProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
        //     .Returns(Task.FromResult(true));


        //     var dataSource4 = new Mock<IDbCommand>();
        //     dataSource4
        //     .Setup(m => m.ExecuteNonQuery())
        //     .Returns(ret);

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource4
        //     .Setup(m => m.ExecuteNonQuery())
        //     .Returns(ret);


        //     //Inject the datasource into the class containing the methods to be tested

        //     var TheClassBeingTested = new dbsRequests(dataSource3.Object);
        //     var TheClassBeingTested2 = new dbsRequests(dataSource5.Object);

        //     //Call the methods to be tested
        //     //Act


        //     var TheUserProfileWasCreated = TheClassBeingTested.CreateProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Picture", 2);
        //     var TheUserProfileWasCreated2 = TheClassBeingTested2.CreateProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Picture", 2);


        //     //Assert

        //     Assert.True(true);
        //     Assert.True(ret > 0);
        // }





        // [Fact]
        // public void TestingGetProfileByUserID()
        // {
        //     //Hardcode data for mock ProfileDto

         

        //     ProfileDto? profiledto2 = new ProfileDto("Tony", "Rodin@yahoo.com", "ghhhtbnn", 2);

        //     ProfileDto? profiledto = new ProfileDto()
        //     {

        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };

        //     Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

        //     Profile? profile = new Profile()
        //     {
        //         ProfileID = Guid.NewGuid(),
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };

            

        //     // dataSource will decouple the tested method from the database and use the local data set above for the test

        //     if(profile == null){}

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //     .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
        //     .Returns(Task.FromResult(profile));


        //     var dataSource2 = new Mock<IConfiguration>();
        //     dataSource
        //     .Setup(m => m.GetProfileByUserIDAsync(It.IsAny<string>()))
        //     .Returns(Task.FromResult(profile));


        //     var dataSource8 = new Mock<IDataReader>();
        //     dataSource8
        //     .Setup(m => m.Read())
        //     .Returns(true);

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource8
        //     .Setup(m => m.Read())
        //     .Returns(true);


        //     //Inject the datasource into the class containing the methods to be tested

        //     var TheClassBeingTested = new dbsRequests(dataSource2.Object);
        //     var TheClassBeingTested2 = new dbsRequests(dataSource5.Object);

        //     //Call the methods to be tested
        //     //Act


        //     var TheUserProfileWasCreated = TheClassBeingTested.GetProfileByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");
        //     var TheUserProfileWasCreated2 = TheClassBeingTested2.GetProfileByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");


        //     //Assert

        //     Assert.True(true);
        //     if (profile != null)
        //     {
        //         Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
        //         Assert.Equal(profiledto.Name, profile.Name);
        //     }
        // }



        // [Fact]
        // public void TestingEditProfile()
        // {
        //     //Hardcode data for mock ProfileDto
        //     ProfileDto? profiledto2 = new ProfileDto("Tony", "Rodin@yahoo.com", "ghhhtbnn", 2);

        //     ProfileDto? profiledto = new ProfileDto()
        //     {

        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };

        //     Profile? profile2 = new Profile(Guid.NewGuid(), "d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Note", 2);

        //     Profile? profile = new Profile()
        //     {
        //         ProfileID = Guid.NewGuid(),
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         Email = "Rodin@yahoo.com",
        //         PrivacyLevel = 2,

        //     };

            

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //     .Setup(m => m.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
        //     .Returns(Task.FromResult(true));


        //     var dataSource2 = new Mock<IConfiguration>();
        //     dataSource
        //     .Setup(m => m.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
        //     .Returns(Task.FromResult(true));

        //     //Inject the datasource into the class containing the methods to be tested

        //     var TheClassBeingTested = new dbsRequests(dataSource2.Object);


        //     //Act


        //     var TheUserProfileWasedited = TheClassBeingTested.EditProfileAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", "Tony", "Rodin@yahoo.com", "Picture2", 2);


        //     //Assert
            
           
        //     Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", profile.Fk_UserID);
        //     Assert.Equal(profiledto.Name, profile.Name);
        //     Assert.True(true);
            
        // }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithUserPortfolio()
        // {

        //     //Arrange
        //     Guid guid = Guid.NewGuid();

        //     PortfolioDto? portfoliodto = new PortfolioDto()
        //     {

        //         Name = "Tony",
        //         PrivacyLevel = 2,

        //     };

        //     GetInvestmentDto? investmentDto = new GetInvestmentDto()
        //     {
        //         PortfolioId = guid,
        //         Symbol = "GOOG",
        //     };

        //     GetInvestmentByTimeDto? investmentByTime = new GetInvestmentByTimeDto()
        //     {
        //         StartTime = new DateTime(),
        //         EndTime = new DateTime(),
        //         PortfolioId = guid,
        //         Symbol = "GOOG",

        //     };

        //     Portfolio? portfolio = new Portfolio()
        //     {
        //         PortfolioID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Name = "Tony",
        //         PrivacyLevel = 2,
        //         Type = 2,
        //         OriginalLiquid = 2000,
        //         CurrentInvestment = 1000,
        //         Liquid = 2500,
        //         CurrentTotal = 2300,
        //         Symbols = 34,
        //         TotalPNL = 600,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Portfolio?> portmockList = new List<Portfolio?>();
        //     List<Investment?> investmentList = new List<Investment?>();

        //     portmockList.Add(portfolio);

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(portmockList));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //     .Setup(p => p.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
        //     .Returns(Task.FromResult(portmockList));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);

        //     var dataSource2 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.CreatePortfolioAsync(It.IsAny<string>(), It.IsAny<PortfolioDto>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource3 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource4 = new Mock<IConfiguration>();

        //     if(portfolio != null){}
        //     dataSource
        //         .Setup(p => p.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(portfolio));

        //     var dataSource6 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetRecentPortfoliosByUserIDAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(portfolio));




        //     //Act

        //     var AllTheUserPortfolioWasGotByUserID = TheClassBeingTested.GetALL_PortfoliosByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");

        //     var TheUserPortfolioWasCreated = TheClassBeingTested.CreatePortfolioAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfoliodto);

        //     var TheUserPortfolioWasedited = TheClassBeingTested.EditPortfolioAsync(portfoliodto);

        //     var TheUserPortfolioWasGotByPortfolioID = TheClassBeingTested.GetPortfolioByPorfolioIDAsync(guid);

        //     var TheRecentPortfolioWasGotByUserID = TheClassBeingTested.GetRecentPortfoliosByUserIDAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30");



        //     //Assert
        //     if(portfolio != null)
        //     {
        //         Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", portfolio.Fk_UserID);
        //         Assert.Equal(portfoliodto.Name, portfolio.Name);
        //         Assert.Equal(2, portfolio.PrivacyLevel);
        //         Assert.Equal(portfolio.PortfolioID, guid);
        //     }
        //     Assert.True(true);
        // }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithSell()
        // {

        //     //Arrange
        //     Guid guid = Guid.NewGuid();

        //     GetSellsDto selldto = new GetSellsDto()
        //     {
        //         PortfolioId = guid,
        //         Symbol = "GOOGL",

        //     };

        //     Sell? sell = new Sell()
        //     {
        //         SellID = guid,
        //         Fk_PortfolioID = guid,
        //         Symbol = "GOOGL",
        //         AmountSold = 2000,
        //         PriceSold = 1000,
        //         DateSold = new DateTime(),
        //     };

        //     List<Sell?> SellmockList = new List<Sell?>();
        //     List<Portfolio?> portList = new List<Portfolio?>();

        //     SellmockList.Add(sell);


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
        //         .Returns(Task.FromResult(SellmockList));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(s => s.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
        //         .Returns(Task.FromResult(SellmockList));


        //     var dataSource2 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(s => s.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource55 = new Mock<IConfiguration>();
        //     dataSource
        //     .Setup(s => s.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>()))
        //     .Returns(Task.FromResult(true));

        //     if(sell != null) {}
        //     var dataSource6 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(s => s.GetRecentSellByPortfolioId(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(sell));



        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);
        //     var TheClassBeingTested2 = new dbsRequests(dataSource55.Object);

        //     //Act

        //     var AllSellWasGotBySymbol = TheClassBeingTested.GetAllSellBySymbolAsync(selldto);

        //     var NewSellWasAdded = TheClassBeingTested.AddNewSellAsync(guid, "GOOGL", 2000, 1000);

        //     var NewSellWasAddedBool = TheClassBeingTested2.AddNewSellAsync(guid, "GOOGL", 2000, 1000);

        //     var GotRecentSellByPortfolioId = TheClassBeingTested.GetRecentSellByPortfolioId(guid);


        //     //Assert
        //     if (sell != null)
        //     {
        //         Assert.Equal("GOOGL", sell.Symbol);
        //         Assert.Equal(2000, sell.AmountSold);
        //         Assert.Equal(guid, sell.Fk_PortfolioID);
        //     }
        //     Assert.Equal("GOOGL", selldto.Symbol);
        //     Assert.True(true);
        // }



        // [Fact]
        // public void TestingAllMethodsAssociatedWithBuy()
        // {

        //     //Arrange
        //     Guid guid = Guid.NewGuid();

        //     Get_BuysDto AllBuys = new Get_BuysDto()
        //     {
        //         Symbol = "GOOGL",

        //     };

        //     Buy? buy = new Buy()
        //     {
        //         BuyID = new Guid(),
        //         Fk_PortfolioID = new Guid(),
        //         Symbol = "GOOGL",
        //         CurrentPrice = 2000,
        //         AmountBought = 100,
        //         PriceBought = 50,
        //         DateBought = new DateTime(),

        //     };

        //     BuyDto buyDTO = new BuyDto()
        //     {
        //         portfolioId = new Guid(),
        //         Symbol = "GOOGL",
        //         CurrentPrice = 2000,
        //         AmountBought = 100,
        //         PriceBought = 50,
        //     };

        //     List<Buy?> buymockList = new List<Buy?>();

        //     buymockList.Add(buy);

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
        //         .Returns(Task.FromResult(buymockList));

        //     var dataSource1 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(b => b.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
        //         .Returns(Task.FromResult(buymockList));

        //     var dataSource2 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(b => b.AddNewBuyAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<Decimal>(), It.IsAny<Decimal>(), It.IsAny<Decimal>()))
        //         .Returns(Task.FromResult(true));


        //     var dataSource3 = new Mock<IConfiguration>();
            
        //     if(buy == null) {}

        //     dataSource
        //         .Setup(b => b.GetRecentBuyByPortfolioId(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(buy));


        //     var TheClassBeingTested = new dbsRequests(dataSource1.Object);
        //     var TheClassBeingTested2 = new dbsRequests(dataSource2.Object);



        //     //Act

        //     var AllBuyWasGotBySymbol = TheClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

        //     var NewBuyWasAdded = TheClassBeingTested.AddNewBuyAsync(guid, "GOOGL", 2000, 100, 50);

        //     var NewBuyWasAddedBool = TheClassBeingTested2.AddNewBuyAsync(guid, "GOOGL", 2000, 100, 50);

        //     var GotRecentBuyByPortfolioId = TheClassBeingTested.GetRecentBuyByPortfolioId(guid);


        //     //Assert

        //     Assert.Equal("GOOGL", AllBuys.Symbol);
        //     if(buy != null)
        //     {
        //         Assert.Equal(2000, buy.CurrentPrice);
        //     }
        //     Assert.True(true);
        //     //Assert.Equal(guid, buy.Fk_PortfolioID);

        // }




        // [Fact]
        // public void TestingAllMethodsAssociatedWithInvestment()
        // {

        //     //Arrange

        //     Guid invt = new Guid();

        //     Guid guid = Guid.NewGuid();

        //     DateTime DT = new DateTime();

        //     GetInvestmentDto getInvest2 = new GetInvestmentDto()
        //     {
        //         PortfolioId = invt,
        //         Symbol = "GOOGL",

        //     };

        //     GetInvestmentByTimeDto getInvesttime2 = new GetInvestmentByTimeDto()
        //     {
        //         StartTime = DT,
        //         EndTime = DT,
        //         PortfolioId = invt,
        //         Symbol = "GOOGL",

        //     };


        //     Investment newinvestment = new Investment()
        //     {
        //         InvestmentID = invt,
        //         Fk_PortfolioID = invt,
        //         Symbol = "AAPL",
        //         AmountInvested = 1200,
        //         CurrentAmount = 100,
        //         CurrentPrice = 50,
        //         TotalAmountBought = 4,
        //         TotalAmountSold = 2,
        //         AveragedBuyPrice = 150,
        //         TotalPNL = 50,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),

        //     };

        //     List<Investment> investmentmockList = new List<Investment>();

        //     investmentmockList.Add(newinvestment);

        //     var dataSource = new Mock<IdbsRequests>();
        //     if(investmentmockList == null){}
        //     dataSource
        //         .Setup(I => I.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
        //         .Returns(Task.FromResult(investmentmockList));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(I => I.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
        //         .Returns(Task.FromResult(investmentmockList));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);

        //     if (newinvestment == null) {}

        //     var dataSource2 = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(I => I.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
        //         .Returns(Task.FromResult(newinvestment));

        //     if(investmentmockList != null) 
        //     {
        //         var dataSource3 = new Mock<IdbsRequests>();
        //         dataSource
        //             .Setup(I => I.GetAllInvestmentsByPortfolioIDAsync(It.IsAny<Guid>()))
        //             .Returns(Task.FromResult(investmentmockList));
        //     }




        //     //Act

        //     var InvestmentGotByTime = TheClassBeingTested.GetInvestmentByTimeAsync(getInvesttime2);

        //     var InvestmentGotByPortfolioID = TheClassBeingTested.GetInvestmentByPortfolioIDAsync(getInvest2);

        //     var AllInvestmentGotByPortfolioID = TheClassBeingTested.GetAllInvestmentsByPortfolioIDAsync(guid);




        //     //Assert

        //     Assert.Equal(getInvesttime2.PortfolioId, invt);
        //     Assert.Equal(getInvest2.PortfolioId, invt);

        // }



        // [Fact]
        // public void TestingGetNumberOfUsers()
        // {

        //     //Arrange

        //     int? userCount = 500;

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfUsersAsync())
        //         .Returns(Task.FromResult(userCount));
        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfUsersAsync())
        //         .Returns(Task.FromResult(userCount));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfUsersAsync();


        //     //Assert

        //     Assert.Equal(500, userCount);


        // }



        // [Fact]
        // public void TestingGetNumberOfPosts()
        // {

        //     //Arrange

        //     int? userCount = 500;

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfPostsAsync())
        //         .Returns(Task.FromResult(userCount));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfPostsAsync())
        //         .Returns(Task.FromResult(userCount));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfPostsAsync();


        //     //Assert

        //     Assert.Equal(500, userCount);


        // }

        // /**
        // [Fact]
        // public void TestingGetNumberOfSellsByDay()
        // {

        //     //Arrange

        //     int sellsCount = 700;

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfBuysByDayAsync())
        //         .Returns(Task.FromResult(sellsCount));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfBuysByDayAsync())
        //         .Returns(Task.FromResult(sellsCount));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysByDayAsync();


        //     //Assert

        //     Assert.Equal(700, sellsCount);


        // }
        // **/



        // [Fact]
        // public void TestingGetNumberOfBuysAsync()
        // {

        //     //Arrange

        //     int? buysCount = 300;

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfBuysAsync())
        //         .Returns(Task.FromResult(buysCount));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfBuysAsync())
        //         .Returns(Task.FromResult(buysCount));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfBuysAsync();


        //     //Assert

        //     Assert.Equal(300, buysCount);


        // }



        // [Fact]
        // public void TestingGetNumberOfSellsAsync()
        // {

        //     //Arrange

        //     int? sellsCount = 350;

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfSellsAsync())
        //         .Returns(Task.FromResult(sellsCount));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(G => G.GetNumberOfSellsAsync())
        //         .Returns(Task.FromResult(sellsCount));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetNumberOfSellsAsync();


        //     //Assert

        //     Assert.Equal(350, sellsCount);


        // }


        // [Fact]
        // public void TestingGetAllPostAsync()
        // {

        //     //Arrange
        //     int postsCount = 100;

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Post> postList = new List<Post>();
        //     postList.Add(post);



        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetAllPostAsync())
        //         .Returns(Task.FromResult(postList));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetAllPostAsync())
        //         .Returns(Task.FromResult(postList));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.GetAllPostAsync();


        //     //Assert

        //     Assert.Equal(100, postsCount);


        // }






        // [Fact]
        // public void TestingCreatePost()
        // {

        //     //Arrange
        //     CreatePostDto createPost = new CreatePostDto()
        //     {
        //         Content = "I just bought some APPL stock!",
        //         PrivacyLevel = 2,
        //     };

        //     CreatePostDto createPostDto = new CreatePostDto()
        //     {
        //         Content = "I just bought some APPL stock!",
        //         PrivacyLevel = 2,
        //     };


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
        //         .Returns(Task.FromResult(true));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GetsNumberOfUsers = TheClassBeingTested.CreatePostAsync("d44d63fc-ffa8-4eb7-b81d-644547136d30", createPostDto);


        //     //Assert

        //     Assert.True(true);


        // }



        // [Fact]
        // public void TestingGetRecentPostByUserId()
        // {
        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };


        //     var dataSource = new Mock<IdbsRequests>();
        //     if(post == null){}
        //     dataSource
        //         .Setup(p => p.GetRecentPostByUserId(It.IsAny<string>()))
        //         .Returns(Task.FromResult(post));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetRecentPostByUserId(It.IsAny<string>()))
        //         .Returns(Task.FromResult(post));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GotRecentPostByUserId = TheClassBeingTested.GetRecentPostByUserId("d44d63fc-ffa8-4eb7-b81d-644547136d30");


        //     //Assert
        //     if (post != null)
        //     {
        //         Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", post.Fk_UserID);
        //     }


        // }



        // [Fact]
        // public void TestingGetNumberOfCommentsByPostIdAsync()
        // {
        //     int? numberOfComments = 10;
        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(numberOfComments));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(numberOfComments));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GotNumberOfCommentsByPostId = TheClassBeingTested.GetNumberOfCommentsByPostIdAsync(guid);


        //     //Assert

        //     Assert.Equal(guid, post.PostID);


        // }



        // [Fact]
        // public void TestingGetUserWithPostIdAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };


        //     var dataSource = new Mock<IdbsRequests>();
        //     if(post.Fk_UserID == null){}
        //     dataSource
        //         .Setup(p => p.GetUserWithPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post.Fk_UserID));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetUserWithPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post.Fk_UserID));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GotUserWithPostId = TheClassBeingTested.GetUserWithPostIdAsync(guid);


        //     //Assert

        //     Assert.Equal(guid, post.PostID);


        // }

        // //UpdatePost



        // [Fact]
        // public void TestingGetPostByPostId()
        // {

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     if (post == null) {}

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetPostByPostId(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetPostByPostId(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GotPostByPostId = TheClassBeingTested.GetPostByPostId(guid);


        //     //Assert
        //     if(post != null)
        //     {
        //         Assert.Equal(guid, post.PostID);
        //     }


        // }



        // [Fact]
        // public void TestingDeletePostAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.DeletePostAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.DeletePostAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(true));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var DeletedPost = TheClassBeingTested.DeletePostAsync(guid);


        //     //Assert

        //     Assert.Equal(guid, post.PostID);


        // }



        // [Fact]
        // public void TestingGetAllPostByUserIdAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Post> postList = new List<Post>();
        //     postList.Add(post);


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetAllPostByUserIdAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(postList));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetAllPostByUserIdAsync(It.IsAny<string>()))
        //         .Returns(Task.FromResult(postList));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var GotAllPostByUserId = TheClassBeingTested.GetAllPostByUserIdAsync(post.Fk_UserID);


        //     //Assert

        //     Assert.Equal("d44d63fc-ffa8-4eb7-b81d-644547136d30", post.Fk_UserID);


        // }



        // [Fact]
        // public void TestingGetPostByPostIdAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Post> postList = new List<Post>();
        //     postList.Add(post);

        //     if (post != null) {}
        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.GetPostByPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.GetPostByPostIdAsync(It.IsAny<Guid>()))
        //         .Returns(Task.FromResult(post));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     if (post != null)
        //     {
        //         var GotPostByPostIdAsync = TheClassBeingTested.GetPostByPostIdAsync(post.PostID);
        //     }


        //     //Assert
        //     if (post != null)
        //     {
        //         Assert.Equal(guid, post.PostID);
        //     }


        // }



        // [Fact]
        // public void TestingCreateLikeOnPostAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     LikeDto? likedto = new LikeDto()
        //     {
        //         PostId = guid,
        //     };

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Post> postList = new List<Post>();
        //     postList.Add(post);


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.CreateLikeOnPostAsync(It.IsAny<LikeDto>(), It.IsAny<string>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.CreateLikeOnPostAsync(It.IsAny<LikeDto>(), It.IsAny<string>()))
        //         .Returns(Task.FromResult(true));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var CreatedLikeOnPostAsync = TheClassBeingTested.CreateLikeOnPostAsync(likedto, "d44d63fc-ffa8-4eb7-b81d-644547136d30");


        //     //Assert

        //     Assert.True(true);


        // }



        // [Fact]
        // public void TestingDeleteLikeOnPostAsync()
        // {

        //     Guid guid = Guid.NewGuid();

        //     LikeDto? unlikedto = new LikeDto()
        //     {
        //         PostId = guid,
        //     };

        //     Post? post = new Post()
        //     {
        //         PostID = guid,
        //         Fk_UserID = "d44d63fc-ffa8-4eb7-b81d-644547136d30",
        //         Content = "I just bought some more APPL stock!",
        //         Likes = 16,
        //         PrivacyLevel = 2,
        //         DateCreated = new DateTime(),
        //         DateModified = new DateTime(),
        //     };

        //     List<Post> postList = new List<Post>();
        //     postList.Add(post);


        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(p => p.DeleteLikeOnPostAsync(It.IsAny<LikeDto>(), It.IsAny<string>()))
        //         .Returns(Task.FromResult(true));

        //     var dataSource5 = new Mock<IConfiguration>();
        //     dataSource
        //         .Setup(p => p.DeleteLikeOnPostAsync(It.IsAny<LikeDto>(), It.IsAny<string>()))
        //         .Returns(Task.FromResult(true));

        //     var TheClassBeingTested = new dbsRequests(dataSource5.Object);


        //     //Act

        //     var DeletedLikeOnPostAsync = TheClassBeingTested.DeleteLikeOnPostAsync(unlikedto, "d44d63fc-ffa8-4eb7-b81d-644547136d30");


        //     //Assert

        //     Assert.True(true);


        // }
    }
    //Need to add comments to everything!
        
}
