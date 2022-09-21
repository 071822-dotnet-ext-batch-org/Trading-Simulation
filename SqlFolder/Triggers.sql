--chris
CREATE TRIGGER averagebuy
ON Buys
AFTER INSERT
As
    UPDATE Investments
    SET averageBuyPrice = currentPrice * totalAmountBought/currentAmount
    WHERE symbol =(SELECT symbol FROM inserted)
GO

CREATE TRIGGER averageSell
ON Sells
After INSERT
As
    UPDATE Investments
    SET averageSellPrice = (currentPrice *totalAmountSold)/currentAmount
    WHERE symbol =(SELECT symbol FROM inserted)

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

