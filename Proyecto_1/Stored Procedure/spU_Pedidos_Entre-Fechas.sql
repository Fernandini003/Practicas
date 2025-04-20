CREATE OR ALTER PROC spU_Pedidos_Entre_Fechas
@f1 DATE, @f2 DATE
AS
	SELECT pedidoscabe.IdPedido, pedidoscabe.FechaPedido, Clientes.NombreCia,
	pedidoscabe.CiuDestinatario, pedidoscabe.DirDestinatario 
	FROM pedidoscabe 
	INNER JOIN Clientes ON pedidoscabe.IdCliente = Clientes.IdCliente
	WHERE pedidoscabe.FechaPedido BETWEEN  @f1 AND @f2
GO

spU_Pedidos_Entre_Fechas '04-07-1996', '12-07-1996'

SELECT * FROM pedidoscabe

SELECT @@SERVERNAME