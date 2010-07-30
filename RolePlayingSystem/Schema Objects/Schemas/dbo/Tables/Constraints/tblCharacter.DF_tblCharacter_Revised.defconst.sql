ALTER TABLE [dbo].[tblCharacter]
   ADD CONSTRAINT [DF_tblCharacter_Revised] 
   DEFAULT GETDATE()
   FOR Revised


