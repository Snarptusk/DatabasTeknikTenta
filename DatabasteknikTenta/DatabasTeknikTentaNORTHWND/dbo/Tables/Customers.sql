﻿CREATE TABLE [dbo].[Customers] (
    [CustomerID]   NCHAR (5)     NOT NULL,
    [CompanyName]  NVARCHAR (40) NOT NULL,
    [ContactName]  NVARCHAR (30) NULL,
    [ContactTitle] NVARCHAR (30) NULL,
    [Address]      NVARCHAR (60) NULL,
    [City]         NVARCHAR (15) NULL,
    [Region]       NVARCHAR (15) NULL,
    [PostalCode]   NVARCHAR (10) NULL,
    [Country]      NVARCHAR (15) NULL,
    [Phone]        NVARCHAR (24) NULL,
    [Fax]          NVARCHAR (24) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [City]
    ON [dbo].[Customers]([City] ASC);


GO
CREATE NONCLUSTERED INDEX [CompanyName]
    ON [dbo].[Customers]([CompanyName] ASC);


GO
CREATE NONCLUSTERED INDEX [PostalCode]
    ON [dbo].[Customers]([PostalCode] ASC);


GO
CREATE NONCLUSTERED INDEX [Region]
    ON [dbo].[Customers]([Region] ASC);


GO
CREATE TRIGGER [CustomerUpdateTrigger]
ON [dbo].[Customers]
FOR UPDATE

AS

BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[CustomerContactNameChanges]
	([ContactID], [OldName], [NewName], [ChangedDate], [UserId])

	SELECT i.[CustomerID], d.[ContactName], i.[ContactName], GETDATE(), USER_ID()
            FROM inserted i
              INNER JOIN deleted d ON i.[CustomerID]=d.[CustomerID]
            WHERE d.[ContactName] <> i.[ContactName]
END