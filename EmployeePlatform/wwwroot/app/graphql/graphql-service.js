var globals = {};

globals.pageSize = 1;
globals.token = "";
globals.url = "";


globals.makeGraphQLRequest = function (data, successCallback) {
    $.ajax({
        url: globals.url,
        method: 'post',
        data: data,
        dataType: 'json',
        headers: { 'Authorization': 'Bearer ' + globals.token },
        success: function (response) {
                successCallback(response.data);
        },
        error: "Error"
    });
}