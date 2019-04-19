CREATE TABLE [dbo].[Expenses] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [ExpenseDate]        DATETIME       NOT NULL,
    [ExpenseCategoryId]  BIGINT         NOT NULL,
    [ExpenseAmount]      DECIMAL (9, 2) NOT NULL,
    [Description]        NVARCHAR (500) NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    [VendorId]           BIGINT         NULL,
    CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Expenses_ExpenseCategory] FOREIGN KEY ([ExpenseCategoryId]) REFERENCES [dbo].[ExpenseCategory] ([Id]),
    CONSTRAINT [FK_Expenses_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([VendorId])
);

