function SearchMealId(id) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/SearchMeal",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            mealId: id,
            placeId: $("#placeID").text(),
            quantity: $(".quantitymeal").val(),
            note: $(".note").val(),
        },
        success: function (data) {
            $("#mealTable tbody").html("");
            var num = 1;
            if (data != null) {
                $.each(data, function (key, i) {

                    $("#mealTable tbody").append("<tr><td>" + num + "</td>" +
                                                             "<td>" + i.Name + "</td>" +
                                                             "<td>" + i.Quantity + "</td>" +
                                                             "<td>" + i.Price + "</td>" +
                                                             "<td>" + i.note + "</td>" +
                                                             "<td>" +
                                                             "<button class='btn btn-danger' onclick='DelMealOD(" + i.orderId + ", " + '"' + i.id + '"' + ");'>" +
                                                             "<i class='fa fa-pencil'></i>" +
                                                             "</button>" +
                                                             "</td></tr>");
                    num += 1;


                })
            } else {
                alert("Not found!");
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    });
}
function AddOrder(placeid) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/AddNewOrder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            placeId: placeid,
            employeeId: 1
        },
        success: function (data) {
            if (data != -1) {
                $("#orderID").text(data);
                LoadPlaceList();
            } else {
                alert("Loi khi them order");
            }
            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi thêm order!" + errorThrown);
        }
    })
}
function Checkout(id) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/CheckOut",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            placeId: id,
        },
        success: function (data) {
            alert(data);
            LoadPlaceList();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    })
}
function PrintOrder(id) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/PrintOrderDetail",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            placeId: id
        },
        success: function (data) {
            var list = "---HOA DON---\n";
            list += "---Danh sach mon an---\n";
            var n = 1;
            var total = 0;
            $.each(data[1], function (key, i) {
                total += i.Price * i.Quantity;
                list += "ID: " + i.MealDrinkId + "- Gia: "  + i.Price +"*"+ i.Quantity + "\n";
            })
            list += "----Danh sach dich vu-----\n";
            $.each(data[2], function (key, i) {
                total += i.Price * i.Quantity;
                list += "ID: " + i.ServiceId + "- Gia: " + i.Price + "*" + i.Quantity + "\n";
            })
            list += "---------------\nTotal: " + total;
                alert(list);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    });
    

}
function ShowList(id) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/ShowOrderDetailList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            placeId: id
        },
        success: function (data) {
            var num = 1;
            $.each(data, function (key, i) {
                var id = i.MealDrinkId;
                $("#mealTable tbody").append("<tr><td>" + num + "</td>" +
                                         "<td>" + i.id + "</td>" +
                                         "<td>" + i.Quantity + "</td>" +
                                         "<td>" + i.Price + "</td>" +
                                         "<td>" + i.note + "</td>" +
                                         "<td>" +
                                         "<button class='btn btn-danger' onclick='DelMealOD(" + i.orderId + "," + '"' + i.id + '"' + ");'>" +
                                         "<i class='fa fa-pencil'></i>" +
                                         "</button>" +
                                         "</td></tr>");
                num += 1;
            })
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    });
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/ShowServiceOrderDetailList",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            placeId: id
        },
        success: function (data) {
            $("#serviceTable tbody").html("");
            $.each(data, function (key, i) {
                $("#serviceTable tbody").append("<tr>"+
                                         "<td>" + i.ServiceId + "</td>" +
                                         "<td>" + i.Quantity + "</td>" +
                                         "<td>" + i.Price + "</td>" +
                                         "<td>" + i.Note + "</td>" +
                                         "<td>" +
                                         "<button class='btn btn-danger' onclick='DelServiceOD(" + i.OrderId + ", "+'"'+ i.ServiceId + '"'+");'>" +
                                         "<i class='fa fa-pencil'></i>" +
                                         "</button>" +
                                         "</td></tr>");
            })
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Lỗi!" + errorThrown);
        }
    });
}
function DelMealOD(oid, mid) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Staff/Order/DeleteMealDrinkFromListOrder",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            orderId: oid,
            mealId:mid
        },
        success: function (data) {
            $("#mealTable tbody").html("");
            var num = 1;
            if (data != null) {
                $.each(data, function (key, i) {

                    $("#mealTable tbody").append("<tr><td>" + num + "</td>" +
                                                             "<td>" + i.id + "</td>" +
                                                             "<td>" + i.Quantity + "</td>" +
                                                             "<td>" + i.Price + "</td>" +
                                                             "<td>" + i.note + "</td>" +
                                                             "<td>" +
                                                             "<button class='btn btn-danger' onclick='DelMealOD(" + i.orderId + ", " + '"' + i.id + '"' + ");'>" +
                                                             "<i class='fa fa-pencil'></i>" +
                                                             "</button>" +
                                                             "</td></tr>");
                    num += 1;


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