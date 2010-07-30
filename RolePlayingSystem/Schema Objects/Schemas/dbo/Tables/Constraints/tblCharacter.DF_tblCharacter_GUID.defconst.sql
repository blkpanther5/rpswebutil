ALTER TABLE [dbo].[tblCharacter]
   ADD CONSTRAINT [DF_tblCharacter_GUID] 
   DEFAULT NEWID()
   FOR GUID


