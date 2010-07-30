ALTER TABLE [dbo].[tblAccount]
   ADD CONSTRAINT [DF_Revised] 
   DEFAULT GETDATE()
   FOR Revised


