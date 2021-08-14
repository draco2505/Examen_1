/*5.1 Se requiere obtener un listado de órdenes donde sólo se muestren los siguientes campos: OrdenesNumero, 
ClientesNombre y EmpleadosNombres, debe de estar ordenado por nombre del cliente seguido por el número 
de orden*/
SELECT o.OrdenesNumero, c.ClientesNombre, e.EmpleadosNombre
FROM Ordenes o
INNEr JOIN Clientes c on o.ClientesCodigo = c.ClientesCodigo
INNER JOIN Empleados e ON o.EmpleadosCodigo = e.EmpleadosCodigo
Order BY c.ClientesNombre,  o.OrdenesNumero 
GO
/*5.2 Se requiere obtener un listado de empleados y por cada empleado obtener el total de órdenes vendidas por 
dicho empleado*/
SELECT e.EmpleadosCodigo, e.Empleadosnombre, e.EmpleadosDireccion, COUNT(o.OrdenesNumero) OrdenesVendidas
FROM Empleados e
JOIN Ordenes o on e.EmpleadosCodigo = o.EmpleadosCodigo
GROUP BY  e.EmpleadosCodigo, e.Empleadosnombre, e.EmpleadosDireccion
GO
/*5.3 Se requiere actualizar el campo OrdenesMontoTotal se le debe de agregar el 10% del monto original para 
todas aquellas órdenes que fueron del cliente Juan Perez*/
DECLARE @PorcentaJE Decimal(18,2) = 10
UPDATE o SET OrdenesMontoTotal = (OrdenesMontoTotal * (1+(@PorcentaJE/100)))
FROM Ordenes o
JOIN Clientes c on o.ClientesCodigo = c.ClientesCodigo
WHERE c.ClientesNombre = 'Juan Perez'
GO

/*Se requiere obtener el total de órdenes vendidas para los productos: Leche, Harina y Huevo; además se 
requiere de un filtro por fechas, ya que se busca la información entre las fechas 01/01/2020 al 31/03/2020 esto 
para los clientes “Juan Perez” y “Pedro Hernandez” y que la venta la haya realizado cualquier empleado 
donde su código de empleado contenga los siguientes caracteres “A01”*/
SELECT o.OrdenesNumero,  SUM(DetalleOrdenesImporte) AS Total, c.ClientesNombre
FROM Productos p
JOIN DetalleOrdenes do on p.ProductosCodigos = do.ProductosCodigos
JOIN Ordenes o on do.OrdenesNumero = o.Ordenesnumero
JOIN Clientes c on o.ClientesCodigo = c.ClientesCodigo
JOIN Empleados e on o.EmpleadosCodigo = e.EmpleadosCodigo
WHERE p.ProductosCodigos IN ('000000001','000000002','000000003') 
	 AND c.ClientesNombre IN ('Juan Perez','Pedro Hernandez') 
	 --AND Contains( e.EmpleadosCodigo,'A01')
	 AND CAST(o.OrdenesFecha AS DATE)  BETWEEN CAST('2020-01-01' AS DATE) AND CAST('2020-03-31' AS DATE)
GROUP BY  o.OrdenesNumero,  c.ClientesNombre


