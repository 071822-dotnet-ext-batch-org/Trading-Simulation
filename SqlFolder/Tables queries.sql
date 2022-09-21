Create Table Users
(
	userID nvarchar (max) Primary Key not null,
	role int not null DEFAULT 0,
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP
)

Create Table Profiles
(
	profileID UNIQUEIDENTIFIER Primary Key not null DEFAULT newid(), --make sure all the guids have a newid generator
	fk_userID nvarchar (max) not null Foreign Key References Users(userID),
	name nvarchar (max) not null,
	email nvarchar (max) not null,
	privacyLevel int not null
)

Create Table Portfolios
(
	portfolioID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_userID nvarchar not null Foreign Key References Users(userID),
	name nvarchar (max) not null,
	privacyLevel int not null,
	type int not null DEFAULT 0,
	originalLiquid money not null,
	currentInvestment money not null,
	liquid money not null,
	currentTotal money not null,
	symbols int not null,
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP --use this constraint for all datetime columns
)

Create Table Investments
(
	investmentID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_portfolioID uniqueidentifier not null Foreign Key References Portfolios(portfolioID),
	symbol nvarchar (max) not null,
	amountInvested decimal not null,
	currentAmount decimal not null,
	currentPrice money not null,
	totalAmountBought decimal not null,
	totalAmountSold decimal not null,
	averageBuyPrice money not null,
	averageSellPrice money not null,
	totalPNL money not null
)

Create Table Buys
(
	buyID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_portfolioID uniqueidentifier not null Foreign Key References Portfolios(portfolioID),
	symbol nvarchar (max) not null,
	currentPrice money not null,
	amountBought decimal not null,
	priceBought money not null,
	costBasis money not null,
	dateBought datetime DEFAULT CURRENT_TIMESTAMP,
	PNL money not null
)

Create Table Sells
(
	sellID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_portfolioID uniqueidentifier not null Foreign Key References Portfolios(portfolioID),
	symbol nvarchar (max) not null,
	amountSold decimal not null,
	priceSold money not null,
	dateSold datetime not null DEFAULT CURRENT_TIMESTAMP,
	PNL money not null
)

Create Table Friends
(
	friendID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_user1ID nvarchar (max) not null References Users(userID),
	fk_user2ID nvarchar (max) not null References Users(userID),
	dateFriended datetime not null DEFAULT CURRENT_TIMESTAMP,
)

Create Table Posts
(
	postID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_userID nvarchar (max) not null References Users(userID),
	title nvarchar (100) not null, --set the conventional limit
	content nvarchar (max) not null, --set the conventional limit
	likes int not null,
	privacyLevel int not null,
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP
)

Create Table Comments
(
	commentID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_userID nvarchar (max) not null References Users(userID),
	fk_postID  uniqueidentifier not null Foreign Key References Posts(postID),
	content nvarchar (150) not null, --set the conventional limit (150)
	likes int not null,
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP
)

Create Table LikesPosts
(
	likesPostsID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_postID uniqueidentifier not null Foreign Key References Posts(postID),
	fk_userID nvarchar (max) not null References Users(userID),
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP
)

Create Table LikesComments
(
	likesCommentsID uniqueidentifier Primary Key not null DEFAULT newid(),
	fk_commentID uniqueidentifier not null Foreign Key References Comments(commentID),
	fk_userID nvarchar (max) not null References Users(userID),
	dateCreated datetime not null DEFAULT CURRENT_TIMESTAMP,
	dateModified datetime not null DEFAULT CURRENT_TIMESTAMP
)