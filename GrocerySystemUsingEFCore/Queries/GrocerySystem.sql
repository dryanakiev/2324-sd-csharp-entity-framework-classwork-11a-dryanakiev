CREATE DATABASE GrocerySystem

USE GrocerySystem

CREATE TABLE [Goods](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Weight] DECIMAL(5,2) NOT NULL,
)

CREATE TABLE [Shoppers](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	[Phone] NVARCHAR(50) NOT NULL,
)

CREATE TABLE [Groceries](
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Quantity] INT NOT NULL,
	[GoodsId] INT NOT NULL,
	[ShoppersId] INT NOT NULL,
	CONSTRAINT [FK_Groceries_Goods] FOREIGN KEY ([GoodsId]) REFERENCES [Goods]([Id]),
    CONSTRAINT [FK_Groceries_Shoppers] FOREIGN KEY ([ShoppersId]) REFERENCES [Shoppers]([Id]),
)