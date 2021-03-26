CREATE TABLE [dbo].[Address]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [City] VARCHAR(50) NOT NULL, 
    [StreetName] VARCHAR(50) NOT NULL, 
    [StreetNumber] VARCHAR(10) NOT NULL
)
