CREATE DATABASE EmployeeDB
USE EmployeeDB

CREATE TABLE Employee(
IdEmployee INT IDENTITY PRIMARY KEY,
NameEmployee VARCHAR (50),
Position VARCHAR(50),
Office VARCHAR(50),
Salary DECIMAL(10,2));


--Procedimiento almacenado para listar empleados
CREATE PROCEDURE sp_list_employeer
AS
BEGIN 
	SELECT * FROM Employee
END

--Procedimiento almacenado para obtener empleados
CREATE PROCEDURE sp_get_employee(
@IdEmployee INT 
)
AS
BEGIN
	SELECT * FROM Employee WHERE IdEmployee = @IdEmployee
END

--Procedimiento almacenado para añadir empleados a la tabla
CREATE PROCEDURE sp_add_employee(
	@NameEmployee VARCHAR(50),
	@Position VARCHAR(50),
	@Office VARCHAR(50),
	@Salary DECIMAL(10,2))
AS
BEGIN
	INSERT INTO Employee(NameEmployee,Position,Office,Salary)VALUES(@NameEmployee,@Position,@Office,@Salary)
END

EXECUTE sp_add_employee @NameEmployee='Yeimer Jaramillo',@Position='Senior developer',@Office='Software',@Salary=200000
EXECUTE sp_add_employee @NameEmployee='Valwntina Ruiz',@Position='Senior developer',@Office='Software',@Salary=200000


--Procedimiento almacenado para editar empleados en la tabla
CREATE PROCEDURE sp_update_employee(
	@IdEmployee INT,
	@NameEmployee VARCHAR(50),
	@Position VARCHAR(50),
	@Office VARCHAR(50),
	@Salary DECIMAL(10,2))
AS
BEGIN
	UPDATE Employee SET 
	NameEmployee=@NameEmployee,
	Position=@Position,
	Office=@Office,
	Salary=@Salary
	WHERE IdEmployee=@IdEmployee
END

EXECUTE sp_update_employee @IdEmployee=2, @NameEmployee='Valentina Tapias',@Position='Junior developer',@Office='Software',@Salary=200000


--Procedimiento almacenado para eliminar un empleado de la tabla
CREATE PROCEDURE sp_delete_employee(
	@IdEmployee INT)
AS
BEGIN
	DELETE FROM Employee WHERE IdEmployee=@IdEmployee
END

EXECUTE sp_delete_employee @IdEmployee=1

SELECT * FROM Employee