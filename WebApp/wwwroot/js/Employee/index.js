function obtenerDatos() {
    showSpinner();

    $("#dataTable tbody").empty();

    $.ajax({
        url: 'Employee/GetEmployees', // URL del método del controlador
        type: 'GET', // Tipo de solicitud
        dataType: 'json', // Tipo de datos que esperas
        success: function (data) {
            // Limpia el tbody antes de llenarlo
            $("#ListEmployee tbody").empty();

            // Itera sobre los datos y agrega filas a la tabla
            $.each(data, function (index, item) {
                console.log(item)
                var row = "<tr>" +
                    "<td>" + item.idEmployeers + "</td>" +
                    "<td>" + item.name + "</td>" +
                    "<td>" + item.position + "</td>" +
                    "<td>" + item.office + "</td>" +
                    "<td>" + item.salary + "</td>" +
                    "<td class='d-flex justify-content-center align-items-center d-grid gap-3'>" +
                    "<button class='bi bi-pencil-square btn btn-primary btn-sm' onclick='updateEmployee(" + item.idEmployeers + ")'>Update</button >" +
                    "<button class='btn btn-danger btn-sm bi bi-trash3 ml-1' onclick='eliminarRegistro(" + item.idEmployeers + ")'>Delete</button>" +
                    "</td>"
                "</tr>";
                $("#ListEmployee tbody").append(row);
            });
        },
        error: function (error) {
            // Maneja errores
            alert("An error occurred: " + error);

        },
        complete: function () {
            hideSpinner();
        }
    });
}

function updateEmployee(id) {
    window.location.href = '/Employee/Update/' + id;
}

function eliminarRegistro(id) {
    showSpinner();

    $.ajax({
        url: 'Employee/Delete/' + id, // URL del método del controlador
        type: 'POST', // Tipo de solicitud
        dataType: 'json', // Tipo de datos que esperas
        success: function (data) {
            if (data) {
                alert("Se ha eliminado correctamente el registro");
            } else {
                alert("Ha ocurrido un error a intentar eliminar el registro");
            }
            obtenerDatos();
        },
        error: function (error) {
            // Maneja errores
            alert("An error occurred: " + error);

        },
        complete: function () {
            hideSpinner();
        }
    });
}

function agregarRegistro(name, position, Office, salary) {
    showSpinner();

    $.ajax({
        url: 'Employee/Add/', // URL del método del controlador
        data: {
            name, position, Office, salary
        },
        type: 'POST', // Tipo de solicitud
        dataType: 'json', // Tipo de datos que esperas
        success: function (data) {
            if (data) {
                alert("Se ha ingresado correctamente el registro");
                obtenerDatos();
            } else {
                alert("Ha ocurrido un error a intentar ingresar el registro");
            }
        },
        error: function (error) {
            // Maneja errores
            alert("An error occurred: " + error);

        },
        complete: function () {
            hideSpinner();
        }
    });
}

$(document).ready(function () {
    obtenerDatos();

    $('#buttonAdd').click(function (event) {
        event.preventDefault();

        if (!$("#Name").val() || !$("#Position").val() || !$("#Office").val() || !$("#Salary").val())
        {
            alert('Ingrese por favor todos los datos.');
        } else {
            agregarRegistro($("#Name").val(), $("#Position").val(), $("#Office").val(), $("#Salary").val())
        }
    });
});