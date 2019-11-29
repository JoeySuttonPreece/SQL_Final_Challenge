CREATE TABLE [dbo].[Sale]
(
	[Date] DATE NOT NULL,
	[Price] MONEY NOT NULL,
	[CustomerNumber] INT NOT NULL,
	[RecordID] NVARCHAR(5) NOT NULL,
	PRIMARY KEY ([Date], [CustomerNumber], [RecordID]),
	FOREIGN KEY ([CustomerNumber]) REFERENCES [dbo].[Customer],
	FOREIGN KEY ([RecordID]) REFERENCES [dbo].[Record]
)
