select * from  [dbo].[Cat_CapitalHumano_Empleado] 
GO
insert into [dbo].[Cat_Seguridad_Usuario] ( Usuario, Contrasena, EmpleadoID, RolID) 
VALUES('amendoza', '123456', 1, 1),('jperez', '123456', 2, 2)
GO

