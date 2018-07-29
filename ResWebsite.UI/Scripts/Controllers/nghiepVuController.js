var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var nghiepVuController = {
    init: function () {
        nghiepVuController.loadData();
        nghiepVuController.registerEvent();
    },
    registerEvent: function () {

        $('#btnCapNhatDanhSachNghiepVu').off('click').on('click', function () {
            nghiepVuController.capNhatDanhSachNghiepVu();

        });
        
        //$('#btnSave').off('click').on('click', function () {
        //    //if ($('#frmSaveData').valid()) {
        //    //    nhanVienController.saveData();
        //    //}
        //    nghiepVuController.saveData();
        //});
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#txtMaNghiepVuX').val();
            nghiepVuController.updateNghiepVu(id);

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            nghiepVuController.registerEvent();
            $("#frmXemNghiepVu :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            nghiepVuController.loadDetail(id);
            $('#xemNghiepVu').modal('show');
            $("#frmXemNghiepVu :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            nghiepVuController.registerEvent();
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            nghiepVuController.loadDetail(id);
            $('#xemNghiepVu').modal('show');
            $("#frmXemNghiepVu :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            nghiepVuController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            nghiepVuController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            nghiepVuController.loadData(true);
        });
    },
    capNhatDanhSachNghiepVu: function (id) {
        $.ajax({
            url: '/Admin/NghiepVus/CapNhatDanhSachNghiepVu',
            data: {
                
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    nghiepVuController.notify("Cập nhật danh sách nghiệp vụ thành công !!!");
                    nghiepVuController.loadData(true);
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
    updateNghiepVu: function (id) {
        var maNghiepVu = $('#txtMaNghiepVuX').val();
        var tenNghiepVu = $('#txtTenNghiepVuX').val();
        var ghiChu = $("#txtGhiChuX").val();
        var nghiepVu = {
            MaNghiepVu: maNghiepVu,
            TenNghiepVu: tenNghiepVu,
            GhiChu: ghiChu
        }
        $.ajax({
            url: '/Admin/NghiepVus/CapNhat',
            data: {
                strNghiepVu: JSON.stringify(nghiepVu)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemNghiepVu').modal('hide');
                    nghiepVuController.notify("Cập nhật nghiệp vụ thành công !!!");
                    nghiepVuController.loadData(true);
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
            url: '/Admin/NghiepVus/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtMaNghiepVuX').val(dataDetail.MaNghiepVu);
                    $('#txtTenNghiepVuX').val(dataDetail.TenNghiepVu);
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
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/NghiepVus/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listNghiepVus').html('');
                $.each(response.data, function (index, value) {
                  
                    $('#listNghiepVus').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.MaNghiepVu +
                        "</td>"
                        +
                        "<td>"
                         + value.TenNghiepVu +
                        "</td>"
                        +
                        "<td>"
                         + value.GhiChu +
                        "</td>"
                        +
                       
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaNghiepVu + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaNghiepVu + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default'><a href='/Admin/QuyenHans/Index/"+value.MaNghiepVu +"' style='text-decoration:none;'>Danh sách quyền</a></button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                nghiepVuController.paging(response.total, function () {
                    nghiepVuController.loadData();
                }, changePageSize);
                nghiepVuController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/NghiepVus/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listNghiepVus').html('');
                $.each(response.data, function (index, value) {
                    $('#listNghiepVus').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.MaNghiepVu +
                         "</td>"
                         +
                         "<td>"
                          + value.TenNghiepVu +
                         "</td>"
                         +
                         "<td>"
                         + value.GhiChu +
                         "</td>"
                         +

                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaNghiepVu + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaNghiepVu + "'>Sửa</button>"
                         +
                         "<button class='btn btn-default btn-permissions' data-id='" + value.MaNghiepVu + "'>Danh sách quyền</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                nghiepVuController.paging(response.total, function () {
                    nghiepVuController.search();
                }, changePageSize);
                nghiepVuController.registerEvent();
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
nghiepVuController.init();