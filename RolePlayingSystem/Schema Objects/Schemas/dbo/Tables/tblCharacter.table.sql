CREATE TABLE [dbo].[tblCharacter]
(
	[GUID]					Char(40)				NOT NULL,
	[AccountId]				Char(40)				NOT NULL,
	[CharacterName]			VarChar(25)				NULL,
	[CharacterData]			VarChar(100)			NULL,
	[Entered]				DateTime				NOT NULL,
	[Revised]				DateTime				NOT NULL
)
