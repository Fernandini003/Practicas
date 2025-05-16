-- Para cargar el DropDownList
CREATE OR ALTER PROCEDURE spU_Listar_Paises
AS
	SELECT * FROM paises
		ORDER BY NombrePais
GO

CREATE OR ALTER PROCEDURE spU_Listar_Clientes
AS
	SELECT Clientes.IdCliente, Clientes.NombreCia, 
		   Clientes.Direccion, Clientes.Idpais, 
		   paises.NombrePais, Clientes.Telefono
	FROM Clientes 
	INNER JOIN paises ON Clientes.Idpais = paises.Idpais
GO

CREATE OR ALTER PROCEDURE spU_Buscar_Clientes
@IdCliente VARCHAR(5)
AS
	SELECT TOP 1 * FROM Clientes 
	WHERE IdCliente = @IdCliente
GO



CREATE OR ALTER PROCEDURE sp_MergeCliente
    @IdCliente VARCHAR(5),
    @Nombre VARCHAR(60),
    @Direccion VARCHAR(80),
    @IdPais CHAR(3),
    @Fono VARCHAR(24)
AS
BEGIN
    MERGE INTO Clientes AS TARGET
    USING (SELECT @IdCliente AS IdCliente) AS source
    ON (target.IdCliente = source.IdCliente)
    
    WHEN MATCHED THEN -- Si existe el cliente, actualiza
        UPDATE SET 
            NombreCia = @Nombre,
            Direccion = @Direccion,
            IdPais    = @IdPais,
            Telefono  = @Fono

    WHEN NOT MATCHED BY TARGET THEN 
        INSERT (IdCliente, Nombrecia, Direccion, IdPais, Telefono)
        VALUES (@IdCliente, @Nombre, @Direccion, @IdPais, @Fono);
END
GO

sp_MergeCliente 'ZXZXA','CIBERTEC SAC','AVENIDA URUGUAY 514','001','4516987'