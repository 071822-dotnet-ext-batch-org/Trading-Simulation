using APILayer.Controllers;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using RepoLayer;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Xml.Linq;


namespace Test.Yoink
{
    public class YoinkBusinessLayerClassTests
    {

        private Helpers helpers = new Helpers();


        [Fact]
        public async Task TestingCreateProfileAsync()
        {
            string auth0UserId = "sample auth0UserId";
            ProfileDto profileDto = new ProfileDto()
            {
                Name = "Jonathan",
                Email = "Jonathan241@revature.net",
                Picture = "http://dazedimg.dazedgroup.netdna-cdn.com/786/azure/dazed-prod/1150/0/1150228.jpg",
                PrivacyLevel = 2
            };
            ActionResult<Profile> expectedCreatedProfile = new OkObjectResult(new Profile());
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(c => c.CreateProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdProfile = await theClassBeingTested.CreateProfileAsync(auth0UserId, profileDto);

            //Assert
            if (createdProfile != null)
            {
                Assert.IsType<ActionResult>(createdProfile);
            }
            Assert.Equal(expectedCreatedProfile.Value, createdProfile);
        }


        [Fact]
        public async Task TestingGetProfileByUserIDAsync()
        {
            string auth0UserId = "sample auth0UserId";


            Profile? expectedGetProfile = new Profile();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(new Profile());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotProfile = await theClassBeingTested.GetProfileByUserIDAsync(auth0UserId);

            //Assert
            if (gotProfile != null)
            {
                Assert.IsType<Profile>(gotProfile);
                Assert.Equal(expectedGetProfile.Name, gotProfile.Name);
            }

        }


        [Fact]
        public async Task TestingEditProfileAsync()
        {
            string auth0UserId = "sample auth0UserId";

            ProfileDto profileDto = new ProfileDto()
            {
                Name = "Jonathan",
                Email = "Jonathan241@revature.net",
                Picture = "http://dazedimg.dazedgroup.netdna-cdn.com/786/azure/dazed-prod/1150/0/1150228.jpg",
                PrivacyLevel = 2
            };

            Profile? expectedEditProfile = new Profile();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(e => e.EditProfileAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var editedProfile = await theClassBeingTested.EditProfileAsync(auth0UserId, profileDto);

            //Assert
            if (editedProfile != null)
            {
                Assert.IsType<Profile>(editedProfile);
                Assert.Equal(expectedEditProfile.Name, editedProfile.Name);
            }
        }


        [Fact]
        public async Task TestingCreatePortfolioAsync()
        {
            string auth0UserId = "sample auth0UserId";

            PortfolioDto portfolioDto = new PortfolioDto()
            {
                PortfolioID = Guid.NewGuid(),
                Name = "Sample Name",
                OriginalLiquid = 1000,
                PrivacyLevel = 2
            };

            Portfolio? excpectedCreatePortfolio = new Portfolio();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(c => c.CreatePortfolioAsync(It.IsAny<string>(), It.IsAny<PortfolioDto>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPortfolio = await theClassBeingTested.CreatePortfolioAsync(auth0UserId, portfolioDto);

            //Assert
            if (createdPortfolio != null)
            {
                Assert.IsType<Profile>(createdPortfolio);
                Assert.Equal(excpectedCreatePortfolio.Name, createdPortfolio.Name);
            }

        }


        [Fact]
        public async Task TestingEditPortfolioAsyncUpdatesPortfolio()
        {

            Guid portfolioDtoGuid = Guid.NewGuid();

            Portfolio expectedCreatePortfolio = new Portfolio()
            {
                PortfolioID = portfolioDtoGuid,
                Fk_UserID = "Sample Fk_UserID",
                Name = "Sample Name",
                PrivacyLevel = 2,
                Type = 0,
                OriginalLiquid = 1000,
                CurrentInvestment = 10000,
                Liquid = 1000,
                CurrentTotal = 10000,
                Symbols = 1,
                TotalPNL = 0,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            PortfolioDto portfolioDto = new PortfolioDto()
            {
                PortfolioID = portfolioDtoGuid,
                Name = "Sample Name",
                OriginalLiquid = 1000,
                PrivacyLevel = 2
            };

            var dataSource = new Mock<IdbsRequests>();

            dataSource
                .Setup(e => e.EditPortfolioAsync(It.IsAny<PortfolioDto>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(e => e.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedCreatePortfolio);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPortfolio = await theClassBeingTested.EditPortfolioAsync(portfolioDto);

            //Assert

            Assert.NotNull(createdPortfolio);
            if (createdPortfolio != null)
            {
                Assert.IsType<Portfolio>(createdPortfolio);
                Assert.Equal(expectedCreatePortfolio.Name, createdPortfolio.Name);
            }
        }


        [Fact]
        public async Task TestingGetPortfolioByPortfolioIDAsync()
        {
            Guid portfolioId = Guid.NewGuid();

            Portfolio? excpectedGetPortfolio = new Portfolio();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Portfolio());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotPortfolio = await theClassBeingTested.GetPortfolioByPortfolioIDAsync(portfolioId);

            //Assert
            Assert.NotNull(gotPortfolio);
            Assert.IsType<Portfolio>(gotPortfolio);
            if (gotPortfolio != null)
            {
                Assert.Equal(excpectedGetPortfolio.Name, gotPortfolio.Name);
            }
        }


        [Fact]
        public async Task TestingGetALLPortfoliosByUserIDAsync()
        {
            string auth0UserId = "sample auth0UserId";

            List<Portfolio?> expectedGetAllPortfolio = new List<Portfolio?>();

            expectedGetAllPortfolio.Add(helpers.fakePortfolio());
            expectedGetAllPortfolio.Add(helpers.fakePortfolio());
            expectedGetAllPortfolio.Add(helpers.fakePortfolio());

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedGetAllPortfolio);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllPortfolios = await theClassBeingTested.GetALLPortfoliosByUserIDAsync(auth0UserId);

            //Assert
            Assert.NotNull(gotAllPortfolios);
            Assert.IsType<List<Portfolio>>(gotAllPortfolios);
            Assert.Equal(expectedGetAllPortfolio, gotAllPortfolios);
        }


        [Fact]
        public async Task TestingAddNewBuyAsyncCreatesNewRowInBuysTable()
        {
            Guid buyIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Buy expectedBuy = new Buy()
            {
                BuyID = buyIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                CurrentPrice = 10,
                AmountBought = 10,
                PriceBought = 10,
                DateBought = new DateTime()
            };

            BuyDto buyDto = new BuyDto()
            {
                portfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                CurrentPrice = 100,
                AmountBought = 20,
                PriceBought = 15
            };

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.AddNewBuyAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(a => a.GetRecentBuyByPortfolioId(It.IsAny<Guid>()))
                .ReturnsAsync(expectedBuy);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var addedBuy = await theClassBeingTested.AddNewBuyAsync(buyDto);

            //Assert
            Assert.NotNull(addedBuy);
            if (addedBuy != null)
            {
                Assert.IsType<Buy>(addedBuy);
                Assert.Equal(expectedBuy.Symbol, addedBuy.Symbol);
            }
        }


        [Fact]
        public async Task TestingAddNewSellAsyncCreatesNewRowInSellsTable()
        {

            Guid sellIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Sell expectedSell = new Sell()
            {
                SellID = sellIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                AmountSold = 100,
                PriceSold = 10,
                DateSold = new DateTime()
            };

            SellDto sellDto = new SellDto()
            {
                Fk_PortfolioID = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                AmountSold = 20,
                PriceSold = 15
            };

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.AddNewSellAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(a => a.GetRecentSellByPortfolioId(It.IsAny<Guid>()))
                .ReturnsAsync(expectedSell);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var addedSell = await theClassBeingTested.AddNewSellAsync(sellDto);

            //Assert
            Assert.NotNull(addedSell);
            if (addedSell != null)
            {
                Assert.IsType<Sell>(addedSell);
                Assert.Equal(expectedSell.Symbol, addedSell.Symbol);
            }
        }


        [Fact]
        public async Task TestingGetAllBuyBySymbolAsyncReturnsAllBuysOfMatchingPortfolioIDAndSymbolOrderByDescendingDateBought()
        {

            Guid buyIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Buy expectedBuy = new Buy()
            {
                BuyID = buyIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                CurrentPrice = 10,
                AmountBought = 10,
                PriceBought = 10,
                DateBought = new DateTime()
            };

            Get_BuysDto AllBuys = new Get_BuysDto()
            {
                Get_BuysID = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Buy?> expectedBuyMockList = new List<Buy?>();
            expectedBuyMockList.Add(expectedBuy);
            expectedBuyMockList.Add(helpers.fakeBuy());
            expectedBuyMockList.Add(helpers.fakeBuy());


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllBuyBySymbolAsync(It.IsAny<Get_BuysDto>()))
                .ReturnsAsync(expectedBuyMockList);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllBuys = await theClassBeingTested.GetAllBuyBySymbolAsync(AllBuys);

            //Assert
            Assert.NotNull(gotAllBuys);
            if (gotAllBuys != null)
            {
                Assert.IsType<List<Buy>>(gotAllBuys);
                Assert.Equal(expectedBuyMockList.Count, gotAllBuys.Count);
                Assert.Equal(expectedBuyMockList[0]?.BuyID, gotAllBuys[0]?.BuyID);
            }
        }


        [Fact]
        public async Task TestingGetAllSellBySymbolAsyncReturnsAllSellsOfMatchingPortfolioIDAndSymbolOrderByDescendingDateSold()
        {

            Guid sellIdGuid = Guid.NewGuid();
            Guid fk_PortfolioIdGuid = Guid.NewGuid();

            Sell expectedSell = new Sell()
            {
                SellID = sellIdGuid,
                Fk_PortfolioID = fk_PortfolioIdGuid,
                Symbol = "Sample Symbol",
                AmountSold = 100,
                PriceSold = 10,
                DateSold = new DateTime()
            };

            GetSellsDto sellsDto = new GetSellsDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol"
            };

            List<Sell?> expectedSellMockList = new List<Sell?>();
            expectedSellMockList.Add(expectedSell);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllSellBySymbolAsync(It.IsAny<GetSellsDto>()))
                .ReturnsAsync(expectedSellMockList);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllSells = await theClassBeingTested.GetAllSellBySymbolAsync(sellsDto);

            //Assert
            Assert.NotNull(gotAllSells);
            if (gotAllSells != null)
            {
                Assert.IsType<List<Sell>>(gotAllSells);
                Assert.Equal(expectedSellMockList, gotAllSells);

            }
        }


        [Fact]
        public async Task TestingGetInvestmentByPortfolioIDAsyncReturningInvestmentsMatchingPortfolioIDandSymbol()
        {
            Guid investmentIdGuid = Guid.NewGuid();
            Guid fk_PortfolioID = Guid.NewGuid();

            Investment expectedInvestment = new Investment()
            {
                InvestmentID = investmentIdGuid,
                Fk_PortfolioID = fk_PortfolioID,
                Symbol = "Sample Symbol",
                AmountInvested = 1000,
                CurrentAmount = 1500,
                CurrentPrice = 1500,
                TotalAmountBought = 1500,
                TotalAmountSold = 0,
                AveragedBuyPrice = 1,
                TotalPNL = 500,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            GetInvestmentDto investmentDto = new GetInvestmentDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
            };

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(expectedInvestment);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotInvestment = await theClassBeingTested.GetInvestmentByPortfolioIDAsync(investmentDto);

            //Assert
            Assert.NotNull(gotInvestment);
            if (gotInvestment != null)
            {
                Assert.IsType<Investment>(gotInvestment);
                Assert.Equal(expectedInvestment.Symbol, gotInvestment.Symbol);
            }

        }


        [Fact]
        public async Task TestingGetInvestmentByTimeAsyncReturnsInvestmentsBetweenTwoDates()
        {

            Guid investmentIdGuid = Guid.NewGuid();
            Guid fk_PortfolioID = Guid.NewGuid();

            Investment expectedInvestment = new Investment()
            {
                InvestmentID = investmentIdGuid,
                Fk_PortfolioID = fk_PortfolioID,
                Symbol = "Sample Symbol",
                AmountInvested = 1000,
                CurrentAmount = 1500,
                CurrentPrice = 1500,
                TotalAmountBought = 1500,
                TotalAmountSold = 0,
                AveragedBuyPrice = 1,
                TotalPNL = 500,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            GetInvestmentByTimeDto investmentByTime = new GetInvestmentByTimeDto()
            {
                PortfolioId = Guid.NewGuid(),
                Symbol = "Sample Symbol",
                StartTime = new DateTime(),
                EndTime = new DateTime()
            };

            List<Investment> expectedMockInvestmentByTimeList = new List<Investment>();
            expectedMockInvestmentByTimeList.Add(expectedInvestment);


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetInvestmentByTimeAsync(It.IsAny<GetInvestmentByTimeDto>()))
                .ReturnsAsync(expectedMockInvestmentByTimeList);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotInvestment = await theClassBeingTested.GetInvestmentByTimeAsync(investmentByTime);

            //Assert
            Assert.NotNull(gotInvestment);
            if (gotInvestment != null)
            {
                Assert.IsType<List<Investment>>(gotInvestment);
                Assert.Equal(expectedMockInvestmentByTimeList, gotInvestment);
            }
        }

        //mark edits
        [Fact]
        public async Task GetNumberOfUsersAsyncReturnsTheAmountOfUsers()
        {

            int excpectedGetNumberUsers = 10;
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfUsersAsync())
                .ReturnsAsync(excpectedGetNumberUsers);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberUsers = await theClassBeingTested.GetNumberOfUsersAsync();

            //Assert
            Assert.NotNull(gotNumberUsers);
            if (gotNumberUsers != null)
            {
                Assert.IsType<int>(gotNumberUsers);
                Assert.Equal(excpectedGetNumberUsers, gotNumberUsers);
            }
        }


        [Fact]
        public async Task TestingGetNumberOfPostsAsyncReturnsNumberOfTotalPosts()
        {

            int? excpectedGetNumberPosts = 10;
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfPostsAsync())
                .ReturnsAsync(excpectedGetNumberPosts);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberPosts = await theClassBeingTested.GetNumberOfPostsAsync();

            //Assert
            Assert.NotNull(gotNumberPosts);
            Assert.IsType<int>(gotNumberPosts);
            Assert.Equal(excpectedGetNumberPosts, gotNumberPosts);

        }


        [Fact]
        public async Task TestingGetNumberOfBuysAsyncReturnsTotalNumberOfBuys()
        {

            int? excpectedGetNumberBuys = 10;
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfBuysAsync())
                .ReturnsAsync(excpectedGetNumberBuys);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberBuys = await theClassBeingTested.GetNumberOfBuysAsync();

            //Assert
            if (gotNumberBuys != null)
            {
                Assert.IsType<int>(gotNumberBuys);
                Assert.Equal(excpectedGetNumberBuys, gotNumberBuys);
            }
        }


