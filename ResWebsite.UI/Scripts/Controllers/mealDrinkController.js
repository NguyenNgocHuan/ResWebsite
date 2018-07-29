var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var mealDrinkController = {
    init: function () {
        mealDrinkController.loadData();
        mealDrinkController.registerEvent();
    },
    registerEvent: function () {
       
        $('#btnAddNew').off('click').on('click', function () {
            $('#roleAddUpdate').modal('show');
            mealDrinkController.resetForm();
        });
        $('#frmSaveData').validate({
            rules: {
                txtTenMon: {
                    required: true,
                    minlength: 5
                },
                txtMoTa: {
                    required: true,
                    minlength: 5
                }
            },
            messages: {
                txtTenMon: {
                    required: "Tên bắt buộc nhập",
                    minlength: "Chiều dài phải lớn hơn 5 ký tự"
                },
                txtMoTa: {
                    required: "Bắt buộc nhập tên món",
                    minlength: "Chiều dài phải lớn hơn 5 ký tự"
                }
            }
        });
        $('#btnGetAllMealDrinks').off('click').on('click', function () {
            mealDrinkController.loadData(true);
        });
        $('#btnGetAllMeals').off('click').on('click', function () {
            mealDrinkController.getMeals(true);
        });
        $('#btnGetAllDrinks').off('click').on('click', function () {
            mealDrinkController.getDrinks(true);
        });
        $('#btnSave').off('click').on('click', function () {
            alert("abc");
            if ($('#frmSaveData').valid()) {
                mealDrinkController.saveData();
            }
            
        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            mealDrinkController.resetForm(true);
            mealDrinkController.loadForm(true);
            mealDrinkController.loadDetail(id);
            $('#roleAddUpdate').modal('show');
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa món ăn hay thức uống này không ?",
                buttons: {
                    confirm: {
                        label: 'Có',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'Không',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    if(result==true){
                        console.log('Deleted mealdrink ' + id);
                        mealDrinkController.deleteMealDrink(id);
                    }else{
                        mealDrinkController.notify("Không xóa món ăn hay thức uống này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            mealDrinkController.loadDetailOfItem(id);
            $('#roleDetails').modal('show');
        });
        $('#btnSearch').off('click').on('click', function () {
            mealDrinkController.loadDataSearch(true);
        });
    },
    deleteMealDrink: function (id) {
        $.ajax({
            url: '/Admin/MealDrinks/DeleteMealDrink',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    mealDrinkController.notify("Xóa thành công !!!");
                    $('#roleAddUpdate').modal('hide');

                    mealDrinkController.loadData(true);
                    mealDrinkController.getMeals(true);
                    mealDrinkController.getDrinks(true);
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    loadDetailOfItem: function (id) {
        $.ajax({
            url: '/Admin/MealDrinks/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;
                    $('#hidIDDT').html(dataDetail.MealDrinkId);
                    $('#txtTenMenuDT').html(dataDetail.MenuName);
                    $('#txtTenMonDT').html(dataDetail.Name);
                    $('#txtDonGiaDT').html(dataDetail.Price);
                    $('#txtDonViDT').html(dataDetail.UnitName);
                    $('#txtHinhAnhDT').html(dataDetail.Picture);
                    $('#txtMoTaDT').html(dataDetail.Descriptions);
                    $("#imgImageDT").attr("src", dataDetail.Picture);
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    loadDetail: function (id) {
        $.ajax({
            url: '/Admin/MealDrinks/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;
                    $('#hidID').val(dataDetail.MealDrinkId);
                    $('#txtTenMenu').val(dataDetail.MenuId);
                    $('#txtTenMon').val(dataDetail.Name);
                    $('#txtDonGia').val(dataDetail.Price);
                    $('#txtDonVi').val(dataDetail.UnitId);
                    $('#txtHinhAnh').val(dataDetail.Picture);
                    $('#txtMoTa').val(dataDetail.Descriptions);
                    $("#imgImage").attr("src", dataDetail.Picture);
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    loadForm: function () {
        $.ajax({
            url: '/Admin/MealDrinks/LoadForm',
            data: {
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                $('#txtTenMenu').html('');
                $('#txtDonVi').html('');
                $.each(response.listMealDrinkType, function (index, value) {
                    $('#txtTenMenu').append(
                        "<option value='"+value.MenuId+"'>"+value.MenuName+"</option>"
                        );
                });
                $.each(response.listUnit, function (index, value) {
                    $('#txtDonVi').append(
                        "<option value='" + value.UnitId + "'>" + value.UnitName + "</option>"
                        );
                });
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    saveData: function () {
        var menuId = $('#txtTenMenu').val();
        var tenMon = $('#txtTenMon').val();
        var donGia = $('#txtDonGia').val();
        var donViId = $('#txtDonVi').val();
        var hinhAnh = $('#txtHinhAnh').val();
        var menuId = $('#txtTenMenu').val();
        var moTa = $('#txtMoTa').val();
        var id = $('#hidID').val();
        var mealDrink = {
            MenuId: menuId,
            Name: tenMon,
            Descriptions: moTa,
            Price: donGia,
            UnitId: donViId,
            Picture:hinhAnh,
            MealDrinkId: id
        }
        $.ajax({
            url: '/Admin/MealDrinks/SaveData',
            data: {
                strMealDrink: JSON.stringify(mealDrink)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    mealDrinkController.notify("Cập nhật thành công !!!");
                    $('#roleAddUpdate').modal('hide');
                    
                            mealDrinkController.loadData(true);
                            mealDrinkController.getMeals(true);
                            mealDrinkController.getDrinks(true);
                            
                    
                }
                else {
                    alert(response.message);
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    resetForm: function () {
        $('#hidID').val('0');
        mealDrinkController.loadForm(true);
        $('#txtTenMon').val('');
        $('#txtDonGia').val(0);
        $('#txtMoTa').val('');
        $('#txtHinhAnh').val('');
        $("#imgImage").attr("src", '');
    },
   getMeals:function() {
    $.ajax({
        method: "GET",
        url: '/Admin/MealDrinks/Meals',
        data: {
            page: homeConfig.pageIndex,
            pageSize: homeConfig.pageSize
        },
        success: function (response) {
            $('#listAction').html('');
            $.each(response.data, function (index, value) {
                $('#listAction').append(
                    "<tr>"
                    +
                    "<td>"
                    + value.MenuName +
                    "</td>"
                    +
                    "<td>"
                    + value.Name +
                    "</td>"
                    +
                    "<td>"
                    + value.Descriptions +
                    "</td>"
                    +
                    "<td>"
                    + value.Price +
                    "</td>"
                    +
                    "<td>"
                    + value.UnitName +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<img src='"+value.Picture+"' width='50px' height='50px'>"
                    +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<button class='btn btn-default btn-edit' data-id='"+value.MealDrinkId+"'>Sửa</button>"
                    +
                    "<button class='btn btn-default btn-delete' data-id='" + value.MealDrinkId + "'>Xóa</button>"
                    +
                    "</td>"
                    +
                    "</tr>");
            });
            mealDrinkController.pagingMeal(response.total, function () {
                mealDrinkController.getMeals();
            });
            mealDrinkController.registerEvent();
        }
    })
},
getDrinks:function (action) {
    $.ajax({
        method: "GET",
        url: '/Admin/MealDrinks/Drinks',
        data: {
            page: homeConfig.pageIndex,
            pageSize: homeConfig.pageSize
        },
        success: function (response) {
            $('#listDrink').html('');
            $.each(response.data, function (index, value) {
                $('#listDrink').append(
                    "<tr>"
                    +
                    "<td>"
                    + value.MenuName +
                    "</td>"
                    +
                    "<td>"
                    + value.Name +
                    "</td>"
                    +
                    "<td>"
                    + value.Descriptions +
                    "</td>"
                    +
                    "<td>"
                    + value.Price +
                    "</td>"
                    +
                    "<td>"
                    + value.UnitName +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<img src='" + value.Picture + "' width='50px' height='50px'>"
                    +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<button class='btn btn-default btn-edit' data-id='" + value.MealDrinkId + "'>Sửa</button>"
                    +
                    "<button class='btn btn-default btn-delete' data-id='" + value.MealDrinkId + "'>Xóa</button>"
                    +
                    "</td>"
                    +
                    "</tr>");
            });
            mealDrinkController.pagingDrink(response.total, function () {
                mealDrinkController.getDrinks();
            });
            mealDrinkController.registerEvent();
        }
    })
},
loadData: function (changePageSize) {
    $.ajax({
        type: "GET",
        async: true,
        url: "/Admin/MealDrinks/LoadData",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            page: homeConfig.pageIndex,
            pageSize: homeConfig.pageSize
        },
            success: function (response) {
                $('#listMealDrinks').html('');
                $.each(response.data, function (index, value) {
                    $('#listMealDrinks').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.MenuName +
                        "</td>"
                        +
                        "<td>"
                        + value.Name +
                        "</td>"
                        +
                        "<td>"
                        + value.Descriptions +
                        "</td>"
                        +
                        "<td>"
                        + value.Price +
                        "</td>"
                        +
                        "<td>"
                        + value.UnitName +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<img src='" + value.Picture + "' width='50px' height='50px'>"
                        +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MealDrinkId + "'>Sửa</button>"
                      
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MealDrinkId + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                mealDrinkController.paging(response.total, function () {
                    mealDrinkController.loadData();
                }, changePageSize);
                mealDrinkController.registerEvent();
            }
        })
},
loadDataSearch: function (changePageSize) {
    var information = $('#txtInformationSearch').val();
    $.ajax({
        type:'GET',
        url: '/Admin/MealDrinks/Search',
        dataType: 'json',
        data: {
            page: homeConfig.pageIndex,
            pageSize: homeConfig.pageSize,
            information:information
        },
        success: function (response) {
            $('#listMealDrinks').html('');
            $.each(response.data, function (index, value) {
                $('#listMealDrinks').append(
                    "<tr>"
                    +
                    "<td>"
                    + value.MenuName +
                    "</td>"
                    +
                    "<td>"
                    + value.Name +
                    "</td>"
                    +
                    "<td>"
                    + value.Descriptions +
                    "</td>"
                    +
                    "<td>"
                    + value.Price +
                    "</td>"
                    +
                    "<td>"
                    + value.UnitName +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<img src='" + value.Picture + "' width='50px' height='50px'>"
                    +
                    "</td>"
                    +
                    "<td>"
                    +
                    "<button class='btn btn-default btn-edit' data-id='" + value.MealDrinkId + "'>Sửa</button>"

                    +
                    "<button class='btn btn-default btn-delete' data-id='" + value.MealDrinkId + "'>Xóa</button>"
                    +
                    "</td>"
                    +
                    "</tr>");
            });
            mealDrinkController.paging(response.total, function () {
                mealDrinkController.loadDataSearch(true);
            },changePageSize);
            mealDrinkController.registerEvent();
        }
    })
},
    pagingMeal: function (totalRow, callback, changePageSize) {
        //ceil làm tròn
        var totalPage = Math.ceil(totalRow / homeConfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination2 a').length === 0 || changePageSize === true) {
            $('#pagination2').empty();
            $('#pagination2').removeData("twbs-pagination");
            $('#pagination2').unbind("page");
        }
        $('#pagination2').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            prev: "Trước",
            last: "Cuối",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeConfig.pageIndex = page;
                setTimeout(callback, 100);
            }
        });
    },

    pagingDrink: function (totalRow, callback, changePageSize) {
        //ceil làm tròn
        var totalPage = Math.ceil(totalRow / homeConfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination3 a').length === 0 || changePageSize === true) {
            $('#pagination3').empty();
            $('#pagination3').removeData("twbs-pagination");
            $('#pagination3').unbind("page");
        }
        $('#pagination3').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            prev: "Trước",
            last: "Cuối",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeConfig.pageIndex = page;
                setTimeout(callback, 100);
            }
        });
    },

    notify:function(message){
        $.notify(message, {
            animate: {
                enter: 'animated bounceIn',
                exit: 'animated bounceOut'
            }
        });
        },
    paging: function (totalRow, callback, changePageSize) {
        //ceil làm tròn
        var totalPage = Math.ceil(totalRow / homeConfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            prev: "Trước",
            last: "Cuối",
            visiblePages: 10,
            onPageClick: function (event, page) {
                homeConfig.pageIndex = page;
                setTimeout(callback, 100);
            }
        });
    }

}
mealDrinkController.init();