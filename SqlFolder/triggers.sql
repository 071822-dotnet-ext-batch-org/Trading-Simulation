-- COMBINED TRIGGERS, RUN ONLY THESE ---------------------------------------------------------------
-- TODO: portfolio pnl not changing

DROP TRIGGER buyTrigger;
DROP TRIGGER sellTrigger;

CREATE TRIGGER buyTrigger
ON Buys
AFTER INSERT, UPDATE
AS
	IF EXISTS (SELECT * FROM Investments WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted))
		BEGIN
			UPDATE Investments
			SET	moneyInvested = moneyInvested + (SELECT (amountBought * priceBought) FROM inserted),
				currentAmount = currentAmount + (SELECT amountBought FROM inserted),
				currentPrice = (SELECT priceBought FROM inserted),
				totalAmountBought = totalAmountBought + (SELECT amountBought FROM inserted),
				averageBuyPrice = ((SELECT (amountBought * priceBought) FROM inserted) + moneyInvested)/(currentAmount + (SELECT amountBought FROM inserted)),
				pnl = ((currentAmount + (SELECT amountBought FROM inserted)) * (SELECT currentPrice FROM inserted)) - (moneyInvested + (SELECT (amountBought * priceBought) FROM inserted)),
				dateModified = CURRENT_TIMESTAMP
			WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted);


			UPDATE Portfolios
			SET currentInvestment = currentInvestment + (SELECT (amountBought * priceBought) FROM inserted),
				liquid = liquid - (SELECT (amountBought * priceBought) FROM inserted),
				currentTotal = (liquid - (SELECT (amountBought * priceBought) FROM inserted)) + (currentInvestment + (SELECT (amountBought * priceBought) FROM inserted)),
				pnl = ((liquid - (SELECT (amountBought * priceBought) FROM inserted)) + (currentInvestment + (SELECT (amountBought * priceBought) FROM inserted))) - originalLiquid,
				dateModified = CURRENT_TIMESTAMP
			WHERE portfolioID = (SELECT fk_portfolioID FROM inserted);
		END
	ELSE
		BEGIN
			INSERT INTO Investments (
				fk_portfolioID, 
				symbol, 
				moneyInvested, 
				currentAmount, 
				currentPrice, 
				totalAmountBought, 
				totalAmountSold, 
				averageBuyPrice,
				pnl
			)
			VALUES (
				(SELECT fk_portfolioID FROM inserted),
				(SELECT symbol FROM inserted),
				(SELECT (amountBought * priceBought) FROM inserted),
				(SELECT amountBought FROM inserted),
				(SELECT currentPrice FROM inserted),
				(SELECT amountBought FROM inserted),
				0,
				(SELECT currentPrice FROM inserted),
				0
			); 

			UPDATE Portfolios
			SET	currentInvestment = currentInvestment + (SELECT (amountBought * priceBought) FROM inserted),
				liquid = liquid - (SELECT (amountBought * priceBought) FROM inserted),
				currentTotal = (liquid - (SELECT (amountBought * priceBought) FROM inserted)) + (currentInvestment + (SELECT (amountBought * priceBought) FROM inserted)),
				symbols = symbols + 1,
				pnl = ((liquid - (SELECT (amountBought * priceBought) FROM inserted)) + (currentInvestment + (SELECT (amountBought * priceBought) FROM inserted))) - originalLiquid,
				dateModified = CURRENT_TIMESTAMP
			WHERE portfolioID = (SELECT fk_portfolioID FROM inserted);
		END
GO;

-- TRIGGER TEST
INSERT INTO Buys(fk_portfolioID, symbol, currentPrice, amountBought, priceBought) VALUES([get the portfolioID from table], 'AAPL', 15.00, 3, 15.00);
INSERT INTO Buys(fk_portfolioID, symbol, currentPrice, amountBought, priceBought) VALUES([get the portfolioID from table], 'AAPL', 15.50, 4, 15.50);

