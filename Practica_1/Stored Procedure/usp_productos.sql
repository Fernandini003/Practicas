CREATE OR ALTER PROC usp_productos
AS
SELECT IdProducto, NomProducto, PrecioUnidad, UnidadesEnExistencia
FROM     dbo.Productos
go

usp_productos