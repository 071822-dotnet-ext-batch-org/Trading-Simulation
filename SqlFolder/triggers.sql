--chris
CREATE TRIGGER averagebuy
ON Buys
AFTER INSERT
As
    UPDATE Investments
    SET averageBuyPrice = (currentPrice * (SELECT amountBought FROM inserted) + amountInvested)/totalAmountBought
    WHERE symbol =(SELECT symbol FROM inserted)
GO

CREATE TRIGGER averageSell
ON Sells
After INSERT
As
    UPDATE Investments
    SET averageSellPrice = (currentPrice *totalAmountSold)/currentAmount
    WHERE symbol =(SELECT symbol FROM inserted)

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
AFTER INSERT
AS 
	UPDATE [dbo].[Portfolios]
	SET currentTotal = 
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
ON Dbo.Buys
AFTER INSERT
AS
   UPDATE DBO.Investments
   SET  totalAmountBought = totalAmountBought + (SELECT amountBought FROM inserted) --amountBought
   WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER onDateBought
ON Dbo.Buys
AFTER INSERT
AS
   UPDATE DBO.Portfolios
   SET dateModified = (SELECT dateBought FROM inserted)--dateBought
   WHERE symbols = (SELECT symbols FROM inserted)
GO

CREATE TRIGGER onTotalAmtAftersell
ON Dbo.Sells
AFTER INSERT
AS
   UPDATE DBO.Investments
   SET  totalAmountSold =  totalAmountSold + (SELECT amountSold FROM inserted) --amountSold
   WHERE symbol = (SELECT symbol FROM inserted)
GO

CREATE TRIGGER onDateSold
ON Dbo.Sells
AFTER INSERT
AS
   UPDATE DBO.Portfolios
   SET dateModified = (SELECT dateSold from inserted)--dateSold
   WHERE symbols = (SELECT symbols FROM inserted)
GO

