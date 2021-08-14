CREATE TABLE PRODUCTOS
(
	ProductosCodigos Varchar(10) NOT NULL PRIMARY KEY,
	ProductosDescripcion Varchar(100) NOT NULL,
	ProductosPrecio DECIMAL(18,2) NOT NULL,
	ProductosStock INT NOt NULL,
	ProductosUnidad int NOT NuLL
)

GO
CREATE TABLE Clientes
(
	ClientesCodigo Varchar(10) NOT NULL PRIMARY KEY,
	ClientesNombre Varchar(100) NOT NULL,
	ClientesDireccion VARCHAR(250) NOT NULL
)

GO
CREATE TABLE Empleados
(
	EmpleadosCodigo Varchar(10) NOT NULL PRIMARY KEY,
	EmpleadosNombre Varchar(100) NOT NULL,
	EmpleadosDireccion VARCHAR(250) NOT NULL
)

GO
CREATE TABLE Ordenes
(
	OrdenesNumero Varchar(10) NOT NULL PRIMARY key,
	ClientesCodigo Varchar(10) NOT NULL Foreign Key References Clientes(ClientesCodigo),
	EmpleadosCodigo Varchar(10) NOT NULL Foreign Key References Empleados(EmpleadosCodigo),
	OrdenesFecha DATETIME NOT NULL DEFAULT(GETDATE()),
	OrdenesMontoTotal DECIMAL(18,2) NOT NULL,
	OrdenesDetalle VARCHAR(250) NOT NULL

)

GO
CREATE TABLE DetalleOrdenes
(
	OrdenesNumero Varchar(10) NOT NULL FOREIGN KEY REFERENCES Ordenes(OrdenesNumero),
	ProductosCodigos Varchar(10) NOT NULL  FOREIGN KEY REFERENCES Productos(ProductosCodigos),
	DetalleOrdenesPrecioVenta DECIMAL(18,2) NOT NULL,
	DetalleOrdenesCantidadVendida  DECIMAL(18,2) NOT NULL,
	DetalleOrdenesImporte  DECIMAL(18,2) NOT NULL,
	CONSTRAINT pk_Detalleordenes Primary Key (OrdenesNumero, ProductosCodigos )
)

GO

