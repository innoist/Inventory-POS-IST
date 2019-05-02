CREATE TABLE [dbo].[StagingEbayBatchImports] (
    [EbayBatchImportId]   INT            IDENTITY (1, 1) NOT NULL,
    [InProcess]           BIT            CONSTRAINT [DF_STG_EBayBatchImport_InProcess] DEFAULT ((0)) NOT NULL,
    [CreatedBy]           NVARCHAR (128) NULL,
    [CreatedOn]           DATETIME       CONSTRAINT [DF_STG_EBayBatchImport_CreatedOn] DEFAULT (getutcdate()) NOT NULL,
    [StartedOn]           DATETIME       NULL,
    [CompletedOn]         DATETIME       NULL,
    [TotalKeywordMatched] INT            NULL,
    [ToBeProcessed]       INT            NULL,
    [Imported]            INT            NULL,
    [Failed]              INT            NULL,
    [Duplicates]          INT            NULL,
    [NoListingType]       INT            NULL,
    [Auctions]            INT            NULL,
    [AuctionsWithBIN]     INT            NULL,
    [Classified]          INT            NULL,
    [FixedPrice]          INT            NULL,
    [StoreInventory]      INT            NULL,
    [EbayTimestamp]       DATETIME       NULL,
    [EbayVersion]         NVARCHAR (25)  NULL,
    [Deleted]             BIT            NULL,
    [DeletedOn]           DATETIME       NULL,
    [DeletedBy]           NVARCHAR (128) NULL,
    CONSTRAINT [PK_STG_EBayBatchImport] PRIMARY KEY CLUSTERED ([EbayBatchImportId] ASC),
    CONSTRAINT [FK_StagingEbayBatchImports_AspNetUsers_CreatedBy] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_StagingEbayBatchImports_AspNetUsers_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[AspNetUsers] ([Id])
);



