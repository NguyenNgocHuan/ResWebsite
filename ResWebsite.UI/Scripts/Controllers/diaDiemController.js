var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var diaDiemController = {
    init: function () {
        diaDiemController.loadData();
        diaDiemController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemDiaDiem').off('click').on('click', function () {
            diaDiemController.resetForm();
            $('#themDiaDiem').modal('show');

        });
        $('#btnSave').off('click').on('click', function () {
            //if ($('#frmSaveData').valid()) {
            //    nhanVienController.saveData();
            //}
            diaDiemController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            if ($('#frmXemDiaDiem').valid()) {
                diaDiemController.updateDiaDiem(id);
            }

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            diaDiemController.registerEvent();
            $("#frmXemDiaDiem :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            diaDiemController.resetForm();
            diaDiemController.loadDetail(id);
            $('#xemDiaDiem').modal('show');
            $("#frmXemDiaDiem :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            diaDiemController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa địa điểm này không ?",
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
                        console.log('Deleted Địa điểm ' + id);
                        diaDiemController.deleteDiaDiem(id);
                    } else {
                        diaDiemController.notify("Không xóa địa điểm này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            diaDiemController.resetForm();
            diaDiemController.loadDetail(id);
            $('#xemDiaDiem').modal('show');
            $("#frmXemDiaDiem :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            diaDiemController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            diaDiemController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            diaDiemController.loadData(true);
        });
    },
    deleteDiaDiem: function (id) {
        $.ajax({
            url: '/Admin/DiaDiems/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    diaDiemController.notify("Xóa thành công !!!");
                    diaDiemController.loadData(true);
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
    updateDiaDiem: function (id) {
        var maDiaDiem = id;
        var tenDiaDiem = $('#txtTenDiaDiemX').val();
        var hinhAnh = $("#txtHinhAnhX").val();
        var khuVuc = $('#txtKhuVucX').val();
        var giaTien = $('#txtGiaTienX').val();
        var soChoNgoi = $('#txtSoChoNgoiX').val();
        var soChoConLai = $('#txtSoChoConLaiX').val();
        var trangThai = $("input:radio[name=rdoTrangThaiX]:checked").val();
        var diaDiem = {
            MaDiaDiem: maDiaDiem,
            TenDiaDiem: tenDiaDiem,
            HinhAnh: hinhAnh,
            KhuVuc: khuVuc,
            GiaTien: giaTien,
            SoChoNgoi: soChoNgoi,
            SoChoConLai: soChoConLai,
            TrangThai: trangThai,
        }
        $.ajax({
            url: '/Admin/DiaDiems/CapNhat',
            data: {
                strDiaDiem: JSON.stringify(diaDiem)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemDiaDiem').modal('hide');
                    diaDiemController.notify("Cập nhật địa điểm thành công !!!");
                    diaDiemController.loadData(true);
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
            url: '/Admin/DiaDiems/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenDiaDiemX').val(dataDetail.TenDiaDiem);
                    $('#idTemp').val(dataDetail.MaDiaDiem);
                    $('#txtKhuVucX').val(dataDetail.KhuVuc);
                    $('#txtGiaTienX').val(dataDetail.GiaTien);
                    $('#txtHinhAnhX').val(dataDetail.HinhAnh);
                    $("#imgImageX").attr("src", dataDetail.HinhAnh);
                    if (dataDetail.TrangThai === "Đang sử dụng") {
                        $('input[id="rdoDangSuDungX"]').prop('checked', true);
                        $('input[id="rdoNgungSuDungX"]').prop('checked', false);
                    }
                    else {
                        $('input[id="rdoDangSuDungX"]').prop('checked', false);
                        $('input[id="rdoNgungSuDungX"]').prop('checked', true);
                    }
                    $('#txtSoChoNgoiX').val(dataDetail.SoChoNgoi);
                    $('#txtSoChoConLaiX').val(dataDetail.SoChoConLai);

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
        var tenDiaDiem = $('#txtTenDiaDiem').val();
        var hinhAnh = $("#txtHinhAnh").val();
        var khuVuc = $('#txtKhuVuc').val();
        var giaTien = $('#txtGiaTien').val();
        var soChoNgoi = $('#txtSoChoNgoi').val();
        var soChoConLai = $('#txtSoChoConLai').val();
        var trangThai = $("input:radio[name=rdoTrangThai]:checked").val();
        var diaDiem = {
            MaDiaDiem: "",
            TenDiaDiem: tenDiaDiem,
            KhuVuc: khuVuc,
            GiaTien: giaTien,
            SoChoConLai: soChoConLai,
            SoChoNgoi: soChoNgoi,
            HinhAnh: hinhAnh,
            TrangThai: trangThai,
        }
        $.ajax({
            url: '/Admin/DiaDiems/SaveData',
            data: {
                strDiaDiem: JSON.stringify(diaDiem)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themDiaDiem').modal('hide');
                    diaDiemController.notify("Thêm mới địa điểm thành công !!!");
                    diaDiemController.loadData(true);
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
        $('#txtTenDiaDiemX').val("");
        $('#idTemp').val("");
        $('#txtKhuVucX').val("");
        $('#txtGiaTienX').val("");
        $('#txtHinhAnhX').val("");
        $('#txtSoChoNgoiX').val("");
        $('#txtSoChoConLaiX').val("");
        $('input[name="rdoTrangThaiX"]').prop('checked', false);
        $("#imgImageX").attr("src", "");

        $('#txtTenDiaDiem').val("");
        $('#txtKhuVuc').val("");
        $('#txtGiaTien').val("");
        $('#txtHinhAnh').val("");
        $('#txtSoChoNgoi').val("");
        $('#txtSoChoConLai').val("");
        $("#imgImage").attr("src", "");
        $('input[name="rdoTrangThai"]').prop('checked', false);
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/DiaDiems/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listDiaDiems').html('');
                $.each(response.data, function (index, value) {
                    
                    $('#listDiaDiems').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenDiaDiem +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                        +
                        "</td>"
                        +
                        "<td>"
                        + value.KhuVuc +
                        "</td>"
                        +
                        "<td>"
                        + value.GiaTien +
                        "</td>"
                        +

                        "<td>"
                        + value.SoChoNgoi +
                        "</td>"
                        +

                        "<td>"
                        + value.SoChoConLai +
                        "</td>"
                        +
                        "<td>"
                        + value.TrangThai +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaDiaDiem + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaDiaDiem + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaDiaDiem + "'>Xóa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                diaDiemController.paging(response.total, function () {
                    diaDiemController.loadData();
                }, changePageSize);
                diaDiemController.registerEvent();
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
                    $('#listDiaDiems').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.TenDiaDiem +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                         +
                         "</td>"
                         +
                         "<td>"
                         + value.KhuVuc +
                         "</td>"
                         +
                         "<td>"
                         + value.GiaTien +
                         "</td>"
                         +

                         "<td>"
                         + value.SoChoNgoi +
                         "</td>"
                         +

                         "<td>"
                         + value.SoChoConLai +
                         "</td>"
                         +
                         "<td>"
                         + value.TrangThai +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaDiaDiem + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaDiaDiem + "'>Sửa</button>"
                         +
                         "<button class='btn btn-default btn-delete' data-id='" + value.MaDiaDiem + "'>Xóa</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                diaDiemController.paging(response.total, function () {
                    diaDiemController.search();
                }, changePageSize);
                diaDiemController.registerEvent();
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
diaDiemController.init();