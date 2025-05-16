SELECT * FROM Categorias

CREATE TABLE Herramientas(
idHerramienta VARCHAR(7) PRIMARY KEY,
desHerramienta VARCHAR(100),
medHerramienta VARCHAR(50),
Idcategoria INT REFERENCES Categorias(Idcategoria),
preUnitario	DECIMAL(10,2),
stockActual	INT
)
INSERT INTO Herramientas (idHerramienta, desHerramienta, medHerramienta, Idcategoria, preUnitario, stockActual)
VALUES ('HERR001', 'Destornillador', '15 cm', 2, 10.50, 100);

INSERT INTO Herramientas (idHerramienta, desHerramienta, medHerramienta, Idcategoria, preUnitario, stockActual)
VALUES 
    ('HERR002', 'Destornillador Phillips', '15 cm', 2, 12.99, 75),
    ('HERR003', 'Llave inglesa', '20 cm', 1, 18.50, 30),
    ('HERR004', 'Sierra manual', '50 cm', 3, 22.75, 20),
    ('HERR005', 'Taladro eléctrico', '1.2 kg', 4, 89.90, 10),
    ('HERR006', 'Cinta métrica', '5 metros', 2, 7.25, 100);

SELECT * FROM Herramientas

--=====================PROCESOS ALMACENADOS=====================--
--	Procedure para listar los registros de tb_categorias
CREATE OR ALTER PROC SP_LISTAR_CATEGORIAS
AS
	SELECT IdCategoria,NombreCategoria FROM Categorias
go

--	Procedure para listar los registros de tb_herramienta
CREATE OR ALTER PROC SP_LISTAR_HERRAMIENTAS
AS
	SELECT * FROM Herramientas
go


--	Procedure para agregar un registro a la tabla tb_herramienta
CREATE OR ALTER PROC SP_INSERTAR_HERRAMIENTA
@idHerramienta VARCHAR(7),
@desHerramienta VARCHAR(100),
@medHerramienta VARCHAR(50),
@Idcategoria INT,
@preUnitario DECIMAL(10,2),
@stockActual INT
AS
	INSERT INTO Herramientas(idHerramienta,desHerramienta,medHerramienta,Idcategoria,preUnitario,stockActual)
	VALUES(@idHerramienta,@desHerramienta,@medHerramienta,@Idcategoria,@preUnitario,@stockActual)
go

SP_INSERTAR_HERRAMIENTA 'HERR007',Lija,'25cm',1,4.2,100

SP_LISTAR_HERRAMIENTAS 
GO
--	Procedure para actualizar un registro a la tabla tb_herramienta

CREATE OR ALTER PROC SP_EDITAR_HERRAMIENTA
@idHerramienta VARCHAR(7),
@desHerramienta VARCHAR(100),
@medHerramienta VARCHAR(50),
@Idcategoria INT,
@preUnitario DECIMAL(10,2),
@stockActual INT
AS
	UPDATE Herramientas SET	
		desHerramienta	= @desHerramienta,
		medHerramienta	= @medHerramienta,
		Idcategoria		= @Idcategoria,
		preUnitario		= @preUnitario,
		stockActual		= @stockActual
		WHERE idHerramienta = @idHerramienta
go

SP_EDITAR_HERRAMIENTA HERR001,'Hola Mundo','20cm',3,5.00,95
SP_LISTAR_HERRAMIENTAS
GO

--BUSCAR CLIENTE POR ID
CREATE OR ALTER PROCEDURE SP_BUSCAR_HERRAMIENTA
@idHerramienta VARCHAR(7)
AS
	SELECT TOP 1 * FROM Herramientas 
	WHERE idHerramienta = @idHerramienta
GO

SP_BUSCAR_HERRAMIENTA 'HERR001'

CREATE OR ALTER PROCEDURE SP_ELIMINAR_HERRAMIENTA
@idHerramienta VARCHAR(7)
AS
	DELETE FROM Herramientas
	WHERE idHerramienta = @idHerramienta
GO

SP_ELIMINAR_HERRAMIENTA 'HERR009'

SELECT * FROM Herramientas