CREATE TABLE [dbo].[InventoryItems] (
    [ItemId]              BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]           BIGINT          NOT NULL,
    [VendorId]            BIGINT          NULL,
    [Quantity]            BIGINT          NOT NULL,
    [Comments]            NVARCHAR (1000) NULL,
    [RecCreatedBy]        NVARCHAR (128)  NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (128)  NOT NULL,
    [RecCreatedDate]      DATETIME        NOT NULL,
    [RecLastUpdatedDate]  DATETIME        NOT NULL,
    [PurchasingDate]      DATETIME        NOT NULL,
    [PurchasePrice]       DECIMAL (9, 2)  NOT NULL,
    [SalePrice]           DECIMAL (9, 2)  NOT NULL,
    [MinSalePriceAllowed] DECIMAL (9, 2)  NOT NULL,
    CONSTRAINT [PK_InventoryItems] PRIMARY KEY CLUSTERED ([ItemId] ASC),
    CONSTRAINT [FK_InventoryItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]),
    CONSTRAINT [FK_InventoryItems_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([VendorId])
);

