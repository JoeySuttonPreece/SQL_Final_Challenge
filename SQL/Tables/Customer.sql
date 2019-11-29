CREATE TABLE [dbo].[Customer]
(
	[CustomerNumber] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[Postcode] NVARCHAR(4) NOT NULL,
	[InterestCode] NVARCHAR(2) NOT NULL,
	PRIMARY KEY ([CustomerNumber]),
	FOREIGN KEY ([InterestCode]) REFERENCES [dbo].[Interest]
)
