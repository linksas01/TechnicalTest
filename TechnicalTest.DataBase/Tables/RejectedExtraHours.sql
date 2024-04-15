CREATE TABLE [dbo].[RejectedExtraHours]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ExtraHourId] UNIQUEIDENTIFIER NOT NULL, 
    [Description] VARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_RejectedExtraHours_ExtraHours] FOREIGN KEY ([ExtraHourId]) REFERENCES [ExtraHours]([Id])
)
