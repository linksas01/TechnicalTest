CREATE TABLE [dbo].[ExtraHours]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL, 
    [Date] DATE NOT NULL, 
    [Hours] TINYINT NOT NULL, 
    [Description] VARCHAR(100) NOT NULL, 
    [LeaderApproval] BIT NULL, 
    [HumanResourcesApproval] BIT NULL, 
    [ManagerApproval] BIT NULL, 
    CONSTRAINT [FK_ExtraHours_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id])
)
