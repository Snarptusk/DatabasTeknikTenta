CREATE PROCEDURE [dbo].[AddTerritory]
	(@TerritoryDescription   nchar (5)
	,@RegionID  nchar (40))

	AS

INSERT INTO [dbo].[AddTerritory]
	([TerritoryDescription]
	,[RegionID])

VALUES
	(@TerritoryDescription
	,@RegionID)
