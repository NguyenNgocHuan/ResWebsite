var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var quyenHanController = {
    init: function () {
         quyenHanController.searchMaNghiepVu(true);
       //quyenHanController.loadData(true);
        quyenHanController.registerEvent();
    },
    registerEvent: function () {
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            quyenHanController.updateQuyenHan(id);
        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            quyenHanController.registerEvent();
            $("#frmXemQuyenHan :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            quyenHanController.loadDetail(id);
            $('#xemQuyenHan').modal('show');
            $("#frmXemQuyenHan :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            quyenHanController.registerEvent();
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            quyenHanController.loadDetail(id);
            $('#xemQuyenHan').modal('show');
            $("#frmXemQuyenHan :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            quyenHanController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            quyenHanController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            quyenHanController.loadData(true);
        });
    },
    updateQuyenHan: function (id) {
        var maQuyenHan = id;
        var tenQuyenHan = $('#txtTenQuyenHanX').val();
        var maNghiepVu = $("#txtMaNghiepVuX").val();
        var moTa = $('#txtMoTaX').val();
        var quyenHan = {
            MaQuyenHan: maQuyenHan,
            TenQuyenHan: tenQuyenHan,
            MaNghiepVu: maNghiepVu,
            MoTa: moTa,
        }
        $.ajax({
            url: '/Admin/QuyenHans/CapNhat',
            data: {
                strQuyenHan: JSON.stringify(quyenHan)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemQuyenHan').modal('hide');
                    quyenHanController.notify("Cập nhật quyền hạn thành công !!!");
                    quyenHanController.loadData(true);
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
            url: '/Admin/QuyenHans/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenQuyenHanX').val(dataDetail.TenQuyenHan);
                    $('#idTemp').val(dataDetail.MaQuyenHan);
                    $('#txtMaNghiepVuX').val(dataDetail.MaNghiepVu);
                    $('#txtMoTaX').val(dataDetail.MoTa);

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
            url: "/Admin/QUyenHans/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listQuyenHans').html('');
                $.each(response.data, function (index, value) {

                    $('#listQuyenHans').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenQuyenHan +
                        "</td>"
                        +
                        "<td>"
                        + value.MaNghiepVu +
                        "</td>"
                        +
                        "<td>"
                        + value.MoTa +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaQuyenHan + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaQuyenHan + "'>Sửa</button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                quyenHanController.paging(response.total, function () {
                    quyenHanController.loadData();
                }, changePageSize);
                quyenHanController.registerEvent();
            }
        })
    },
    searchMaNghiepVu: function (changePageSize) {
        var url = window.location.pathname;
        var information = url.substring(url.lastIndexOf('/') + 1);
        $.ajax({
            type: 'GET',
            url: '/Admin/QuyenHans/SearchMaNghiepVu',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listQuyenHans').html('');
                $.each(response.data, function (index, value) {
                    $('#listQuyenHans').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.TenQuyenHan +
                         "</td>"
                         +
                         "<td>"
                         + value.MaNghiepVu +
                         "</td>"
                         +
                         "<td>"
                         + value.MoTa +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaQuyenHan + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaQuyenHan + "'>Sửa</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                quyenHanController.paging(response.total, function () {
                    quyenHanController.searchMaNghiepVu();
                }, changePageSize);
                quyenHanController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/QuyenHans/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listQuyenHans').html('');
                $.each(response.data, function (index, value) {
                    $('#listQuyenHans').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.TenQuyenHan +
                         "</td>"
                         +
                         "<td>"
                         + value.MaNghiepVu +
                         "</td>"
                         +
                         "<td>"
                         + value.MoTa +
                         "</td>"
                         +
                         "<td>"
                         +
                         "<button class='btn btn-default btn-details' data-id='" + value.MaQuyenHan + "'>Xem</button>"
                         +
                         "<button class='btn btn-default btn-edit' data-id='" + value.MaQuyenHan + "'>Sửa</button>"
                         +
                         "</td>"
                         +
                         "</tr>");
                });
                quyenHanController.paging(response.total, function () {
                    quyenHanController.search();
                }, changePageSize);
                quyenHanController.registerEvent();
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
quyenHanController.init();