CREATE TABLE [dbo].[tblAccount]
(
	[GUID]				Char(40)			NOT NULL,
	[Login]				VarChar(100)		NOT NULL,
	[Password]			VarChar(25)			NOT NULL,
	[Entered]			DateTime			NOT NULL,
	[Revised]			DateTime			NOT NULL
)
