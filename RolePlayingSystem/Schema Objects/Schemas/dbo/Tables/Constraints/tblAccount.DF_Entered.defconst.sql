ALTER TABLE [dbo].[tblAccount]
   ADD CONSTRAINT [DF_Entered] 
   DEFAULT GETDATE()
   FOR Entered


