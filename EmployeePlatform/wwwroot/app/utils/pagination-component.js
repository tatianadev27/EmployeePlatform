function paginationComponent(paginationData) {
    $('#pagination').twbsPagination({
        totalPages: paginationData.totalPages,
        onPageClick: function (_, page) {
            if (page > 0) {
                employeeList({
                    page: page,
                    filter: $("#employee-search").val(),
                    isFilter: false
                })
            }
        }
    });
}