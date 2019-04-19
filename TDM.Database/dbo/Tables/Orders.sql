CREATE TABLE [dbo].[Orders] (
    [OrderId]            BIGINT          IDENTITY (1, 1) NOT NULL,
    [IsModified]         BIT             NOT NULL,
    [RecCreatedDate]     DATETIME        NOT NULL,
    [RecLastUpdatedDate] DATETIME        NOT NULL,
    [RecCreatedBy]       NVARCHAR (128)  NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128)  NOT NULL,
    [CustomerId]         BIGINT          NULL,
    [Comments]           NVARCHAR (1000) NULL,
    [IsDeleted]          BIT             NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Orders_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id])
);

