CREATE OR ALTER PROCEDURE USP_CUSTOMERS_CRUD
@INDICADOR VARCHAR(40),
@CustomerID NCHAR(5),
@CompanyName NVARCHAR(40),
@ContactName NVARCHAR (30),
@City NVARCHAR(40) ,
@Country NVARCHAR(15)
AS
BEGIN
	IF @INDICADOR  ='Insertar'
	BEGIN
		--Insersión
		INSERT INTO Customers(CustomerID,CompanyName, ContactName,City,Country)
		VALUES (@CustomerID, @CompanyName,@ContactName,@City,@Country)
	END
--Revisar:-------------------------------------------------------------------------------------------------
--Error:Procedure or function 'USP_CUSTOMERS_CRUD' expects parameter '@CompanyName', which was not supplied. 
	IF @INDICADOR = 'Eliminar'
	BEGIN
		DELETE FROM Orders WHERE CustomerID = @CustomerID;
		DELETE FROM CustomerCustomerDemo WHERE CustomerID = @CustomerID;
		DELETE FROM Customers WHERE CustomerID = @CustomerID;
	END

	IF @INDICADOR = 'Actualizar'
	BEGIN
		UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, City = @City,Country=@Country
		WHERE CustomerID = @CustomerID
	END

	--Revisar:-------------------------------------------------------------------------------------------------
--Error:Procedure or function 'USP_CUSTOMERS_CRUD' expects parameter '@CompanyName', which was not supplied. 
	IF @INDICADOR = 'ConsultarXId'
	BEGIN
		SELECT CompanyName, ContactName,City,Country FROM Customers
		WHERE CustomerID = @CustomerID
	END

--Revisar:-------------------------------------------------------------------------------------------------
--Error:Procedure or function 'USP_CUSTOMERS_CRUD' expects parameter '@CompanyName', which was not supplied. 
	IF @INDICADOR = 'ConsultarTodo'
	BEGIN
		SELECT CompanyName, ContactName,City,Country FROM Customers
	END
END