        [Fact]
        public async Task TestingGetNumberOfSellsAsyncReturnTotalNumberOfSells()
        {

            int? excpectedGetNumberSells = 10;
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetNumberOfSellsAsync())
                .ReturnsAsync(excpectedGetNumberSells);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotNumberSells = await theClassBeingTested.GetNumberOfSellsAsync();

            //Assert
            if (gotNumberSells != null)
            {
                Assert.IsType<int>(gotNumberSells);
                Assert.Equal(excpectedGetNumberSells, gotNumberSells);
            }
        }


        [Fact]
        public async Task TestingCreatePostAsyncCreatesPostAndReturnsTheNewleyMadePost()
        {
            string auth0UserId = "sample auth0UserId";

            Guid PostIdGuid = Guid.NewGuid();

            Post expectedPost = new Post()//THIS IS NOT NULL - BECAUSE IT IS FILLED WITH PROPERTIES
            {
                PostID = PostIdGuid,
                Fk_UserID = "Sample Fk_UserID",
                Content = "Sample Content",
                Likes = 10,
                PrivacyLevel = 2,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            CreatePostDto post = new CreatePostDto()
            {
                Content = "Sample Content",
                PrivacyLevel = 2
            };

            Post? expectedCreatePost = new Post();//THIS IS NULL - SO IT WILL EXPECT NULL POST
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.CreatePostAsync(It.IsAny<string>(), It.IsAny<CreatePostDto>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(g => g.GetRecentPostByUserId(It.IsAny<string>()))
                .ReturnsAsync(expectedPost);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var createdPost = await theClassBeingTested.CreatePostAsync(auth0UserId, post);
            Post? returnedOBJ = createdPost as Post;//
            //Assert
            Assert.IsType<Post>(returnedOBJ);
            Assert.Equal(expectedPost.Content, returnedOBJ?.Content);
        }


        [Fact]
        public async Task TestingGetAllPostAsyncToReturnAllPostsInDescendingOrder()
        {
            PostWithCommentCountDto listWithCommentCount = new PostWithCommentCountDto()
            {
                PostID = Guid.NewGuid(),
                Fk_UserID = "Sample UserID",
                Content = "Sample Content",
                Likes = 10,
                Comments = 10,
                PrivacyLevel = 2,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };


            List<PostWithCommentCountDto> expectedGotAllPost = new List<PostWithCommentCountDto>();
            List<Post> postList = new List<Post>();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllPostAsync())
                .ReturnsAsync(new List<Post>());
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllPost = await theClassBeingTested.GetAllPostAsync();

            //Assert
            if (gotAllPost != null)
            {
                Assert.IsType<List<PostWithCommentCountDto>>(gotAllPost);
                Assert.Equal(expectedGotAllPost, gotAllPost);
            }
        }


        [Fact]
        public async Task TestingGetAllInvestmentsByPortfolioIDAsyncReturnsAllInvestmentsWithMatchingPortfolioID()
        {
            Guid investmentIdGuid = Guid.NewGuid();
            Guid fk_PortfolioID = Guid.NewGuid();
            Guid portfolioID = Guid.NewGuid();

            Investment expectedInvestment = new Investment()
            {
                InvestmentID = investmentIdGuid,
                Fk_PortfolioID = fk_PortfolioID,
                Symbol = "Sample Symbol",
                AmountInvested = 1000,
                CurrentAmount = 1500,
                CurrentPrice = 1500,
                TotalAmountBought = 1500,
                TotalAmountSold = 0,
                AveragedBuyPrice = 1,
                TotalPNL = 500,
                DateCreated = new DateTime(),
                DateModified = new DateTime()
            };

            List<Investment> expectedGetAllInvestments = new List<Investment>();
            expectedGetAllInvestments.Add(expectedInvestment);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllInvestmentsByPortfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedGetAllInvestments);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var gotAllInvestmentsByID = await theClassBeingTested.GetAllInvestmentsByPortfolioIDAsync(portfolioID);

            //Assert
            if (gotAllInvestmentsByID != null)
            {
                Assert.IsType<List<Investment>>(gotAllInvestmentsByID);
                Assert.Equal(expectedGetAllInvestments, gotAllInvestmentsByID);
            }
        }


