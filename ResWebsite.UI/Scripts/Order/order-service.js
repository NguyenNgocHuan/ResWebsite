function SearchServiceId(id) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/SearchService",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            serviceId: id,
            placeId: $("#placeID").text(),
            note: $(".note").val(),
        },
        success: function (data) {
            $("#serviceTable tbody").html("");
            $.each(data, function (key, i) {
                $("#serviceTable tbody").append("<tr><td>" + i.Name + "</td>" +
                                         "<td>" + i.Price + "</td>" +
                                         "<td>" + i.Quantity + "</td>" +
                                         "<td>" + i.note + "</td>" +
                                         "<td>" +
                                         "<button class='btn btn-danger'onclick='DelServiceOD(" + i.orderId + ", " + '"' + i.id + '"' + ");'>" +
                                         "<i class='fa fa-pencil'></i>" +
                                         "</button>" +
                                         "</td></tr>");
            })
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi search service info!" + errorThrown);
        }
        //$(".homemessage").text(new Date.now);
        //if ($("#datetime").val() <= Date.now()) {
        //    $(".homemessage").text("Chọn ngày tổ chức sau ít nhất 3 ngày tạo đơn đặt trước!");
        //}
    });
}

function LoadPlaceList() {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/ShowPlaceList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
        },
        success: function (data) {
            $("#placeList").html("");
            $.each(data, function (key, i) {
                if (i.Descriptions == "")
                {
                    $("#placeList").append(
                    "<div class='col-md-3 col-sm-12 col-xs-12' onclick='clickTable("+i.PlaceId+");AddOrder("+i.PlaceId+");' data-toggle='modal' data-target='#myModal' style='cursor: pointer'>"+
                        "<div class='panel panel-primary text-center no-boder bg-color-green'>"+
                            "<div class='col-md-12 col-sm-12 col-xs-12' style='padding-left:0;padding-right:0'>"+
                                "<img src='"+i.Picture +"' alt="+i.PlaceName+" style='width:200px;height:150px;' />"+
                            "</div>"+
                            "<div class='panel-footer back-footer-green'>"+
                                i.PlaceName+" - " + i.Descriptions +
                            "</div>"+
                        "</div>"+
                    "</div>");
                }
                else
                {
                    $("#placeList").append(
                    "<div class='col-md-3 col-sm-12 col-xs-12' onclick='clickTable("+i.PlaceId+");ShowList("+i.PlaceId+")' data-toggle='modal' data-target='#myModal' style='cursor: pointer'>"+
                       "<div class='panel panel-primary text-center no-boder bg-color-green'>"+
                            "<div class='col-md-12 col-sm-12 col-xs-12' style='padding-left:0;padding-right:0'>"+
                                "<img src='"+i.Picture +"' alt="+i.PlaceName+" style='width:200px;height:150px;' />"+
                            "</div>"+
                            "<div class='panel-footer back-footer-red'>"+
                                "Check out - " + i.Descriptions +
                             "</div>" +
                        "</div>" +
                    "</div>");
                   }
            });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi load place list!" + errorThrown);
        }
    });
}

function DelServiceOD(oid, sid) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/DeleteServiceFromListOrder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            orderId: oid,
            serviceId: sid
        },
        success: function (data) {
            $("#serviceTable tbody").html("");
            if (data != null) {
                $.each(data, function (key, i) {
                    $("#serviceTable tbody").append("<tr><td>" + i.Name + "</td>" +
                                                             "<td>" + i.Price + "</td>" +
                                                             "<td>" + i.Quantity + "</td>" +
                                                             "<td>" + i.Note + "</td>" +
                                                             "<td>" +
                                                             "<button class='btn btn-danger'onclick='DelServiceOD(" + i.orderId + ", " + '"' + i.id + '"' + ");'>" +
                                                             "<i class='fa fa-pencil'></i>" +
                                                             "</button>" +
                                                             "</td></tr>");
                })
            } else {
                alert("Something wrong! Try later");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    });
}