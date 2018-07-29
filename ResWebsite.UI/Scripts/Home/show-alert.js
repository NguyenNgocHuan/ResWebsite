function showAlert(id, type, content) {
    //type 1 is success
    //type 1 is error
    if(type == 0){
        var pattern = " <div class='alert alert-danger'>" +
             "<strong> Thất bại! </strong>" + content + "</div>";
    } else if (type == 1) {
        var pattern = "<div class='alert alert-success mess'>" +
           "<strong> Thành công! </strong>" + content + "</div>";
    }
    else {
        var pattern = " <div class='alert alert-warning'>"+
            "<strong> Cảnh báo! </strong>" + content + "</div>";
    }
    $(id).html(pattern); setTimeout(function () { $(".mess").addClass("fade"); $(".mess").hide(); }, 8000);

}