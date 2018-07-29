var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var caLamViecController = {
    init: function () {
        caLamViecController.loadData();
        caLamViecController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemCaLamViec').off('click').on('click', function () {
            caLamViecController.resetForm();
            $('#themCaLamViec').modal('show');

        });
        $('#btnSave').off('click').on('click', function () {
            caLamViecController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            caLamViecController.updateCaLamViec(id);
            

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            caLamViecController.registerEvent();
            $("#frmXemCaLamViec :input").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            caLamViecController.resetForm();
            caLamViecController.loadDetail(id);
            $('#xemCaLamViec').modal('show');
            $("#frmXemCaLamViec :input").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            caLamViecController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa ca làm việc này không ?",
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
                        console.log('Deleted ca làm việc' + id);
                        caLamViecController.deleteCaLamViec(id);
                    } else {
                        caLamViecController.notify("Không xóa ca làm việc này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            caLamViecController.resetForm();
            caLamViecController.loadDetail(id);
            $("#frmXemCaLamViec:input").prop("disabled", true);
            $('#xemCaLamViec').modal('show');
            
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            caLamViecController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            caLamViecController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            caLamViecController.loadData(true);
        });
    },
    deleteCaLamViec: function (id) {
        $.ajax({
            url: '/Admin/CaLamViecs/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    caLamViecController.notify("Xóa thành công !!!");
                    caLamViecController.loadData(true);
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
    updateCaLamViec: function (id) {
        var maCaLamViec = id;
        var tenCaLamViec = $('#txtTenCaLamViecX').val();
        var thoiGianRa = $("#txtThoiGianRaX").val();
        var thoiGianVao = $('#txtThoiGianVaoX').val();
        var ghiChu = $('#txtGhiChuX').val();
        var caLamViec = {
            MaCaLamViec: maCaLamViec,
            TenCaLamViec: tenCaLamViec,
            ThoiGianRa: thoiGianRa,
            ThoiGianVao: thoiGianVao,
            GhiChu: ghiChu
        }
        $.ajax({
            url: '/Admin/CaLamViecs/CapNhat',
            data: {
                strCaLamViec: JSON.stringify(caLamViec)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemCaLamViec').modal('hide');
                    caLamViecController.notify("Cập nhật ca làm việc thành công !!!");
                    caLamViecController.loadData(true);
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
            url: '/Admin/CaLamViecs/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenCaLamViecX').val(dataDetail.TenCaLamViec);
                    $('#idTemp').val(dataDetail.MaCaLamViec);
                    $('#txtThoiGianRaX').val(dataDetail.ThoiGianRa);
                    $('#txtThoiGianVaoX').val(dataDetail.ThoiGianVao);
                    $('#txtGhiChuX').val(dataDetail.GhiChu);

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
        var tenCaLamViec = $('#txtTenCaLamViec').val();
        var thoiGianRa = $("#txtThoiGianRa").val();
        var thoiGianVao = $('#txtThoiGianVao').val();
        var ghiChu = $('#txtGhiChu').val();
        var caLamViec = {
            MaCaLamViec: "",
            TenCaLamViec: tenCaLamViec,
            ThoiGianRa: thoiGianRa,
            ThoiGianVao: thoiGianVao,
            GhiChu: ghiChu,
        }
        $.ajax({
            url: '/Admin/CaLamViecs/SaveData',
            data: {
                strCaLamViec: JSON.stringify(caLamViec)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themCaLamViec').modal('hide');
                    caLamViecController.notify("Thêm mới ca làm việc thành công !!!");
                    caLamViecController.loadData(true);
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
        $('#txtTenCaLamViecX').val("");
        $('#idTemp').val("");
        $('#txtThoiGianRaX').val("");
        $('#txtThoiGianVaoX').val("");
        $('#txtGhiChuX').val("");

        $('#txtTenCaLamViec').val("");
        $('#txtThoiGianRa').val("");
        $('#txtThoiGianVao').val("");
        $('#txtGhiChu').val("");
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/CaLamViecs/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listCaLamViecs').html('');
                $.each(response.data, function (index, value) {

                    $('#listCaLamViecs').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenCaLamViec +
                        "</td>"
                        +
                        "<td>"
                        + value.ThoiGianVao +
                        "</td>"
                        +
                        "<td>"
                        + value.ThoiGianRa +
                        "</td>"
                        +
                        "<td>"
                        + value.GhiChu +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaCaLamViec + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaCaLamViec + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaCaLamViec + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                caLamViecController.paging(response.total, function () {
                    caLamViecController.loadData();
                }, changePageSize);
                caLamViecController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/CaLamViecs/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listDiaDiems').html('');
                $.each(response.data, function (index, value) {
                    $('#listCaLamViecs').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenCaLamViec +
                        "</td>"
                        +
                        "<td>"
                        + value.ThoiGianVao +
                        "</td>"
                        +
                        "<td>"
                        + value.ThoiGianRa +
                        "</td>"
                        +
                        "<td>"
                        + value.GhiChu +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaCaLamViec + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaCaLamViec + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaCaLamViec + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                caLamViecController.paging(response.total, function () {
                    caLamViecController.search();
                }, changePageSize);
                caLamViecController.registerEvent();
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
caLamViecController.init();