
function LoadKhaiVi() {
    $(".khaivi").show();
    $(".monchinh").css('display', 'none');
    $(".trangmieng").css('display', 'none');
    $(".nuocuong").css('display', 'none');
}
function LoadMonChinh() {
    $(".khaivi").css('display', 'none');
    $(".monchinh").show();
    $(".trangmieng").css('display', 'none');
    $(".nuocuong").css('display', 'none');
}
function LoadTrangMieng() {
    $(".monchinh").css('display', 'none');
    $(".khaivi").css('display', 'none');
    $(".trangmieng").show();
    $(".nuocuong").css('display', 'none');
}
function LoadDrink() {
    $(".khaivi").css('display', 'none');
    $(".trangmieng").css('display', 'none');
    $(".nuocuong").show();
    $(".monchinh").css('display', 'none');
}
function LoadAllMeal() {
    $(".khaivi").show();
    $(".monchinh").show();
    $(".nuocuong").show();
    $(".trangmieng").show();
}
function ShowDetail(id) {

    $.ajax({
        type: "POST",
        async: false,
        url: "/Home/Detail",
        dataType: "json",
        data: {
            mealId: id
        },
        success: function (data) {
            $("#mealid").text(data.MealDrinkId);
            $("#name").text(data.Name);
            $("#des").text(data.Descriptions);
            $("#price").text(data.Price + " 000 VND");
            $("#pic").attr('src', data.Picture);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Some error to show detail! Please try later!" + errorThrown);
        }
    });

}
function MenuDetail(id) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/Home/ShowMenuDetailInfo",
        dataType: "json",
        data: {
            menuId: id
        },
        success: function (data) {
            $("#menudetail tbody").html("");
            var num = 1;
            var total = 0.0;
            $.each(data, function (key, i) {
                $("#menudetail tbody").append("<tr><td>"
                    + num + "</td>" +
                    "<td><img src='" + i.Picture + "' alt='" + i.Name + "' style='width:50px;height:50px'/></td>"
                    + "<td>" + i.Name + "</td>"
                    + "<td>" + i.Descriptions + "</td>"
                    + "<td>" + i.Price + "000 VND</td><tr>");
                getMealId(i.MealDrinkId, $("#noteformeal").val(), $("#table").text(), i.Price);
                total += i.Price;
                num++;
            });
            $("#menudetail tbody").append("<tr><td colspan='5'>Số bàn: "+$("#table").text()+" bàn</td></tr>" +
                "<tr><td colspan='5'>Tổng tiền thực đơn: " + total + "000 VND</td></tr>"+
                "<tr><td colspan='5' style='color:blue'>Tổng tiền thanh toán: <h3>" + total * parseInt($("#table").text()) + "000 VND</h3></td></tr>");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Some error to show detail! Please try later!" + errorThrown);
        }
    });

}
