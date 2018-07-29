
var phanQuyenController = {
    init: function () {
        phanQuyenController.loadData();
        phanQuyenController.registerEvent();
    },
    registerEvent: function () {
        $('select').on('change', function () {
           // alert(this.value);
            phanQuyenController.loadDanhSachQuyenHan();
        });
        $('input').on('change', function () {
            //  alert(this.value);
            var id = this.value;
            phanQuyenController.updatePhanQuyen(id);
        })
    },
    updatePhanQuyen: function (maQuyenHan) {
        var url = window.location.pathname;
        var maNhanVien = url.substring(url.lastIndexOf('/') + 1);
        var maQuyenHan = maQuyenHan;
        $.ajax({
            url: '/Admin/PhanQuyens/CapNhatDanhSachQuyenHan',
            type: 'POST',
            dataType: "json",
            data: {
                maQuyenHan: maQuyenHan,
                maNhanVien: maNhanVien
            },
            success: function (response) {
                if (response.status === 1) {
                    phanQuyenController.notify("Phân quyền thành công !!!");
                   // phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 2) {
                    phanQuyenController.notify("Phân quyền không thành công !!!");
                    //phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 3) {
                    phanQuyenController.notify("Hủy quyền thành công !!!");
                    //phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 4) {
                    phanQuyenController.notify("Hủy quyền không thành công !!!");
                   // phanQuyenController.loadDanhSachQuyenHan();
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
    loadDanhSachQuyenHan: function () {
        var maNghiepVu = $('#txtNghiepVu').val();
        var url = window.location.pathname;
        var maNhanVien = url.substring(url.lastIndexOf('/') + 1);
        $.ajax({
            type: "GET",
            url: "/Admin/PhanQuyens/LayDanhSachQuyenHan",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                maNghiepVu: maNghiepVu,
                maNhanVien:maNhanVien
            },
            success: function (response) {
                $('#listQuyenHan').html('');
                $.each(response.data, function (index, value) {
                    if (value.DaDuocChon) {
                        $('#listQuyenHan').append("<input type='CheckBox' checked value='" + value.MaQuyenHan + "'>" + value.MoTa + "<br>");
                    } else {
                        $('#listQuyenHan').append("<input type='CheckBox' value='" + value.MaQuyenHan + "'>" + value.MoTa + "<br>");
                    }
                });
                phanQuyenController.registerEvent();
            }
        })
    },
    loadData: function () {
        var url = window.location.pathname;
        var id = url.substring(url.lastIndexOf('/') + 1);
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/PhanQuyens/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                id: id
            },
            success: function (response) {

                if (response.status) {
                    $('#txtNghiepVu').html('<option value="">Chọn nghiệp vụ</option>');
                    $('#tenNhanVien').append(response.tenNhanVien);
                    $.each(response.data, function (index, value) {

                        $('#txtNghiepVu').append(
                            "<option value='" + value.MaNghiepVu + "'>" + value.TenNghiepVu + "</option>"
                            );
                    });
                    phanQuyenController.registerEvent();
                }
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

}
phanQuyenController.init();