/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

MERGE INTO dbo.DocumentTypes AS Target
USING (VALUES
		( 1, 'Cédula de Ciudadanía')
	  )
AS Source ( Id, [Name]) 
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET [Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ( Id, [Name]) VALUES ( Id, [Name]);
--WHEN NOT MATCHED BY SOURCE THEN 
--	DELETE;

MERGE INTO dbo.Roles AS Target
USING (VALUES
		(1, 'Manager'),
		(2, 'Human Resources'),
		(3, 'Area Leader'),
		(4, 'Analyst')
	  )
AS Source ( Id, [Name]) 
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET [Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ( Id, [Name]) VALUES ( Id, [Name]);
--WHEN NOT MATCHED BY SOURCE THEN 
--	DELETE;

MERGE INTO dbo.Areas AS Target
USING (VALUES
		(1, 'Area 1')
	  )
AS Source ( Id, [Name]) 
ON Target.Id = Source.Id
WHEN MATCHED THEN
	UPDATE SET [Name] = Source.[Name]
WHEN NOT MATCHED BY TARGET THEN
	INSERT ( Id, [Name]) VALUES ( Id, [Name]);
--WHEN NOT MATCHED BY SOURCE THEN 
--	DELETE;