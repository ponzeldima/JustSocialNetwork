
function subscribeOn(userId) {
    $.ajax({
        type: "POST",
        url: "/Subscriptions/Subscribe/",
        data: JSON.stringify(userId),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            alert("ok");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });

}