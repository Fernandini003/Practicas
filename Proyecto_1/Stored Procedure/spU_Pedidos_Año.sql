CREATE OR ALTER PROC spU_Pedidos_Año
@y INT 
AS
	SELECT pedidoscabe.IdPedido, pedidoscabe.FechaPedido, Clientes.NombreCia,
	pedidoscabe.CiuDestinatario, pedidoscabe.DirDestinatario 
	FROM pedidoscabe 
	INNER JOIN Clientes ON pedidoscabe.IdCliente = Clientes.IdCliente
	WHERE YEAR (pedidoscabe.FechaPedido)=@y
GO

spU_Pedidos_Año 2010