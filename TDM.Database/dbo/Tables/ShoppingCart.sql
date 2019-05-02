CREATE TABLE [dbo].[ShoppingCart] (
    [CartId]             BIGINT          IDENTITY (1, 1) NOT NULL,
    [UserCartId]         NVARCHAR (200)  NOT NULL,
    [TransactionId]      NVARCHAR (100)  NULL,
    [Status]             INT             NOT NULL,
    [AmountPaid]         DECIMAL (10, 2) NULL,
    [CurrencyCode]       NVARCHAR (5)    NULL,
    [RecCreatedBy]       NVARCHAR (200)  NOT NULL,
    [RecCreatedDate]     DATETIME        NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (200)  NOT NULL,
    [RecLastUpdatedDate] DATETIME        NOT NULL,
    CONSTRAINT [PK_ShoppingCart] PRIMARY KEY CLUSTERED ([CartId] ASC)
);