        [Fact]
        public async Task TestingUpdatePostAsyncReturnsUpdatedPostWithNewContentAndOrPrivacyLevel()
        {
            string auth0UserId = "sample auth0UserId";

            EditPostDto editPostDto = new EditPostDto()
            {
                PostId = Guid.NewGuid(),
                Content = "Sample Content",
                PrivacyLevel = 2
            };

            Post expectedUpdatedPost = new Post();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.UpdatePostAsync(It.IsAny<EditPostDto>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var updatedPost = await theClassBeingTested.UpdatePostAsync(auth0UserId, editPostDto);

            //Assert
            if (updatedPost != null)
            {
                Assert.IsType<List<Investment>>(updatedPost);
                Assert.Equal(expectedUpdatedPost.Content, updatedPost.Content);
            }
        }


        [Fact]
        public async Task TestingDeletePostAsyncDeletesPostWithMatchingID()
        {
            string auth0UserId = "sample auth0UserId";
            Guid postId = Guid.NewGuid();


            Guid expectedDeletedPost = Guid.NewGuid();
            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.DeletePostAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var deletedPost = await theClassBeingTested.DeletePostAsync(auth0UserId, postId);

            //Assert
            if (deletedPost != null)
            {
                Assert.IsType<List<Investment>>(deletedPost);
                Assert.Equal(expectedDeletedPost, deletedPost);
            }
        }

        /// <summary>
        /// This method tests to see if a user created a profile 
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_CreateProfileAsync_if_Created()
        {
            string auth0UserId = "sample auth0UserId";
            Guid postId = Guid.NewGuid();
            ProfileDto dto = new ProfileDto("name", "email", "string", 1);
            Profile expectedOBJ = new Profile(Guid.NewGuid(), "auth0ID", "name", "email", "src/picture", 1);


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.CreateProfileAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int?>()))
                .ReturnsAsync(true);


        
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.CreateProfileAsync(auth0UserId, dto);
            Profile? profile = returnedResult as Profile;


