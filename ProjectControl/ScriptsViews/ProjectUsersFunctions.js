function userChange() {
    $(document).on('change', "#UserId", function () { 
        var userId = $(this).val();
        $.ajax({
            url: 'UserProjects/GetUserProject',
            data: { id: userId },
            type: "Get",
            dataType: "html",
            success: function (data) {
                $("#divPartialView").html(data);
            }
        });
    });
}