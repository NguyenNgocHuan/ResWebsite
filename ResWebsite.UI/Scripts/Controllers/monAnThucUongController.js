var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var monAnThucUongController = {
    init: function () {
        monAnThucUongController.loadData();
        monAnThucUongController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemMonAnThucUong').off('click').on('click', function () {
            monAnThucUongController.resetForm();
            //monAnThucUongController.loadForm();
            $('#themMonAnThucUong').modal('show');

        });
        $('#btnSave').off('click').on('click', function () {
            //if ($('#frmSaveData').valid()) {
            //    nhanVienController.saveData();
            //}
            monAnThucUongController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            if ($('#frmXemMonAnThucUong').valid()) {
                monAnThucUongController.updateMonAnThucUong(id);
            }

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            monAnThucUongController.registerEvent();
            $("#frmXemMonAnThucUong :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            monAnThucUongController.resetForm();
           //monAnThucUongController.loadForm(true);
            monAnThucUongController.loadDetail(id);
            $('#xemMonAnThucUong').modal('show');
            $("#frmXemMonAnThucUong :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            monAnThucUongController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa món ăn hoặc thức uống này không ?",
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
                    if (result == true) {
                        console.log('Deleted Món ăn thức uống ' + id);
                        monAnThucUongController.deleteMonAnThucUong(id);
                    } else {
                        monAnThucUongController.notify("Không xóa món ăn hoặc thức uống này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            monAnThucUongController.resetForm();
            //monAnThucUongController.loadForm(true);
            monAnThucUongController.loadDetail(id);
            $('#xemMonAnThucUong').modal('show');
            $("#frmXemMonAnThucUong :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            monAnThucUongController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            monAnThucUongController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            monAnThucUongController.loadData(true);
        });
    },
    deleteMonAnThucUong: function (id) {
        $.ajax({
            url: '/Admin/MonAnThucUongs/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    monAnThucUongController.notify("Xóa thành công !!!");
                    monAnThucUongController.loadData(true);
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
    updateMonAnThucUong: function (id) {
        var maMonAnThucUong = id;
        var tenMonAnThucUong = $('#txtTenMonAnThucUongX').val();
        var donGia = $("#txtDonGiaX").val();
        var donVi = $("#txtDonViX").val();
        var hinhAnh = $('#txtHinhAnhX').val();
        var phanLoai = $('#txtPhanLoaiX').val();
        var monAnThucUong = {
            MaMonAnThucUong: maMonAnThucUong,
            TenMonAnThucUong: tenMonAnThucUong,
            DonGia: donGia,
            DonVi: donVi,
            HinhAnh: hinhAnh,
            PhanLoai: phanLoai,
        }
        $.ajax({
            url: '/Admin/MonAnThucUongs/CapNhat',
            data: {
                strMonAnThucUong: JSON.stringify(monAnThucUong)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemMonAnThucUong').modal('hide');
                    monAnThucUongController.notify("Cập nhật món ăn thức uống thành công !!!");
                    monAnThucUongController.loadData(true);
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
    //loadForm: function (id) {
    //    $.ajax({
    //        url: '/Admin/MonAnThucUongs/LoadForm',
    //        data: {
    //            id: id
    //        },
    //        type: 'GET',
    //        dataType: 'json',
    //        success: function (response) {
    //            if (response.status) {
    //                $('#txtThucDon').html('<option value="" >' + "Chọn thực đơn" + '</option>');
    //                $('#txtThucDonX').html('<option value="" >' + "Chọn thực đơn" + '</option>');
    //                $.each(response.data, function (index, value) {
    //                    $('#txtThucDon').append(
    //                             "<option value='" + value.MaThucDon + "'>" + value.TenThucDon + "</option>"
    //                             );
    //                    $('#txtThucDonX').append(
    //                            "<option value='" + value.MaThucDon + "'>" + value.TenThucDon + "</option>"
    //                            );
    //                });
    //            }
    //            else {
    //                alert(response.message);
    //            }
    //        },
    //        error: function (err) {
    //            console.log(err);
    //        }
    //    })
    //},
    loadDetail: function (id) {
        $.ajax({
            url: '/Admin/MonAnThucUongs/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenMonAnThucUongX').val(dataDetail.TenMonAnThucUong);
                    $('#idTemp').val(dataDetail.MaMonAnThucUong);
                    $('#txtDonGiaX').val(response.donGia);
                    $('#txtDonViX').val(dataDetail.DonVi);
                    $('#txtHinhAnhX').val(dataDetail.HinhAnh);
                    $('#txtPhanLoaiX').val(dataDetail.PhanLoai);
                    $('#imgImageX').val(dataDetail.HinhAnh);
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
    saveData: function () {
        var tenMonAnThucUong = $('#txtTenMonAnThucUong').val();
        var donGia = $("#txtDonGia").val();
        var donVi = $("#txtDonVi").val();
        var hinhAnh = $('#txtHinhAnh').val();
        var phanLoai = $('#txtPhanLoai').val();
        var monAnThucUong = {
            MaMonAnThucUong: "",
            TenMonAnThucUong: tenMonAnThucUong,
            DonGia: donGia,
            DonVi: donVi,
            HinhAnh: hinhAnh,
            PhanLoai: phanLoai,
        }
        $.ajax({
            url: '/Admin/MonAnThucUongs/SaveData',
            data: {
                strMonAnThucUong: JSON.stringify(monAnThucUong)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themMonAnThucUong').modal('hide');
                    monAnThucUongController.notify("Thêm mới món ăn thức uống thành công !!!");
                    monAnThucUongController.loadData(true);
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
        $('#txtTenMonAnThucUong').val("");
        $('#txtDonGia').val("");
        $('#txtDonVi').val("");
        $('#txtHinhAnh').val("");
        $('#txtPhanLoai').val("");
        $('#imgImage').val("");
        

        $('#txtTenMonAnThucUongX').val("");
        $('#txtDonGiaX').val("");
        $('#txtDonViX').val("");
        $('#txtHinhAnhX').val("");
        $('#txtPhanLoaiX').val("");
        $('#imgImageX').val("");
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/MonAnThucUongs/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listMonAnThucUongs').html('');
                $.each(response.data, function (index, value) {
                    $('#listMonAnThucUongs').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenMonAnThucUong +
                        "</td>"
                        +
                        "<td>"
                        + value.DonGia +
                        "</td>"
                        +
                        "<td>"
                        + value.DonVi +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                        +
                        "</td>"
                        +
                        "<td>"
                        + value.PhanLoai +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaMonAnThucUong + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaMonAnThucUong + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaMonAnThucUong + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                monAnThucUongController.paging(response.total, function () {
                    monAnThucUongController.loadData();
                }, changePageSize);
                monAnThucUongController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/MonAnThucUongs/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listMonAnThucUongs').html('');
                $.each(response.data, function (index, value) {
                    $('#listMonAnThucUongs').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.TenMonAnThucUong +
                         "</td>"
                         +
                         "<td>"
                         + value.DonGia +
                         "</td>"
                         +
                         "<td>"
                         + value.DonVi +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                         +
                         "</td>"
                         +
                         "<td>"
                         + value.PhanLoai +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaMonAnThucUong + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaMonAnThucUong + "'>Sửa</button>"
                         +
                         "<button class='btn btn-default btn-delete' data-id='" + value.MaMonAnThucUong + "'>Xóa</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                monAnThucUongController.paging(response.total, function () {
                    monAnThucUongController.search();
                }, changePageSize);
                monAnThucUongController.registerEvent();
            }
        })
    },
    notify: function (message) {
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
monAnThucUongController.init();