CREATE TABLE [dbo].[Vendors] (
    [VendorId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (200) NOT NULL,
    [ContactNo]          NVARCHAR (20)  NOT NULL,
    [ActiveFlag]         BIT            NOT NULL,
    [RecCreatedDate]     DATETIME       NOT NULL,
    [RecLastUpdatedDate] DATETIME       NOT NULL,
    [RecCreatedBy]       NVARCHAR (128) NOT NULL,
    [RecLastUpdatedBy]   NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([VendorId] ASC)
);

