var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var lichLamViecController = {
    init: function () {
        lichLamViecController.searchMaNhanVien();
        //quyenHanController.loadData(true);
        lichLamViecController.registerEvent();
    },
    registerEvent: function () {
        $('#btnSearch').off('click').on('click', function () {
            lichLamViecController.searchMaNhanVienTheoNgay(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtDateSearch').val('');
            lichLamViecController.searchMaNhanVien(true);
        });
    },
    searchMaNhanVien: function (changePageSize) {
        var url = window.location.pathname;
        var maNhanVien = url.substring(url.lastIndexOf('/') + 1);
        $.ajax({
            type: 'GET',
            url: '/Admin/Home/LoadData',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                maNhanVien: maNhanVien
            },
            success: function (response) {
                $('#listLichLamViecs').html('');
                $.each(response.data, function (index, value) {
                    $('#listLichLamViecs').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.NgayLamViec +
                         "</td>"
                         +
                         "<td>"
                         + value.TenCaLamViec +
                         "</td>"
                         +
                         "<td>"
                         + value.ThoiGianRa.substring(0, 8)  +
                         "</td>"
                         +
                         "<td>"
                         + value.ThoiGianVao.substring(0, 8) +
                         "</td>"
                         +
                         "</tr>");
                });
                lichLamViecController.paging(response.total, function () {
                    lichLamViecController.searchMaNhanVien();
                }, changePageSize);
                lichLamViecController.registerEvent();
            }
        })
    },
    searchMaNhanVienTheoNgay: function (changePageSize) {
        var url = window.location.pathname;
        var maNhanVien = url.substring(url.lastIndexOf('/') + 1);
        var ngay=$('#txtDateSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/Home/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                maNhanVien: maNhanVien,
                ngay:ngay
            },
            success: function (response) {
                $('#listLichLamViecs').html('');
                $.each(response.data, function (index, value) {
                    $('#listLichLamViecs').append(
                         "<tr>"
                         +
                         "<td>"
                         + value.NgayLamViec +
                         "</td>"
                         +
                         "<td>"
                         + value.TenCaLamViec +
                         "</td>"
                         +
                         "<td>"
                         + value.ThoiGianRa.substring(0, 8) +
                         "</td>"
                         +
                         "<td>"
                         + value.ThoiGianVao.substring(0, 8) +
                         "</td>"
                         +
                         "</tr>");
                });
                lichLamViecController.paging(response.total, function () {
                    lichLamViecController.searchMaNhanVienTheoNgay();
                }, changePageSize);
                lichLamViecController.registerEvent();
            }
        })
    },
    //search: function (changePageSize) {
    //    var information = $('#txtInformationSearch').val();
    //    $.ajax({
    //        type: 'GET',
    //        url: '/Admin/QuyenHans/Search',
    //        dataType: 'json',
    //        data: {
    //            page: homeConfig.pageIndex,
    //            pageSize: homeConfig.pageSize,
    //            information: information
    //        },
    //        success: function (response) {
    //            $('#listQuyenHans').html('');
    //            $.each(response.data, function (index, value) {
    //                $('#listQuyenHans').append(
    //                     "<tr>"
    //                     +
    //                     "<td>"
    //                     + value.TenQuyenHan +
    //                     "</td>"
    //                     +
    //                     "<td>"
    //                     + value.MaNghiepVu +
    //                     "</td>"
    //                     +
    //                     "<td>"
    //                     + value.MoTa +
    //                     "</td>"
    //                     +
    //                     "<td>"
    //                     +
    //                     "<button class='btn btn-default btn-details' data-id='" + value.MaQuyenHan + "'>Xem</button>"
    //                     +
    //                     "<button class='btn btn-default btn-edit' data-id='" + value.MaQuyenHan + "'>Sửa</button>"
    //                     +
    //                     "</td>"
    //                     +
    //                     "</tr>");
    //            });
    //            quyenHanController.paging(response.total, function () {
    //                quyenHanController.search();
    //            }, changePageSize);
    //            quyenHanController.registerEvent();
    //        }
    //    })
    //},
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
lichLamViecController.init();