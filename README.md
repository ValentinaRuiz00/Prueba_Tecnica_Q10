# Prueba_Tecnica_Q10
CRUD Employee

Seguir el siguiente procedimiento, para la correcta funcionalidad del CRUD EmployeeManagement

Paso 1
Abrir la solucion EmployeeManagement
Paso 2
Buscar el proyecto WebApp en la solucion
Paso 3
Buscar el archivo appsettings.json
Paso 4
Modfiicar la conexión a la base de datos encontrada en la linea 4 (CadenaSQL)

Paso 5
En la carpeta del proyecto se encontrará el script de la Base de datos llamada EmployeeDB 
en el script se encuentra la tabla Employee conteniendo la información de empleados (id,name,position,office,salary).

Se crearon los siguientes procedimientos almacenados:  
-sp_list_employeer: Este método es para mostrar la lista de empleados, y no requiere de parámetros.
-sp_get_employee: Este método obtiene como parámetro el idEmployee, para obtener el id de empleado.
-sp_add_employee: Este método obtiene como parámetros el NameEmployee,Position,Office,Salary, para crear un nuevo empleado.
-sp_update_employee: Este método obtiene como parámetros el idEmployee,NameEmployee,Position,Office,Salary, para actualizar la información de empleados mediante el Id.
-sp_delete_employee: Este mpetodo obtiene como parámetro el idEmployee, para eliminar un empleado a través de su id.