CREATE TRIGGER sellTrigger
ON Sells
AFTER INSERT
AS
	BEGIN

		IF (SELECT amountSold FROM inserted) < (SELECT currentAmount FROM Investments WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted))
			UPDATE Investments
			SET averageBuyPrice = (moneyInvested - (SELECT (amountSold * priceSold) FROM inserted))/(currentAmount - (SELECT amountSold FROM inserted))
			WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted);
		ELSE 
			UPDATE Investments
			SET averageBuyPrice = 0
			WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted);


		UPDATE Investments
		SET moneyInvested = moneyInvested - (SELECT (amountSold * priceSold) FROM inserted),
			currentAmount = currentAmount - (SELECT amountSold FROM inserted),
			currentPrice = (SELECT priceSold FROM inserted),
			totalAmountSold = totalAmountSold + (SELECT amountSold FROM inserted),
			pnl = ((currentAmount - (SELECT amountSold FROM inserted)) * (SELECT priceSold FROM inserted)) - (moneyInvested - (SELECT (amountSold * priceSold) FROM inserted)),
			dateModified = CURRENT_TIMESTAMP
		WHERE symbol = (SELECT symbol FROM inserted) AND fk_portfolioID = (SELECT fk_portfolioID FROM inserted);


		IF (SELECT currentInvestment FROM Portfolios WHERE portfolioID = (SELECT fk_portfolioID FROM inserted)) >= (SELECT (amountSold * priceSold) FROM inserted)
			UPDATE Portfolios
			SET currentInvestment = currentInvestment - (SELECT (amountSold * priceSold) FROM inserted)
			WHERE portfolioID = (SELECT fk_portfolioID FROM inserted);
		ELSE 
			UPDATE Portfolios
			SET currentInvestment = 0
			WHERE portfolioID = (SELECT fk_PortfolioID FROM inserted);


		UPDATE Portfolios
		SET liquid = liquid + (SELECT (amountSold * priceSold) FROM inserted),
			currentTotal = currentInvestment + (liquid + (SELECT (amountSold * priceSold) FROM inserted)),
			pnl = currentInvestment + (liquid + (SELECT (amountSold * priceSold) FROM inserted)) - originalLiquid,
			dateModified = CURRENT_TIMESTAMP
		WHERE portfolioID = (SELECT fk_PortfolioID FROM inserted);

	END
GO;

-- TRIGGER TEST
INSERT INTO Sells(fk_portfolioID, symbol, amountSold, priceSold) VALUES([get the portfolioID from table], 'AAPL', 3, 15.00);
INSERT INTO Sells(fk_portfolioID, symbol, amountSold, priceSold) VALUES([get the portfolioID from table], 'AAPL', 4, 15.50);

CREATE TRIGGER AddLikesToPost
ON [dbo].[LikesPosts]
AFTER INSERT 
AS 
	UPDATE [dbo].[Posts]
	SET likes = likes +1
	WHERE postID=(SELECT fk_postID FROM inserted);
	GO


CREATE TRIGGER AddLikesToComments
ON [dbo].[LikesComments] 
AFTER INSERT
As 
	UPDATE [dbo].[Comments]
	SET likes = likes + 1
	WHERE commentID = (SELECT commentID FROM inserted);


CREATE TRIGGER DeleteLikesToPost
ON[dbo].[LikesPosts]
AFTER DELETE
AS
UPDATE[dbo].[Posts]
SET likes = likes - 1
WHERE postID = (SELECT fk_postID FROM deleted);
GO



-- COMBINED TRIGGERS, RUN ONLY THESE ---------------------------------------------------------------



--chris
CREATE TRIGGER averageBuy
ON Buys
AFTER INSERT
As
    UPDATE Investments
    SET averageBuyPrice = ((currentPrice * (SELECT amountBought FROM inserted)) + amountInvested)/totalAmountBought
    WHERE symbol =(SELECT symbol FROM inserted)
