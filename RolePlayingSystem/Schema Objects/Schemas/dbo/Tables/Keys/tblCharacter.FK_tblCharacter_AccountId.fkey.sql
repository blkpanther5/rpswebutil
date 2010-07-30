ALTER TABLE [dbo].[tblCharacter]
	ADD CONSTRAINT [FK_tblCharacter_AccountId] 
	FOREIGN KEY (AccountId)
	REFERENCES tblAccount (GUID)	

