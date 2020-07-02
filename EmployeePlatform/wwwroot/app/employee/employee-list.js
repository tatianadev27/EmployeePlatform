function employeeList(paginationData) {
    globals.makeGraphQLRequest({
        query: `query { employees(pageSize:${globals.pageSize}, filter: "${paginationData.filter}"){
                            totalPages
                            totalRecords
    						results(page:${paginationData.page}, pageSize:${globals.pageSize}, filter: "${paginationData.filter}") {
                            id,
                            identificationNumber,
                            identificationType {
                                name
                            },
                            firstName,
                            lastName,
                            subarea {
                                name,
                                area {
                                name
                                }
                            }
                            }
                        }
                    }`
    }, function successCallback(data) {
        $("#employee-message").empty()
        $("#employee-message").hide(1000)
        if (data != null && data.employees.results != null) {
            if (paginationData.isFilter) {
                $('#paginationComponent').empty();
                $('#paginationComponent').append('<ul id="pagination" class="pagination-sm"></ul>');
                paginationComponent({
                    totalPages: data.employees.totalPages
                });
            }
            let list = data.employees.results;
            let bodyTable = "";
            for (var i = 0; i < list.length; i++) {
                dataEmployee = list[i];
                bodyTable += `<tr>
                            <td>
                                ${dataEmployee.id}
                            </td>
                            <td>
                                ${dataEmployee.identificationNumber}
                            </td>
                            <td>
                                ${dataEmployee.identificationType.name}
                            </td>
                            <td>
                                ${dataEmployee.firstName} ${dataEmployee.lastName}
                            </td>
                            <td>
                                ${dataEmployee.subarea.area.name}
                            </td>
                            <td>
                                ${dataEmployee.subarea.name}
                            </td>
                            <td>
                                <a href="Employee/Edit?id=${dataEmployee.id}"><span class="fa fa-edit"></span></a>
                            </td>
                        </tr>`;
            }
            $("#employee-table").show()
            $("#employee-message").hide(1000).empty()
            $("#employee-body-table").empty();
            $("#employee-body-table").append(bodyTable);
            $("#employee-body-table").show()
        } else {
            $('#paginationComponent').empty();
            bodyTable = `<div class="alert alert-secondary" role="alert">
                            Información no encontrada
                        </div>`
            $("#employee-table").hide(1000)
            $("#employee-body-table").empty();
            $("#employee-message").show(1000)
            $("#employee-message").append(bodyTable);

        }
    });

}

function cleanEmployeeList() {
    $("#employee-search").val("")
    employeeList({
        page: 1,
        filter: $("#employee-search").val(),
        isFilter: true
    })
}