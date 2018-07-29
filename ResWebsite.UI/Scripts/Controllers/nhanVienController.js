var homeConfig = {
    pageIndex: 1,
    pageSize: 5
}
var nhanVienController = {
    init: function () {
        nhanVienController.loadData();
        nhanVienController.registerEvent();
    },
    registerEvent: function () {

        $('#btnThemNhanVien').off('click').on('click', function () {
            nhanVienController.resetForm();
            $('#themNhanVien').modal('show');

        });
        $('#frmThemNhanVien').validate({
            rules: {
                txtTenNhanVienX: {
                    required: true,
                    minlength: 5
                },
                rdoGioiTinhX: {
                    required: true
                }
            },
            messages: {
                txtTenNhanVienX: {
                    required: "Tên bắt buộc nhập",
                    minlength: "Chiều dài phải lớn hơn 5 ký tự"
                },
                rdoGioiTinhX: {
                    required: "Bắt buộc chọn giới tính",
                }
            }
        });
        $('#frmXemNhanVien').validate({
            rules: {
                txtTenNhanVienX: {
                    required: true,
                    minlength: 5
                },
                rdoGioiTinhX: {
                    required: true
                }
            },
            messages: {
                txtTenNhanVienX: {
                    required: "Tên bắt buộc nhập",
                    minlength: "Chiều dài phải lớn hơn 5 ký tự"
                },
                rdoGioiTinhX: {
                    required: "Bắt buộc chọn giới tính",
                }
            }
        });
        $('#btnSave').off('click').on('click', function () {
            //if ($('#frmSaveData').valid()) {
            //    nhanVienController.saveData();
            //}
            nhanVienController.saveData();
        });
        $('#btnSaveC').off('click').on('click', function () {
            var id = $('#idTemp').val();
            if ($('#frmXemNhanVien').valid()) {
                nhanVienController.updateNhanVien(id);
            }

        });
        $('#btnSuaX').off('click').on('click', function () {
            $(this).replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            nhanVienController.registerEvent();
            $("#frmXemNhanVien :input,a").prop("disabled", false);

        });
        $('.btn-edit').off('click').on('click', function () {

            var id = $(this).data('id');
            nhanVienController.loadDetail(id);
            $('#xemNhanVien').modal('show');
            $("#frmXemNhanVien :input,a").prop("disabled", false);
            $('#btnSuaX').replaceWith("<button type='submit' class='btn btn-primary' id='btnSaveC'>" + "Lưu" + "</button>");
            nhanVienController.registerEvent();
        });
        $('.btn-delete').off('click').on('click', function () {
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có muốn xóa nhân viên này không ?",
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
                        console.log('Deleted Nhan Vien ' + id);
                        nhanVienController.deleteNhanVien(id);
                    } else {
                        nhanVienController.notify("Không xóa nhân viên uống này !!!");
                    }
                }
            });
        });
        $('.btn-details').off('click').on('click', function () {
            var id = $(this).data('id');
            nhanVienController.loadDetail(id);
            $('#xemNhanVien').modal('show');
            $("#frmXemNhanVien :input,a").prop("disabled", true);
            $('#btnSaveC').replaceWith("<button type='submit' class='btn btn-primary' id='btnSuaX'>" + "Sửa" + "</button>");
            nhanVienController.registerEvent();

        });
        $('#btnSearch').off('click').on('click', function () {
            nhanVienController.search(true);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            $('#txtInformationSearch').val('');
            nhanVienController.loadData(true);
        });
    },
    deleteNhanVien: function (id) {
        $.ajax({
            url: '/Admin/NhanViens/Delete',
            data: {
                id: id
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    nhanVienController.notify("Xóa thành công !!!");
                    nhanVienController.loadData(true);
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
    updateNhanVien: function (id) {
        var maNhanVien = id;
        var tenNhanVien = $('#txtTenNhanVienX').val();
        var gioiTinh = JSON.parse($("input:radio[name=rdoGioiTinhX]:checked").val());
        var ngaySinh = $("#txtNgaySinhX").val();
        var diaChi = $('#txtDiaChiX').val();
        var sdt = $('#txtSoDienThoaiX').val();
        var hinhAnh = $('#txtHinhAnhX').val();
        var chucVu = $('#txtChucVuX').val();
        var trangThai = $("input:radio[name=rdoTrangThaiX]:checked").val();
        var tenDangNhap = $('#txtTenDangNhapX').val();
        var matKhau = "123456";
        var email = $('#txtEmailX').val();
        var nhanVien = {
            MaNhanVien: maNhanVien,
            TenNhanVien: tenNhanVien,
            GioiTinh: gioiTinh,
            NgaySinh: ngaySinh,
            DiaChi: diaChi,
            SoDienThoai: sdt,
            HinhAnh: hinhAnh,
            ChucVu: chucVu,
            TrangThai: trangThai,
            TenDangNhap: tenDangNhap,
            MatKhau: matKhau,
            Email: email
        }
        $.ajax({
            url: '/Admin/NhanViens/CapNhat',
            data: {
                strNhanVien: JSON.stringify(nhanVien)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#xemNhanVien').modal('hide');
                    nhanVienController.notify("Cập nhật nhân viên thành công !!!");
                    nhanVienController.loadData(true);
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
            url: '/Admin/NhanViens/GetDetail',
            data: {
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var dataDetail = response.data;

                    $('#txtTenNhanVienX').val(dataDetail.TenNhanVien);
                    if (dataDetail.GioiTinh === true) {
                        $('input[id="rdoNamX"]').prop('checked', true);
                    }
                    //$(date).attr('value', today);
                    //$('#txtNgaySinhX').attr("value", response.date);

                    $('#idTemp').val(dataDetail.MaNhanVien);
                    $('#txtNgaySinhX').val(response.date);
                    $('#txtDiaChiX').val(dataDetail.DiaChi);
                    $('#txtSoDienThoaiX').val(dataDetail.SoDienThoai);
                    $('#txtHinhAnhX').val(dataDetail.HinhAnh);
                    $('#txtChucVuX').val(dataDetail.ChucVu);
                    if (dataDetail.TrangThai === 1) {
                        $('input[id="rdoDangHoatDongX"]').prop('checked', true);
                    }
                    $('#txtTenDangNhapX').val(dataDetail.TenDangNhap);
                    $('#txtEmailX').val(dataDetail.Email);
                    $("#imgImageX").attr("src", dataDetail.HinhAnh);

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
        var tenNhanVien = $('#txtTenNhanVien').val();
        var gioiTinh = JSON.parse($("input:radio[name=rdoGioiTinh]:checked").val());
        var ngaySinh = $("#txtNgaySinh").val();
        var diaChi = $('#txtDiaChi').val();
        var sdt = $('#txtSoDienThoai').val();
        var hinhAnh = $('#txtHinhAnh').val();
        var chucVu = $('#txtChucVu').val();
        var trangThai = $("input:radio[name=rdoTrangThai]:checked").val();
        var tenDangNhap = $('#txtTenDangNhap').val();
        var matKhau = "123456";
        var email = $('#txtEmail').val();
        var nhanVien = {
            MaNhanVien: "",
            TenNhanVien: tenNhanVien,
            GioiTinh: gioiTinh,
            NgaySinh: ngaySinh,
            DiaChi: diaChi,
            SoDienThoai: sdt,
            HinhAnh: hinhAnh,
            ChucVu: chucVu,
            TrangThai: trangThai,
            TenDangNhap: tenDangNhap,
            MatKhau: matKhau,
            Email: email
        }
        $.ajax({
            url: '/Admin/NhanViens/SaveData',
            data: {
                strNhanVien: JSON.stringify(nhanVien)
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    $('#themNhanVien').modal('hide');
                    nhanVienController.notify("Thêm mới nhân viên thành công !!!");
                    nhanVienController.loadData(true);
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
        $('#txtTenNhanVien').val("");
        $('input[name="rdoGioiTinh"]').prop('checked', false);
        $('#txtNgaySinh').val("");
        $('#txtDiaChi').val("");
        $('#txtSoDienThoai').val("");
        $('#txtHinhAnh').val("");
        $('#txtChucVu').val("");
        $('input[name="rdoTrangThai"]').prop('checked', false);
        $('#txtTenDangNhap').val("");
        $('#txtEmail').val("");
    },
    loadData: function (changePageSize) {
        $.ajax({
            type: "GET",
            async: true,
            url: "/Admin/NhanViens/LoadData",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize
            },
            success: function (response) {
                $('#listNhanViens').html('');
                $.each(response.data, function (index, value) {
                    var gioiTinh = "";
                    if (value.GioiTinh === true) {
                        gioiTinh = "Nam";
                    }
                    else {
                        gioiTinh = "Nữ"
                    }
                    var trangThai = "";
                    if (value.TrangThai === 1) {
                        trangThai = "Đang hoạt động";
                    }
                    else {
                        trangThai = "Bị khóa"
                    }
                    $('#listNhanViens').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenNhanVien +
                        "</td>"
                        +
                        "<td>"
                        + gioiTinh +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                        +
                        "</td>"
                        +
                        "<td>"
                        + value.ChucVu +
                        "</td>"
                        +
                        "<td>"
                        + trangThai +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaNhanVien + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaNhanVien + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaNhanVien + "'>Xóa</button>"
                        +
                        "<button class='btn btn-default'><a href='/Admin/PhanQuyens/Index/" + value.MaNhanVien + "' style='text-decoration:none;'>Phân quyền</a></button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                nhanVienController.paging(response.total, function () {
                    nhanVienController.loadData();
                }, changePageSize);
                nhanVienController.registerEvent();
            }
        })
    },
    search: function (changePageSize) {
        var information = $('#txtInformationSearch').val();
        $.ajax({
            type: 'GET',
            url: '/Admin/NhanViens/Search',
            dataType: 'json',
            data: {
                page: homeConfig.pageIndex,
                pageSize: homeConfig.pageSize,
                information: information
            },
            success: function (response) {
                $('#listNhanViens').html('');
                $.each(response.data, function (index, value) {
                    var gioiTinh = "";
                    if (value.GioiTinh === true) {
                        gioiTinh = "Nam";
                    }
                    else {
                        gioiTinh = "Nữ"
                    }
                    var trangThai = "";
                    if (value.TrangThai === 1) {
                        trangThai = "Đang hoạt động";
                    }
                    else {
                        trangThai = "Bị khóa"
                    }
                    $('#listNhanViens').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.TenNhanVien +
                        "</td>"
                        +
                        "<td>"
                        + gioiTinh +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<img src='" + value.HinhAnh + "' width='50px' height='50px'>"
                        +
                        "</td>"
                        +
                        "<td>"
                        + value.ChucVu +
                        "</td>"
                        +
                        "<td>"
                        + trangThai +
                        "</td>"
                        +
                        "<td>"
                        +
                        "<button class='btn btn-default btn-details' data-id='" + value.MaNhanVien + "'>Xem</button>"
                        +
                        "<button class='btn btn-default btn-edit' data-id='" + value.MaNhanVien + "'>Sửa</button>"
                        +
                        "<button class='btn btn-default btn-delete' data-id='" + value.MaNhanVien + "'>Xóa</button>"
                        +
                        "<button class='btn btn-default'><a href='/Admin/PhanQuyens/Index/" + value.MaNhanVien + "' style='text-decoration:none;'>Phân quyền</a></button>"
                        +
                        "</td>"
                        +
                        "</tr>");
                });
                nhanVienController.paging(response.total, function () {
                    nhanVienController.search();
                }, changePageSize);
                nhanVienController.registerEvent();
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
nhanVienController.init();