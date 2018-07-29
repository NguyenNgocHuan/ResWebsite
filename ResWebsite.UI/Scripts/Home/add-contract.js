//function Check() {
//    var form = $("#reservation-form");
//    form.validate({
//        errorPlacement: function errorPlacement(error, element) { element.before(error); },
//        rules: {
//            confirm: {
//                equalTo: "#password"
//            }
//        }
//    });
//    form.children("div").steps({
//        headerTag: "h3",
//        bodyTag: "section",
//        transitionEffect: "slideLeft",
//        onStepChanging: function (event, currentIndex, newIndex) {
//            form.validate().settings.ignore = ":disabled,:hidden";
//            return form.valid();
//        },
//        onFinishing: function (event, currentIndex) {
//            form.validate().settings.ignore = ":disabled";
//            return form.valid();
//        },
//        onFinished: function (event, currentIndex) {
//            alert("Submitted!");
//        }
//    });
//}

function addNewContract(placeid) {
    if ($("#check").text() == "-1") {
        alert("Ngày tổ chức không hợp lệ! Vui lòng thay đổi ngày tổ chức!");
    } else {
        $("#p").text(placeid);
        $.ajax({
            type: "GET",
            async: true,
            url: "/Contract/AddContract",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                cusId: $("#name").val(),
                contractTypeId: $("#contracttype").val(),
                plandate: $("#plandate").val(),
                quantity: $("#quan").val(),
                placeId: placeid,
            },
            success: function (data) {
                $("#a").text(data[1]);
                $("#total").val(data[0]);
                $("#deposit").val(parseInt(data[0]) / 2);
                //$(".placemessage").html("");
                //$(".placemessage").append(data[0]);
                alert("Đã chọn phòng");
                //window.location.href = "/Home/Cart";
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Lỗi xảy ra khi tạo đơn đặt trước! Vui lòng nhập đầy đủ thông tin!" + errorThrown);
            }
        });
    }
    
}
function TempContract(placeid) {
    $("#p").text(placeid);
    $.ajax({
        type: "GET",
        async: true,
        url: "/Contract/AddTempContract",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
        },
        success: function (data) {
            $("#a").text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi xảy ra khi tạo đơn đặt trước! Vui lòng nhập đầy đủ thông tin!" + errorThrown);
        }
    })
}
function SubmitContract(cusid, id, cardnumber, deposit, total) {
    alert(cusid + "-" + id + "-" + cardnumber + "-" + deposit + "-" + total);
        $.ajax({
            type: "GET",
            async: false,
            url: "/Home/ShowMenu",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                cusId: cusid,
                contractId: id,
                cardNumber: cardnumber,
                deposit: deposit,
                total: total
            },
            success: function (data) {
                var list = "---MENU---\n";
                list += "---Danh sach mon an---\n";
                var n = 1;
                var total = 0;
                $.each(data[0], function (key, i) {
                    total += i.Price * i.Quantity;
                    list += "ID: " + i.MealDrinkId + "- Gia: " + i.Price + "*" + i.Quantity + "\n";
                })
                list += "---------------\nTotal: " + total;
                alert(list);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Lỗi khi lấy danh sách món ăn đã đặt! Thử lại sau!" + errorThrown);
            }
        });

    }
