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
                    "<a class='bi bi-pencil-square btn btn-primary btn-sm' >Update</a >" +
                    "<a class='btn btn-danger btn-sm bi bi-trash3 ml-1'>Delete</a>" +
                    "</td>"
                "</tr>";
                $("#ListEmployee tbody").append(row);
            });
        },
        error: function (xhr, status, error) {
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
});