GO;

--Mikael

CREATE TRIGGER onTotalAmtInvested
ON [dbo].[Buys]
AFTER INSERT
AS
	UPDATE [dbo].[Investments]
	SET amountInvested = amountInvested + (currentPrice * totalAmountBought)
	WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER updateCurrentPrice
ON [dbo].[Buys]
AFTER INSERT
AS 
	UPDATE [dbo].[Investments]
	SET currentPrice = (SELECT currentPrice from inserted)
	WHERE symbol = (SELECT symbol FROM inserted)
GO
-->>>>>>new stuff
--TODO 
--CREATE TRIGGER totalPNLAfterBuy
--ON [dbo].[Buys]
--AFTER INSERT
--AS 
--	UPDATE [dbo].[Investments]
--	SET totalPNL = aver) + PNL --avg priceb * amountb = baseline >=< currentprice * amountb
--	WHERE symbol = (SELECT symbol FROM inserted)
--GO

CREATE TRIGGER totalPNLAfterSell
ON [dbo].[Sells]
AFTER INSERT
AS 
	UPDATE [dbo].[Investments]
	SET totalPNL = PNL - ()
	WHERE symbol = (SELECT symbol FROM inserted)
GO
-- ^^^^^^^^^^^^^^^^^^^^^^^
CREATE TRIGGER updateLiquidAfterBuy
ON [dbo].[Buys]
AFTER INSERT
AS 
	UPDATE [dbo].[Portfolios]
	SET liquid = (SELECT priceBought from inserted) - liquid
	WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER updateLiquidAfterSell
ON [dbo].[Sells]
AFTER INSERT
AS 
	UPDATE [dbo].[Portfolios]
	SET liquid = (SELECT priceSold from inserted) - liquid
	WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER updateCurrentTotal
ON [dbo].[Investments]
AFTER UPDATE
AS 
	UPDATE [dbo].[Portfolios]
	SET currentTotal = liquid + currentInvestment
	WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER updateCurrentInvestment
ON [dbo].[Investments]
AFTER UPDATE
AS 
	UPDATE [dbo].[Portfolios]
	SET currentInvestment = currentInvestment + (SELECT amountInvested FROM inserted)
	WHERE symbol = (SELECT symbol FROM inserted)
GO
-->>>>>>new stuff

--Mohammad
CREATE TRIGGER curramountboughttrigger
ON [dbo].[Buys]
AFTER INSERT
AS
    UPDATE [dbo].[Investments]
    SET currentAmount  = currentAmount + (select amountBought from inserted)
    WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER curramountsoldtrigger
ON [dbo].[Sells]
AFTER INSERT
AS
    UPDATE [dbo].[Investments]
    SET currentAmount  = currentAmount + (select amountSold from inserted)
    WHERE symbol = (SELECT symbol FROM inserted)
GO

--Emmanuel
CREATE TRIGGER onTotalAmtAfterbuy
ON [dbo].[Buys]
AFTER INSERT
AS
   UPDATE DBO.Investments
   SET  totalAmountBought = totalAmountBought + (SELECT amountBought FROM inserted) --amountBought
   WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER onDateBought
ON [dbo].[Buys]
AFTER INSERT
AS
   UPDATE DBO.Portfolios
   SET dateModified = (SELECT dateBought FROM inserted)--dateBought
   WHERE symbols = (SELECT symbols FROM inserted)
GO

CREATE TRIGGER onTotalAmtAftersell
ON [dbo].[Sells]
AFTER INSERT
AS
   UPDATE DBO.Investments
   SET  totalAmountSold =  totalAmountSold + (SELECT amountSold FROM inserted) --amountSold
   WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER onDateSold
ON [dbo].[Sells]
AFTER INSERT
AS
   UPDATE DBO.Portfolios
   SET dateModified = (SELECT dateSold from inserted)--dateSold
   WHERE symbols = (SELECT symbols FROM inserted)
GO

