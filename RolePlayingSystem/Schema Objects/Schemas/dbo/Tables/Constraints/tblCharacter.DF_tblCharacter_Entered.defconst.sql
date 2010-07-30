ALTER TABLE [dbo].[tblCharacter]
   ADD CONSTRAINT [DF_tblCharacter_Entered] 
   DEFAULT GETDATE()
   FOR Entered


