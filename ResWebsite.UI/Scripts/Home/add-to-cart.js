function AddToCart(id, content) {
    $.ajax({
        type: "POST",
        async: false,
        url: "/Contract/AddMealDrinkToCart",
        dataType: "json",
        data: {
            mealId: id,
            note:content

        },
        success: function (data) {
            $("#contracid").text(data);
            //$("#tablecart tbody").html("");
            //var num = 1;
            //$.each(data, function (key, i) {
            //    $("#tablecart tbody").append(
            //            "<tr>"
            //            + "<td>" + num + "</td>"
            //            + "<td>" + i.Picture + "</td>"
            //            + "<td>" + i.MealName + "</td>"
            //            + "<td>" + i.Price + "</td>"
            //            + "<td>" + i.Quantity + " VND</td>"
            //            + "<td></td>"
            //            + "<td><button class='deletemeal' value=" + i.MealID + " onclick='deleteMeal($(this).val());'><i class='noti-icon material-icons'>add_circle_outline</i></button></td>"
            //            + "</tr>");
            //    num++;
            //})
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Some error to add to cart! Please try later!" + errorThrown);
        }
    });
}
function deleteMeal(id) {
    alert("ôk");
}