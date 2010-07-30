ALTER TABLE [dbo].[tblAccount]
   ADD CONSTRAINT [DF_GUID] 
   DEFAULT NEWID()
   FOR GUID


