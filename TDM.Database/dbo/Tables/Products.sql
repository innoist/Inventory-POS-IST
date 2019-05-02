CREATE TABLE [dbo].[Products] (
    [ProductId]           BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50)   NOT NULL,
    [ProductCode]         NVARCHAR (25)   NULL,
    [ProductBarCode]      NVARCHAR (25)   NULL,
    [PurchasePrice]       DECIMAL (9, 2)  NOT NULL,
    [SalePrice]           DECIMAL (9, 2)  NOT NULL,
    [MinSalePriceAllowed] DECIMAL (9, 2)  NOT NULL,
    [CategoryId]          BIGINT          NOT NULL,
    [VendorId]            BIGINT          NOT NULL,
    [RecCreatedDate]      DATETIME        NOT NULL,
    [RecLastUpdatedDate]  DATETIME        NOT NULL,
    [RecCreatedBy]        NVARCHAR (128)  NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (128)  NOT NULL,
    [Comments]            NVARCHAR (1000) NULL,
    [Specification]       NVARCHAR (2000) NULL,
    [ImagePath]           NVARCHAR (100)  NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProductCategory] ([CategoryId])
);

