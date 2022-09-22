SELECT TOP (1000) * FROM [dbo].[Portfolios]

INSERT INTO [dbo].[Portfolios] (portfolioID, fk_userID, name, privacyLevel, type, originalLiquid, currrentInvestment, liquid, currentTotal, symbols) 
VALUES('2c7a678a-3735-4d67-a826-2471c6d75ec0','51afedcf-70d2-465c-9b49-20c0e9c00496', 'myPortfolio', 0, 0, 1000, 0, 1000, 1000, 0)

INSERT INTO [dbo].[Users] (userID, role) VALUES ('3b90a622-2fe0-4ee1-b951-abb670961cec', 0)

INSERT INTO [dbo].[Users] (userID, role) VALUES ('126c730e-6dd6-4493-9655-32f5f6489cfd', 0)

INSERT INTO [dbo].[Users] (userID, role) VALUES ('51afedcf-70d2-465c-9b49-20c0e9c00496', 0)

INSERT INTO [dbo].[Investments] (InvestmentID, fk_portfolioID, symbol, amountInvested, currentAmount, currentPrice, totalAmountBought, totalAmountSold, averageBuyPrice, averageSellPrice, totalPNL)
VALUES ('a99699e6-9305-4ec5-9349-bbbe0eb16464', '2c7a678a-3735-4d67-a826-2471c6d75ec0', 'AAPL', 200, 1, 200, 1, 0, 0, 0, 0)