            //Assert
            Assert.NotNull(profile);
            Assert.IsType<Guid>(profile?.ProfileID);
            Assert.Equal(expectedOBJ, profile);
        }//End of CreateProfileAsync Test - Created


        /// <summary>
        /// This method tests to see if a user created a profile 
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetProfileByUserIDAsync_if_Gotten()
        {
            string auth0UserId = "sample auth0UserId";
            Guid postId = Guid.NewGuid();
            ProfileDto dto = new ProfileDto("name", "email", "string", 1);
            Profile expectedOBJ = new Profile(Guid.NewGuid(), "auth0ID", "name", "email", "src/picture", 1);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);
            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetProfileByUserIDAsync(auth0UserId);
            Profile? profile = returnedResult as Profile;


            //Assert
            Assert.NotNull(profile);
            Assert.IsType<Guid>(profile.ProfileID);
            Assert.Equal(expectedOBJ, profile);
        }//End of CreateProfileAsync Test - Created

        /// <summary>
        /// This method tests to see if a user successfully editted a profile if they have a user ID and an already existing profile
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_EditProfileAsync_if_Editted()
        {
            string auth0UserId = "sample auth0UserId";
            ProfileDto dto = new ProfileDto("name", "email", "string", 1);
            Profile expectedOBJ = new Profile(Guid.NewGuid(), "auth0ID", "name", "email", "src/picture", 1);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.EditProfileAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int?>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.EditProfileAsync(auth0UserId, dto);
            Profile? profile = returnedResult as Profile;

            //Assert
            Assert.NotNull(profile);
            Assert.IsType<Profile?>(profile);
            Assert.Equal(expectedOBJ, profile);
        }//End of EditProfileAsync Test - Edited

        /// <summary>
        /// This method tests to see if a user unsuccessfully editted a profile if even with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_EditProfileAsync_if_NOT_Editted()
        {
            string auth0UserId = "sample auth0UserId";
            ProfileDto dto = new ProfileDto("name", "email", "string", 1);
            Profile? expectedOBJ = null;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.EditProfileAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int?>()))
                .ReturnsAsync(false);
            dataSource
                .Setup(g => g.GetProfileByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.EditProfileAsync(auth0UserId, dto);
            Profile? profile = returnedResult as Profile;

            //Assert
            Assert.Null(profile);
            Assert.Equal(null, profile);
        }//End of EditProfileAsync Test - NOT Edited

        /// <summary>
        /// This method tests to see if a user successfully creates a portfolio with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_CreatePortfolioAsync_if_Created()
        {
            string auth0UserId = "sample auth0UserId";
            PortfolioDto dto = new PortfolioDto(Guid.NewGuid(), "name", 1, 1);
            Portfolio? expectedOBJ = new Portfolio(Guid.NewGuid(), auth0UserId, "Name", 1, 1, 1, 1, 1, 1, 1, 1, DateTime.Now, DateTime.Now);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.CreatePortfolioAsync(It.IsAny<string>(), It.IsAny<PortfolioDto>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(g => g.GetRecentPortfoliosByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.CreatePortfolioAsync(auth0UserId, dto);
            Portfolio? obj = returnedResult as Portfolio;

            //Assert
            Assert.NotNull(obj);
            Assert.IsType<Guid>(obj?.PortfolioID);
            Assert.Equal(expectedOBJ, obj);
        }//End of CreatePortfolioAsync Test - CREATED


        /// <summary>
        /// This method tests to see if a user attempts to unsuccessfully creates a portfolio with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_CreatePortfolioAsync_if_NOT_Created()
        {
            string auth0UserId = "sample auth0UserId";
            PortfolioDto dto = new PortfolioDto(Guid.NewGuid(), "name", 1, 1);
            Portfolio? expectedOBJ = null;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.CreatePortfolioAsync(It.IsAny<string>(), It.IsAny<PortfolioDto>()))
                .ReturnsAsync(false);
            dataSource
                .Setup(g => g.GetRecentPortfoliosByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.CreatePortfolioAsync(auth0UserId, dto);
            Portfolio? obj = returnedResult as Portfolio;

            //Assert
            Assert.Null(obj);
            Assert.Equal(expectedOBJ, obj);
        }//End of CreatePortfolioAsync Test - NOT CREATED


        /// <summary>
        /// This method tests to see if a user successfully gets a portfolio with a portfolio ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetPortfolioByPortfolioIDAsync_if_GOTTEN()
        {
            string auth0UserId = "sample auth0UserId";
            Guid portfolioId = Guid.NewGuid();
            Portfolio? expectedOBJ = new Portfolio(Guid.NewGuid(), auth0UserId, "Name", 1, 1, 1, 1, 1, 1, 1, 1, DateTime.Now, DateTime.Now);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetPortfolioByPortfolioIDAsync(portfolioId);
            Portfolio? obj = returnedResult as Portfolio;

            //Assert
            Assert.NotNull(obj);
            Assert.IsType<Guid>(obj?.PortfolioID);
            Assert.Equal(expectedOBJ, obj);
        }//End of GetPortfolioByPortfolioIDAsync Test - GOTTEN

        /// <summary>
        /// This method tests to see if a user did not successfully gets a portfolio with a portfolio ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetPortfolioByPortfolioIDAsync_if_NOT_GOTTEN()
        {
            Guid portfolioId = Guid.NewGuid();
            Portfolio? expectedOBJ = null;

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetPortfolioByPorfolioIDAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedOBJ);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetPortfolioByPortfolioIDAsync(portfolioId);
            Portfolio? obj = returnedResult as Portfolio;

            //Assert
            Assert.Null(obj);
            Assert.Equal(expectedOBJ, obj);
        }//End of GetPortfolioByPortfolioIDAsync Test - NOT GOTTEN



        /// <summary>
        /// This method tests to see if a user successfully gets a list of portfolios with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetALLPortfoliosByUserIDAsync_if_GOTTEN()
        {
            string auth0UserId = "sample auth0UserId";
            List<Portfolio?> expectedList = new List<Portfolio?>();
            for (int i = 0; i < 5; i++)
            {
                Portfolio? expectedOBJ = new Portfolio(Guid.NewGuid(), auth0UserId, "Name", 1, 1, 1, 1, 1, 1, 1, 1, DateTime.Now, DateTime.Now);
                expectedList.Add(expectedOBJ);

            }


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetALL_PortfoliosByUserIDAsync(It.IsAny<string?>()))
                .ReturnsAsync(expectedList);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetALLPortfoliosByUserIDAsync(auth0UserId);
            List<Portfolio?>? obj = returnedResult as List<Portfolio?>;

            //Assert
            Assert.NotNull(obj);
            Assert.NotEmpty(obj);
            Assert.IsType<List<Portfolio?>>(obj);
            Assert.Equal(expectedList.Count(), obj?.Count());
        }//End of GetALLPortfoliosByUserIDAsync Test - GOTTEN


        /// <summary>
        /// This method tests to see if a user did not successfully get a list of portfolios with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetALLPortfoliosByUserIDAsync_if_NOT_GOTTEN()
        {
            string auth0UserId = "sample auth0UserId";
            List<Portfolio?> expectedList = new List<Portfolio?>();



            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetALL_PortfoliosByUserIDAsync(It.IsAny<string?>()))
                .ReturnsAsync(expectedList);

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetALLPortfoliosByUserIDAsync(auth0UserId);
            List<Portfolio?>? obj = returnedResult as List<Portfolio?>;

            //Assert
            Assert.NotNull(obj);
            Assert.Empty(obj);
            Assert.IsType<List<Portfolio?>>(obj);
            Assert.Equal(0, obj?.Count());
        }//End of GetALLPortfoliosByUserIDAsync Test - NOT GOTTEN

        /// <summary>
        /// This method tests to see if a user successfully gets a list of posts with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetAllPostAsync_if_GOTTEN()
        {
            string auth0UserId = "sample auth0UserId";
            List<Post> expectedPostList = new List<Post>();
            List<PostWithCommentCountDto> expectedList = new List<PostWithCommentCountDto>();
            for (int i = 0; i < 5; i++)
            {
                Post? expectedOBJ = new Post(Guid.NewGuid(), auth0UserId, "content", 1, 1, DateTime.Now, DateTime.Now);
                PostWithCommentCountDto? expectedOBJgotten = new PostWithCommentCountDto(Guid.NewGuid(), auth0UserId, "content", 1, 1, 1, DateTime.Now, DateTime.Now);
                expectedList.Add(expectedOBJgotten);
                expectedPostList.Add(expectedOBJ);

            }


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllPostAsync())
                .ReturnsAsync(expectedPostList);

            dataSource
                .Setup(g => g.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<int>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetAllPostAsync();
            List<PostWithCommentCountDto>? obj = returnedResult as List<PostWithCommentCountDto>;

            //Assert
            Assert.NotNull(obj);
            Assert.NotEmpty(obj);
            Assert.IsType<List<PostWithCommentCountDto?>>(obj);
            Assert.Equal(expectedList.Count(), obj?.Count());
        }//End of GetALLPortfoliosByUserIDAsync Test - GOTTEN


        /// <summary>
        /// This method tests to see if a user successfully gets a list of posts with a user ID
        /// </summary>
        /// <returns>an async Task</returns>
        [Fact]
        public async Task Testing_GetAllPostAsync_if_NOT_GOTTEN()
        {
            List<Post> expectedPostList = new List<Post>();
            List<PostWithCommentCountDto> expectedList = new List<PostWithCommentCountDto>();

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(g => g.GetAllPostAsync())
                .ReturnsAsync(expectedPostList);

            dataSource
                .Setup(g => g.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(It.IsAny<int>());

            var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

            //Act
            var returnedResult = await theClassBeingTested.GetAllPostAsync();
            List<PostWithCommentCountDto>? obj = returnedResult as List<PostWithCommentCountDto>;

            //Assert
            Assert.NotNull(obj);
            Assert.Empty(obj);
            Assert.IsType<List<PostWithCommentCountDto?>>(obj);
            Assert.Equal(0, obj?.Count());
        }//End of GetALLPortfoliosByUserIDAsync Test - NOT GOTTEN



        /// <summary>
        /// This method tests to see if a user unsuccessfully editted a profile 
        /// <returns>an async Task</returns>
        // [Fact]
        // public async Task Testing_EditProfileAsync_if_NOT_Editted()
        // {
        //     string auth0UserId = "sample auth0UserId";
        //     Guid postId = Guid.NewGuid();
        //     ProfileDto dto = new ProfileDto("name", "email", "string", 1);
        //     Profile expectedOBJ = new Profile();

        //     var dataSource = new Mock<IdbsRequests>();
        //     dataSource
        //         .Setup(g => g.EditProfileAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<int?>()))
        //         .ReturnsAsync(false);
        //     var theClassBeingTested = new YoinkBusinessLayer(dataSource.Object);

        //     //Act
        //     var returnedResult = await theClassBeingTested.EditProfileAsync(auth0UserId, dto);

        //     //Assert
        //     // if (returnedResult != null)
        //     // {
        //         Assert.IsType<Profile?>(returnedResult);
        //         Assert.Equal(expectedOBJ, returnedResult);
        //     // }
        // }//End of EditProfileAsync Test - Edited




        [Fact]
        public async Task CreateCommentOnPostAsyncReturnsTrueOnCreatedComment()
        {
            // Arrange
            string fakeUser = "auth0id";
            Guid guid = Guid.NewGuid();
            CommentDto createComment = new(guid, "TestComment");
            bool mockBool = true;

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.CreateCommentOnPostAsync(It.IsAny<CommentDto>(), fakeUser))
                .ReturnsAsync(mockBool);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.CreateCommentOnPostAsync(createComment, fakeUser);

            //Assert
            Assert.Equal(mockBool, result);
        }

        [Fact]
        public async Task EditCommentAsyncReturnsEditedCommentWhenSucceeded()
        {
            // Arrange

            Guid guid = Guid.NewGuid();


            EditCommentDto editedComment = new(guid, "TestComment");

            Comment mockComment = helpers.fakeComment();

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.EditCommentAsync(It.IsAny<EditCommentDto>()))
                .ReturnsAsync(true);
            dataSource
                .Setup(a => a.GetCommentByCommentIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockComment);

            var bl = new YoinkBusinessLayer(dataSource.Object);

            // Act
            var result = await bl.EditCommentAsync(editedComment);

            //Assert
            Assert.Equal(mockComment, result);
        }


        [Fact]
        public async Task DeleteCommentAsyncAuthorizeUserReturnTrueIfDeleted()
        {
            // Arrange

            Guid guid = Guid.NewGuid();
            string userId = "userId";
            bool trueCheck = true;

            EditCommentDto editedComment = new(guid, "TestComment");

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.GetUserWithCommentIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(userId);
            dataSource
                .Setup(a => a.DeleteCommentAsync(It.IsAny<Guid>()))
                .ReturnsAsync(trueCheck);

            var bl = new YoinkBusinessLayer(dataSource.Object);

            // Act
            var result = await bl.DeleteCommentAsync(guid, userId);

            //Assert
            Assert.True(result);
        }


        [Fact]
        public async Task CreateLikeForCommentAsyncReturnsTrueWhenLikeSucceeded()
        {

            // Arrange
            string fakeUser = "auth0id";
            Guid guid = Guid.NewGuid();
            LikeForCommentDto likeComment = new(guid);
            bool mockBool = true;

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.CreateLikeForCommentAsync(It.IsAny<LikeForCommentDto>(), fakeUser))
                .ReturnsAsync(mockBool);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.CreateLikeForCommentAsync(likeComment, fakeUser);

            //Assert
            Assert.Equal(mockBool, result);
        }


        [Fact]
        public async Task DeleteLikeForCommentAsyncReturnsTrueWhenLikeSucceeded()
        {
            // Arrange
            string fakeUser = "auth0id";
            Guid guid = Guid.NewGuid();
            LikeForCommentDto unlikeComment = new(guid);
            bool mockBool = true;

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.DeleteLikeForCommentAsync(It.IsAny<LikeForCommentDto>(), fakeUser))
                .ReturnsAsync(mockBool);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.DeleteLikeForCommentAsync(unlikeComment, fakeUser);

            //Assert
            Assert.Equal(mockBool, result);
        }


        [Fact]
        public async Task GetCountofCommentsByPostIdAsyncReturnsNumberOfCommentsAssociatedWithAValidPostId()
        {
            // Arrange
            Guid guid = Guid.NewGuid();
            LikeForCommentDto unlikeComment = new(guid);
            int mockInt = 10;

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.GetCountofCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockInt);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.GetCountofCommentsByPostIdAsync(guid);

            //Assert
            Assert.Equal(mockInt, result);
        }


        [Fact]
        public async Task DeletePortfolioAsyncReturnTrueIfSuccessfulDelete()
        {
            // Arrange
            string userId = "userId";
            Guid guid = Guid.NewGuid();
            DeletePortfolioDto deleteDto = new(guid);
            bool mockBool = true;

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.DeletePortfolioByPortfolioIDAsync(It.IsAny<string>(), It.IsAny<DeletePortfolioDto>()))
                .ReturnsAsync(mockBool);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.DeletePortfolioAsync(userId, deleteDto);

            //Assert
            Assert.Equal(mockBool, result);
        }


        [Fact]
        public async Task GetPostLikesByUserIdReturnsListOfUserIdsThatHaveLikedAPost()
        {

            // Arrange
            string fakeUser = "auth0id";

            List<Guid> mockGuids = helpers.fakeGuidList();

            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(bl => bl.GetPostLikesByUserID(It.IsAny<string>()))
                .ReturnsAsync(mockGuids);

            var bl = new YoinkBusinessLayer(mockRl.Object);

            // Act
            var result = await bl.GetPostLikesByUserID(fakeUser);


            //Assert
            if (result != null)
            {
                Assert.Equal(mockGuids, result);
            }
        }

        //    public async Task<List<PostWithCommentCountDto>> GetAllPostByUserIdAsync(string userId)

        [Fact]
        public async Task GetAllPostByUserIdAsyncReturnsPostWithCommentCountOnSuccessfulUserId()
        {
            // Arrange

            Guid postId = Guid.NewGuid();
            int mockInt = 2;
            string userId = "userId";

            List<Post> mockPostList = new List<Post>();

            Post fakePost1 = helpers.fakePost();
            fakePost1.Fk_UserID = userId;
            mockPostList.Add(fakePost1);
            Post fakePost2 = helpers.fakePost();
            fakePost2.Fk_UserID = userId;
            mockPostList.Add(fakePost2);

            List<PostWithCommentCountDto> postWithCommentCountList = new List<PostWithCommentCountDto>();

            PostWithCommentCountDto fakePostWithCommentCount1 = new PostWithCommentCountDto()
            {
                PostID = fakePost1.PostID,
                Fk_UserID = fakePost1.Fk_UserID,
                Content = fakePost1.Content,
                Likes = fakePost1.Likes,
                Comments = mockInt,
                DateCreated = fakePost1.DateCreated,
                DateModified = fakePost1.DateModified
            };
            postWithCommentCountList.Add(fakePostWithCommentCount1);

            PostWithCommentCountDto fakePostWithCommentCount2 = new PostWithCommentCountDto()
            {
                PostID = fakePost2.PostID,
                Fk_UserID = fakePost2.Fk_UserID,
                Content = fakePost2.Content,
                Likes = fakePost2.Likes,
                Comments = mockInt,
                DateCreated = fakePost2.DateCreated,
                DateModified = fakePost2.DateModified
            };
            postWithCommentCountList.Add(fakePostWithCommentCount2);

            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.GetAllPostByUserIdAsync(It.IsAny<string>()))
                .ReturnsAsync(mockPostList);
            dataSource
                .Setup(a => a.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockInt);

            var bl = new YoinkBusinessLayer(dataSource.Object);

            // Act
            var result = await bl.GetAllPostByUserIdAsync(userId);

            //Assert
            Assert.Equal(postWithCommentCountList[0].Content, result[0].Content);
        }

        //    public async Task<PostWithCommentCountDto?> GetPostByPostIdAsync(Guid? postId)

        [Fact]
        public async Task GetPostByPostIdReturnsPostWithCommentCountOnSuccessfulRequest()
        {
            // Arrange

            Guid postId = Guid.NewGuid();
            int mockInt = 2;
            string userId = "userId";


            Post fakePost1 = helpers.fakePost();
            fakePost1.Fk_UserID = userId;



            PostWithCommentCountDto fakePostWithCommentCount1 = new PostWithCommentCountDto()
            {
                PostID = fakePost1.PostID,
                Fk_UserID = fakePost1.Fk_UserID,
                Content = fakePost1.Content,
                Likes = fakePost1.Likes,
                Comments = mockInt,
                DateCreated = fakePost1.DateCreated,
                DateModified = fakePost1.DateModified
            };


            var dataSource = new Mock<IdbsRequests>();
            dataSource
                .Setup(a => a.GetPostByPostId(It.IsAny<Guid>()))
                .ReturnsAsync(fakePost1);
            dataSource
                .Setup(a => a.GetNumberOfCommentsByPostIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockInt);

            var bl = new YoinkBusinessLayer(dataSource.Object);

            // Act
            var result = await bl.GetPostByPostIdAsync(postId);

            //Assert
            if (result != null)
            {
                Assert.Equal(fakePostWithCommentCount1.Content, result.Content);
                Assert.Equal(fakePostWithCommentCount1.Fk_UserID, result.Fk_UserID);
            }

        }
        public async Task TestingUpdatePricesAsyncReturnsAllUpdatedRowsDto ()
        {
            // Arrange
            AllUpdatedRowsDto expectedReturn = helpers.fakeAllUpdatedRowsDto();
            string user = "auth0id";

            for(int i = 0; i < expectedReturn.Portfolios.Count; i++)
            {
                expectedReturn.Buys[i].Fk_PortfolioID = expectedReturn.Portfolios[i]?.PortfolioID;
            }
            
            UpdatePriceDto upDto = new UpdatePriceDto(new Random().Next(1000), "AAPL");


            var mockRl = new Mock<IdbsRequests>();
            mockRl.Setup(rl => rl.UpdateBuysCurrentPriceAsync(It.IsAny<UpdatePriceDto>()))
                .ReturnsAsync(true);
            mockRl.Setup(rl => rl.GetAllBuyBySymbolNoPortfolioAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedReturn.Buys);
            mockRl.Setup(rl => rl.UpdateInvestmentsCurrentPriceAsync(It.IsAny<UpdatePriceDto>()))
                .ReturnsAsync(true);
            mockRl.Setup(rl => rl.UpdatePortfoliosCurrentPriceAsync(It.IsAny<List<Guid?>>()))
                .ReturnsAsync(true);
            mockRl.Setup(rl => rl.GetALL_PortfoliosByUserIDAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedReturn.Portfolios);
            mockRl.SetupSequence(rl => rl.GetInvestmentByPortfolioIDAsync(It.IsAny<GetInvestmentDto>()))
                .ReturnsAsync(expectedReturn.Investments[0])
                .ReturnsAsync(expectedReturn.Investments[1])
                .ReturnsAsync(expectedReturn.Investments[2])
                .ReturnsAsync(expectedReturn.Investments[3])
                .ReturnsAsync(expectedReturn.Investments[4]);
                
            var TheClassBeingTested = new YoinkBusinessLayer(mockRl.Object);

            // Act

            var result = await TheClassBeingTested.UpdateCurrentPriceAsync(upDto, user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedReturn.Buys[0].BuyID, result.Buys[0].BuyID);
        }

    }
}


