CREATE TABLE [dbo].[Pharmacy_Product]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [PharmacyId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_Pharmacy_Product_Pharmacy] FOREIGN KEY ([PharmacyId]) REFERENCES [Pharmacy]([Id]), 
    CONSTRAINT [FK_Pharmacy_Product_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
