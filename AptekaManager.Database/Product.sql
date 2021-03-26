CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Price] NUMERIC NOT NULL, 
    [Quantity] NUMERIC NOT NULL, 
    [Description] VARCHAR(150) NULL, 
    [MeasurementUnitId] INT NOT NULL, 
    [MeasurementUnitsPerBox] INT NOT NULL, 
    [IsSeparableSale] BIT NOT NULL, 
    CONSTRAINT [FK_Product_MeasurementUnit] FOREIGN KEY ([MeasurementUnitId]) REFERENCES [MeasurementUnit]([Id])
)
