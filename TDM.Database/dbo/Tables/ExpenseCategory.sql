CREATE TABLE [dbo].[ExpenseCategory] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (200) NOT NULL,
    [Description]        NVARCHAR (500) NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_ExpenseCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

