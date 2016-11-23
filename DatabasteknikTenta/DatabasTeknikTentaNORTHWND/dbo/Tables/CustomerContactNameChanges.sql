CREATE TABLE [dbo].[CustomerContactNameChanges] (
    [ContactNameChangeID] INT      IDENTITY (1, 1) NOT NULL,
    [ContactID]           TEXT     NOT NULL,
    [OldName]             TEXT     NOT NULL,
    [NewName]             TEXT     NOT NULL,
    [ChangedDate]         DATETIME NOT NULL,
    [UserId]              INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([ContactNameChangeID] ASC)
);

