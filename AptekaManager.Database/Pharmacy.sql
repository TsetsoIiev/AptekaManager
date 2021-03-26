CREATE TABLE [dbo].[Pharmacy]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [FK_Pharmacy_Address] FOREIGN KEY ([AddressId]) REFERENCES [Address]([Id])
)
