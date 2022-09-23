DELETE FROM [dbo].[Portfolios];
DELETE FROM [dbo].[Profiles];
DELETE FROM [dbo].[Users];

INSERT INTO Users(userID) 
    VALUES 
    ('auth0test1'),
    ('auth0test2'),
    ('auth0test3');

INSERT INTO Profiles(fk_userID, name, email, privacyLevel)
    VALUES
    ('auth0test1', 'Keanu Reeves', 'guyfromthematrix1029@gmail.com', 0),
    ('auth0test2', 'Mad Max', 'apocalypsesurvivor@moremail.com', 1),
    ('auth0test3', 'MC Hammer', 'twitterposter203@yahoo.com', 0);

INSERT INTO Portfolios(
    fk_userID, 
    name, 
    privacyLevel, 
    originalLiquid, 
    currentInvestment, 
    liquid, 
    currentTotal, 
    symbols, 
    pnl),
    VALUES
    ('auth0test1', 'My portfolio', 1, 1000, 300, 700, 1000, 2, 0),
    ('auth0test2', 'a new portfolio', 0, 10000, 200, 100, 300, 1, -9700),
    ('auth0test3', 'my first portfolio', 0, 500, 1000, 0, 1000, 3, 500);
