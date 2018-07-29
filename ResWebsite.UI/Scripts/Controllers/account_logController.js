var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var account_logController = {
    init: function () {
        account_logController.loadData();
        account_logController.registerEvent();
    },
    registerEvent: function () {
       
        $('#btnSearch').off('click').on('click', function () {
            var dateTime = $('#txtDate').val();
            if (dateTime == "") {
                account_logController.notify("Bạn chưa chọn ngày, Kiểm tra lại thông tin");
            }
            account_logController.loadDataSearch(true);
        });
        $('#btnReset').off('click').on('click', function () {
            $('#txtDate').val('');
            account_logController.loadData(true);
        });
    },
    loadData: function (changePageSize) {
        $.ajax({
            url: '/Account_Log/LoadData',
            type: 'GET',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            dataType: 'json',
            
            success: function (response) {
                $('#tblData').html('');
                $.each(response.data, function (index, value) {
                    $('#tblData').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.EmployeeName +
                        "</td>"
                        +
                        "<td>"
                        + value.Action +
                        "</td>"
                        +
                        "<td>"
                        + value.Time +
                        "</td>"
                        +
                        "<td>"
                        + value.IpAddress +
                        "</td>"
                        +
                        "</tr>");
                });
                account_logController.paging(response.total, function () {
                    account_logController.loadData();
                }, changePageSize);
                account_logController.registerEvent();
            }
        })
    },
    loadDataSearch: function (changePageSize) {
        var datetime = $('#txtDate').val();
        $.ajax({
            url: '/Account_Log/LoadDataSearch',
            type: 'GET',
            data: {
                dateTime:datetime,
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            dataType: 'json',

            success: function (response) {
                $('#tblData').html('');
                $.each(response.data, function (index, value) {
                    $('#tblData').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.EmployeeName +
                        "</td>"
                        +
                        "<td>"
                        + value.Action +
                        "</td>"
                        +
                        "<td>"
                        + value.Time +
                        "</td>"
                        +
                        "<td>"
                        + value.IpAddress +
                        "</td>"
                        +
                        "</tr>");
                });
                account_logController.paging(response.total, function () {
                    account_logController.loadData(true);
                }, changePageSize);
                account_logController.registerEvent();
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
account_logController.init();