function employeeSelect() {
    idArea = $("#Subarea_Area_Id").val();
    idSubarea = $("#SubareaId").val();
    globals.makeGraphQLRequest({
        query: `query { 
                        subareasByArea(idArea:${idArea}) {
                        id
                        name
                      }
                    }`
    }, function successCallback(data) {
        $("#SubareaId").empty();
        if (data != null && data.subareasByArea.length > 0) {
            for (var i = 0; i < data.subareasByArea.length; i++) {
                let subarea = data.subareasByArea[i];
                $('#SubareaId').append('<option value="' + subarea.id + '">' + subarea.name + '</option>')
                if (subarea.id == idSubarea) {
                    $('#SubareaId').val(subarea.id)
                }
            }
        }
    });
}
