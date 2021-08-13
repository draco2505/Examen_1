CREATE TABLE Cat_CapitalHumano_Empleado
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre varchar(50) NOT NULL,
	Apellidos Varchar(50) NOT NULL,
	Activo BIT NOT NULL DEFAULT(1)

)
GO

Create Table Cat_Seguridad_Rol
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	Rol Varchar(50) NOT NULL, 
	Activo BIT NOT NULL DEFAULT(1)
)
GO
CREATE TABLE Cat_Seguridad_Usuario
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	Usuario Varchar(15) NOT NULL,
	Contrasena Varchar(8) NOT NULL,
	EmpleadoID INT Foreign Key references  Cat_CapitalHumano_Empleado(ID),
	RolID Int Foreign Key References  Cat_Seguridad_Rol(Id),
	Activo BIT NOT NULL DEFAULT(1)
)
GO
CREATE TABLE Cat_Ventas_TipoHabitacion
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	TipoHabitacion Varchar(50) not null,
	Activo BIT not null DEFAULT(1)
)
GO
CREATE Table Cat_Ventas_Habitacion
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	TipoHabitacionID INT FOREIGN KEY References Cat_Ventas_TipoHabitacion(ID),
	PrecioHabitacion Money not null,
	Nombre Varchar(50) NOT NULL,
	RutaFoto Varchar(Max),
	NoHabitacion int not null, 
	Disponible BIT NOT NULL DEFAULT 1
)
GO
CREATE Table Cat_Ventas_TipoCliente
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	TipoCliente Varchar(50) not null,
	Activo BIT not null DEFAULT(1)
)
GO
CREATE Table Cat_Ventas_Cliente
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	Nombre varchar(50) NOT NULL,
	Apellidos Varchar(50) NOT NULL,
	TipoclienteID INT NOT NULL,
	Descuento Decimal(18,2) NULL
)
GO
Create Table Tra_Ventas_Reservacion
(
	Id INT Identity(1,1) NOT NULL Primary Key,
	ClienteID int Foreign key References Cat_Ventas_Cliente(Id),
	HabitacionID INT FOREIGN KEY References Cat_Ventas_Habitacion(Id),
	FechaIngreso DateTime Not NULL,
	DiasEstancia int Not null,
	FechaRegistro DateTime,
	SubTotal Decimal(18,2) NOT NULL,
	IVA Decimal(18,2) NOT NULL DEFAULT(16),
	Total Decimal(18,2) NOT NULL,
	Estatus BIT NOT NULL DEFAULT(1)
)
GO
INSERT INTO Cat_CapitalHumano_Empleado (Nombre, Apellidos) VALUES ('Alberto', 'Mendoza Mejia'), ('Jose Maria', 'Perez Lopez'), ('Gabriela','Soto Campo')
GO
 INSERT INTO Cat_Seguridad_Rol (Rol) Values ('Administrador'), ('Recepcionista'), ('Portero')
 GO
 Insert INTO Cat_Ventas_TipoHabitacion (TipoHabitacion) VALUES ('Simple'), ('Doble'),('Matrimonial')
 GO
INSERT INTO Cat_Ventas_TipoCliente (TipoCliente) VALUES ('Esporadico'), ('Habitual')
GO
