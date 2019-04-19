CREATE TABLE [dbo].[ShoppingCartItem] (
    [CartItemId] BIGINT          IDENTITY (1, 1) NOT NULL,
    [CartId]     BIGINT          NOT NULL,
    [ProductId]  BIGINT          NOT NULL,
    [UnitPrice]  DECIMAL (10, 2) NOT NULL,
    [Quantity]   INT             NOT NULL,
    CONSTRAINT [PK_ShoppingCartItems] PRIMARY KEY CLUSTERED ([CartItemId] ASC),
    CONSTRAINT [FK_ShoppingCartItem_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]),
    CONSTRAINT [FK_ShoppingCartItem_ShoppingCart] FOREIGN KEY ([CartId]) REFERENCES [dbo].[ShoppingCart] ([CartId])
);



