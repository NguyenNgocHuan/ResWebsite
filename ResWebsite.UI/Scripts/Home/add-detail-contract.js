function AddMealDetail(mealid) {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Contract/AddMealDrinkDetail",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            mealid: mealid,
            note: "",
            contractId: $("#a").text(),
        },
        success: function (data) {
            $(".mealmessage").html(data[0]);
            if ($(".mealmessage div").hasClass('alert')) {
                $(".mealmessage div").delay(2000).fadeOut(2000);
            }
            $("#total").val(data[1]);
            $("#deposit").val(parseInt(data[1]) * 15 / 100);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Xác nhận rằng đã chọn chỗ đặt trước!" + errorThrown);
        }
    })
}
function AddServiceDetail() {
    var val = [];
    $(':checkbox:checked').each(function (i) {
        //val[i] = $(this).val();
        $.ajax({
            type: "GET",
            async: false,
            url: "/Contract/AddServiceDetail",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                serviceId: $(this).val(),
                note: $("#other").val(),
                contractId: $("#a").text(),
            },
            success: function (data) {
                $(".servicemessage").html(data[0]);
                if ($(".servicemessage div").hasClass('alert')) {
                    $(".servicemessage div").delay(2000).fadeOut(2000);
                }
                $("#total").val(data[1]);
                $("#deposit").val(parseInt(data[1]) * 15 / 100);

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Xác nhận rằng đã chọn chỗ đặt trước! Please try later!" + errorThrown);
            }
        })
    });
    // $("input[type=checkbox]").on("click", function () { alert(n); });

    //$( "#log" ).html( $( "input:checked" ).val() + " is checked!" );
    //if($('input[name="check"]').is(':checked'))
    //{
    //  alert($(this).val());
    //}
}