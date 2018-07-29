var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var dichVuController = {
    init: function () {
        dichVuController.loadData();
        dichVuController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemDichVu').off('click').on('click', function () {
            dichVuController.resetForm();
            $('#themDichVu').modal('show');

        });
        $('#btnSave').off('click').on('click', function () {
            //if ($('#frmSaveData').valid()) {
            //    nhanVienController.saveData();
            //}
            dichVuController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            if ($('#frmXemDichVu').valid()) {
                dichVuController.updateDichVu(id);
            }

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            dichVuController.registerEvent();
            $("#frmXemDichVu :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            dichVuController.resetForm();
            dichVuController.loadDetail(id);
            $('#xemDichVu').modal('show');
            $("#frmXemDichVu :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            dichVuController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa dịch vụ này không ?",
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
                        console.log('Deleted dịch vụ ' + id);
                        dichVuController.deleteDichVu(id);
                    } else {
                        dichVuController.notify("Không xóa dịch vụ này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            dichVuController.resetForm();
            dichVuController.loadDetail(id);
            $('#xemDichVu').modal('show');
            $("#frmXemDichVu :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            dichVuController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            dichVuController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            dichVuController.loadData(true);
        });
    },
    deleteDichVu: function (id) {
        $.ajax({
            url: '/Admin/DichVus/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    dichVuController.notify("Xóa thành công !!!");
                    dichVuController.loadData(true);
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
    updateDichVu: function (id) {
        var maDichVu = id;
        var tenDichVu = $('#txtTenDichVuX').val();
        var loaiDichVu = $('#txtLoaiDichVuX').val();
        var giaTien = $('#txtGiaTienX').val();
        var trangThai = $("input:radio[name=rdoTrangThaiX]:checked").val();
        var dichVu = {
            MaDichVu: maDichVu,
            TenDichVu: tenDichVu,
            LoaiDichVu: loaiDichVu,
            GiaTien: giaTien,
            TrangThai: trangThai,
        }
        $.ajax({
            url: '/Admin/DichVus/CapNhat',
            data: {
                strDichVu: JSON.stringify(dichVu)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemDichVu').modal('hide');
                    dichVuController.notify("Cập nhật dịch vụ thành công !!!");
                    dichVuController.loadData(true);
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
            url: '/Admin/DichVus/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenDichVuX').val(dataDetail.TenDichVu);
                    $('#idTemp').val(dataDetail.MaDichVu);
                    $('#txtLoaiDichVuX').val(dataDetail.LoaiDichVu);
                    $('#txtGiaTienX').val(dataDetail.GiaTien);
                    if (dataDetail.TrangThai === "Đang sử dụng") {
                        $('input[id="rdoDangSuDungX"]').prop('checked', true);
                        $('input[id="rdoNgungSuDungX"]').prop('checked', false);
                    }
                    else {
                        $('input[id="rdoDangSuDungX"]').prop('checked', false);
                        $('input[id="rdoNgungSuDungX"]').prop('checked', true);
                    }
                    

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

        var tenDichVu = $('#txtTenDichVu').val();
        var loaiDichVu = $('#txtLoaiDichVu').val();
        var giaTien = $('#txtGiaTien').val();
        var trangThai = $("input:radio[name=rdoTrangThai]:checked").val();
        var dichVu = {
            MaDichVu: "",
            TenDichVu: tenDichVu,
            LoaiDichVu: loaiDichVu,
            GiaTien: giaTien,
            TrangThai: trangThai,
        }
        $.ajax({
            url: '/Admin/DichVus/SaveData',
            data: {
                strDichVu: JSON.stringify(dichVu)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themDichVu').modal('hide');
                    dichVuController.notify("Thêm mới dịch vụ thành công !!!");
                    dichVuController.loadData(true);
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
        $('#txtTenDichVuX').val("");
        $('#txtLoaiDichVuX').val("");
        $('#txtGiaTienX').val("");
        $('#idTemp').val("");
        $('input[name="rdoTrangThaiX"]').prop('checked', false);

        $('#txtTenDichVu').val("");
        $('#txtLoaiDichVu').val("");
        $('#txtGiaTien').val("");
        $('#idTemp').val("");
        $('input[name="rdoTrangThai"]').prop('checked', false);

       
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/DichVus/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listDichVus').html('');
                $.each(response.data, function (index, value) {

                    $('#listDichVus').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenDichVu +
                        "</td>"
                        +
                        "<td>"
                        + value.GiaTien +
                        "</td>"
                        +
                        "<td>"
                        + value.LoaiDichVu +
                        "</td>"
                        +
                        "<td>"
                        + value.TrangThai +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaDichVu + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaDichVu + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaDichVu + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                dichVuController.paging(response.total, function () {
                    dichVuController.loadData();
                }, changePageSize);
                dichVuController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/DiaDiems/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listDiaDiems').html('');
                $.each(response.data, function (index, value) {
                    $('#listDichVus').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.TenDichVu +
                         "</td>"
                         +
                         "<td>"
                         + value.GiaTien +
                         "</td>"
                         +
                         "<td>"
                         + value.LoaiDichVu +
                         "</td>"
                         +
                         "<td>"
                         + value.TrangThai +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaDichVu + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaDichVu + "'>Sửa</button>"
                         +
                         "<button class='btn btn-default btn-delete' data-id='" + value.MaDichVu + "'>Xóa</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                dichVuController.paging(response.total, function () {
                    dichVuController.search();
                }, changePageSize);
                dichVuController.registerEvent();
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
dichVuController.init();