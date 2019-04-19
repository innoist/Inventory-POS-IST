CREATE TABLE [dbo].[OrderItems] (
    [OrderItemId]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductId]           BIGINT          NOT NULL,
    [Quantity]            INT             NOT NULL,
    [OrderId]             BIGINT          NOT NULL,
    [PurchasePrice]       DECIMAL (9, 2)  NOT NULL,
    [SalePrice]           DECIMAL (9, 2)  NOT NULL,
    [MinSalePriceAllowed] DECIMAL (9, 2)  NOT NULL,
    [Discount]            INT             NULL,
    [RecCreatedDate]      DATETIME        NOT NULL,
    [RecLastUpdatedDate]  DATETIME        NOT NULL,
    [RecCreatedBy]        NVARCHAR (128)  NOT NULL,
    [RecLastUpdatedBy]    NVARCHAR (128)  NOT NULL,
    [AmountGiven]         DECIMAL (9, 2)  NULL,
    [Comments]            NVARCHAR (1000) NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED ([OrderItemId] ASC),
    CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]),
    CONSTRAINT [FK_OrderItems_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

