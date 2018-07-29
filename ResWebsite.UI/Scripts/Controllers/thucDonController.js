var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var thucDonController = {
    init: function () {
        thucDonController.loadData();
        thucDonController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemThucDon').off('click').on('click', function () {
            thucDonController.resetForm();
            $('#themThucDon').modal('show');
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSave'>" + "Lưu" + "</button>");

        });
        $('#btnThemMon').off('click').on('click', function () {
            thucDonController.LoadDataMonAnThucUongNew($('#btnThemMon').val(), true);
            $('#xemThucDon').modal('hide');
            $('#themChiTietThucDon').modal('show');
            
            // $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSave'>" + "Lưu" + "</button>");

        });
        $('#btnSave').off('click').on('click', function () {
            //if ($('#frmSaveData').valid()) {
            //    nhanVienController.saveData();
            //}
            thucDonController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            //if ($('#frmThucDon').valid()) {
            //    thucDonController.updateThucDon(id);
            //}
            thucDonController.updateThucDon(id);

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            thucDonController.registerEvent();
            $("#frmXemThucDon :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            $('#btnThemMon').val(id);
            thucDonController.loadDetail(id);
            $('#xemThucDon').modal('show');
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            thucDonController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa thực đơn này không ?",
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
                        console.log('Deleted thực đơn ' + id);
                        thucDonController.deleteThucDon(id);
                    } else {
                        thucDonController.notify("Không xóa thực đơn này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            $('#btnThemMon').val(id);
            thucDonController.loadDetail(id);
            $('#xemThucDon').modal('show');
            $("#frmXemThucDon :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            thucDonController.registerEvent();

        });
        $('.cbx-ChonMon').off('click').on('click', function () {
            var maMonAn = $(this).data('id');
            var maThucDon=$('#btnThemMon').val();
            thucDonController.updateChiTietThucDon(maThucDon, maMonAn);

        });
        $('#btnSearch').off('click').on('click', function () {
            thucDonController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            thucDonController.loadData(true);
        });
    },
    deleteThucDon: function (id) {
        $.ajax({
            url: '/Admin/ThucDons/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    thucDonController.notify("Xóa thành công !!!");
                    thucDonController.loadData(true);
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
    updateThucDon: function (id) {
        var maThucDon = id;
        var tenThucDon = $('#txtTenThucDonX').val();
        var loaiThucDon = $('#txtLoaiThucDonX').val();
        var thucDon = {
            MaThucDon: maThucDon,
            TenThucDon: tenThucDon,
            LoaiThucDon: loaiThucDon
        }
        $.ajax({
            url: '/Admin/ThucDons/CapNhat',
            data: {
                strThucDon: JSON.stringify(thucDon)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemThucDon').modal('hide');
                    thucDonController.notify("Cập nhật thực đơn thành công !!!");
                    thucDonController.loadData(true);
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
            url: '/Admin/ThucDons/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenThucDonX').val(dataDetail.TenThucDon);
                    $('#idTemp').val(dataDetail.MaThucDon);
                    $('#txtLoaiThucDonX').val(dataDetail.LoaiThucDon);

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
        var tenThucDon = $('#txtTenThucDon').val();
        var loaiThucDon = $('#txtLoaiThucDon').val();
        var thucDon = {
            MaThucDon: "",
            TenThucDon: tenThucDon,
            LoaiThucDon: loaiThucDon,
        }
        $.ajax({
            url: '/Admin/ThucDons/SaveData',
            data: {
                strThucDon: JSON.stringify(thucDon)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themThucDon').modal('hide');
                    thucDonController.notify("Thêm mới thực đơn thành công !!!");
                    thucDonController.loadData(true);
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
        $('#txtTenThucDon').val("");
        $('#txtLoaiThucDon').val("");
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/ThucDons/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listThucDons').html('');
                $.each(response.data, function (index, value) {

                    $('#listThucDons').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenThucDon +
                        "</td>"
                        +
                        "<td>"
                        + value.LoaiThucDon +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaThucDon + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaThucDon + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaThucDon + "'>Xóa</button>"
                        +
                        "<button class='btn btn-default btn-listMon' data-id='" + value.MaThucDon + "'>Danh sách món</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                thucDonController.paging(response.total, function () {
                    thucDonController.loadData();
                }, changePageSize);
                thucDonController.registerEvent();
            }
        })
    },
    LoadDataMonAnThucUongNew: function (maThucDon, changePageSize) {

        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/ThucDons/LayDanhSachChiTietThucDon",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                maThucDon: maThucDon
            },
            success: function (response) {
                $('#listMonAnThucUongs').html('');
                $.each(response.data, function (index, value) {
                    if (value.DaDuocChon) {
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
                        "<input type='checkbox' checked class='form-control cbx-ChonMon' data-id='" + value.MaMonAnThucUong + "'/>"
                        +
                        "</td>"
                        +
                        "</tr>");
                    } else {
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
                        "<input type='checkbox' class='form-control cbx-ChonMon' data-id='" + value.MaMonAnThucUong + "'/>"
                        +
                        "</td>"
                        +
                        "</tr>");
                    }
                });
                thucDonController.pagingCT(response.total, function () {
                    thucDonController.LoadDataMonAnThucUongNew(maThucDon);
                }, maThucDon, changePageSize);
                thucDonController.registerEvent();
            }
        })
    },
    updateChiTietThucDon: function (maThucDon, maMonAn) {
        $.ajax({
            type: "GET",
            url: "/Admin/ThucDons/CapNhatDanhSachMonAnThucUong",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                maThucDon: maThucDon,
                maMonAn:maMonAn
            },
            success: function (response) {

                if (response.status == 1) {
                    alert("Chọn món thành công");
                   // thucDonController.notify("Chọn món thành công !!!");
                    thucDonController.LoadDataMonAnThucUongNew(maThucDon,true);
                }
                else if (response.status == 2) {
                    thucDonController.notify("Chọn món không thành công !!!");
                    //thucDonController.LoadDataMonAnThucUongNew(maThucDon,true);
                }
                else if (response.status == 3) {
                    alert("Hủy món thành công");
                    thucDonController.notify("Hủy món thành công !!!");
                   // thucDonController.LoadDataMonAnThucUongNew(maThucDon,true);
                }
                else if (response.status == 4) {
                    thucDonController.notify("Hủy món không thành công !!!");
                    //thucDonController.LoadDataMonAnThucUongNew(maThucDon,true);
                }
            }
        });
    },
    LoadDataMonAnThucUong: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/ThucDons/LoadDataMonAnThucUong",
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
                        "<input type='checkbox' class='form-control' id=cbxChonMonCT/>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                thucDonController.pagingCT(response.total, function () {
                    thucDonController.LoadDataMonAnThucUong();
                }, changePageSize);
                thucDonController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/ThucDons/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listThucDons').html('');
                $.each(response.data, function (index, value) {
                    $('#listThucDons').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenThucDon +
                        "</td>"
                        +
                        "<td>"
                        + value.LoaiThucDon +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaThucDon + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaThucDon + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaThucDon + "'>Xóa</button>"
                        +
                        "<button class='btn btn-default btn-listMon' data-id='" + value.MaThucDon + "'>Danh sách món</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                thucDonController.paging(response.total, function () {
                    thucDonController.search();
                }, changePageSize);
                thucDonController.registerEvent();
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
    },
    pagingCT: function (totalRow, callback, changePageSize) {
        //ceil làm tròn
        var totalPage = Math.ceil(totalRow / homeConfig.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationCT a').length === 0 || changePageSize === true) {
            $('#paginationCT').empty();
            $('#paginationCT').removeData("twbs-pagination");
            $('#paginationCT').unbind("page");
        }
        $('#paginationCT').twbsPagination({
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
thucDonController.init();