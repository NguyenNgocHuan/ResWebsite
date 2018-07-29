
var chiaCaLamViecController = {
    init: function () {
        chiaCaLamViecController.registerEvent();

    },
    registerEvent: function () {
        $('#btnSearch').off('click').on('click', function () {
            var information = $('#txtChucVu').val();
            chiaCaLamViecController.search(information);
        });

        $("body").on("click", "#table tbody tr", function () {
            $('#tenNhanVien').html('Chia ca làm việc cho nhân viên : ');
            $('#tenNhanVien').append(this.cells[1].innerHTML);
            //alert(this.cells[0].innerHTML);
            $('#idTemp').val(this.cells[0].innerHTML);
            var maNhanVien = this.cells[0].innerHTML;
            var ngayLamViec = $('#txtNgayLamViec').val();
            chiaCaLamViecController.loadDanhSachChiaCaLamViec(maNhanVien, ngayLamViec);
        });

        //$('input[type=checkbox]').click(function() {
        //    if($(this).is(':checked')) {
        //        alert("checked");
        //        } else {
        //        alert("non checked");
        //        }
        //});
        $(':checkbox').change(function () {
            if ($(this).attr('checked')) {
                alert('is checked');
            } else {
                alert('not checked');
            }
        });
        //$("body").on("click", "#tableCa tbody tr", function () {
        //   // $('#tenNhanVien').html('Chia ca làm việc cho nhân viên : ');
        //   // $('#tenNhanVien').append(this.cells[1].innerHTML);
        //   // alert(this.cells[0].innerHTML);
        //    var ma = 'cbx' + this.cells[0].innerHTML;
        //   // $('#idTemp').val(this.cells[0].innerHTML);
        //   // var maCa = this.cells[0].innerHTML;
        //   // var ngayLamViec = $('#txtNgayLamViec').val();
        //    // chiaCaLamViecController.loadDanhSachChiaCaLamViec(maNhanVien, ngayLamViec);
        //    $('"#"+ma').on('change', function () {
        //        //  alert(this.value);
        //        var maCaLamViec = this.value;
        //        var maNhanVien = $('#idTemp').val();
        //        var ngay = $('#txtNgayLamViec').val();
        //        chiaCaLamViecController.capNhatChiaCaLamViec(maNhanVien, maCaLamViec, ngay);
        //    });
        //});
        //$('input[type="checkbox"]').change(function () {
        //    alert(1);
        //});
        //$('.checkbox').change(function () {
        //    alert(2);
        //});
        //$('input[type="checkbox"]').change(function () {
        //    if (this.checked) {
        //        alert('is checked');
        //    } else {
        //        alert('is not checked');
        //    }
        //})

        //$('input').on('change', function () {
        //    //  alert(this.value);
        //    var maCaLamViec = this.value;
        //    var maNhanVien = $('#idTemp').val();
        //    var ngay = $('#txtNgayLamViec').val();
        //    chiaCaLamViecController.capNhatChiaCaLamViec(maNhanVien,maCaLamViec,ngay);
        //})
        $('#btnResetSearch').off('click').on('click', function () {
            alert("abc");
        });
        //$('#btnResetSearch').off('click').on('click', function () {
        //    $('#txtInformationSearch').val('');
        //    chiaCaLamViecController.resetData(true);
        //});
    },
    capNhatChiaCaLamViec: function (obj) {
            var maNhanVien = $('#idTemp').val();
            var ngay = $('#txtNgayLamViec').val();
        if (obj.checked) {

          //  alert("đã check" + obj.value + "mã nhân viên" + maNhanVien+" ngày"+ngay);
            chiaCaLamViecController.capNhat(maNhanVien, obj.value, ngay);
        }
        else {
         //   alert("hủy check");
            chiaCaLamViecController.capNhat(maNhanVien, obj.value, ngay);
        }
    }
    ,
    loadDanhSachChiaCaLamViec: function (maNhanVien, ngayLamViec) {
        $.ajax({
            type: "GET",
            url: "/Admin/ChiaCaLamViecs/LayDanhSachChiaCaLamViec",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                maNhanVien: maNhanVien,
                ngayLamViec: ngayLamViec
            },
            success: function (response) {
                $('#listCaLamViec').html('');
                $.each(response.data, function (index, value) {
                    if (value.DaDuocChon) {
                        $('#listCaLamViec').append(
                                "<tr>"
                                +
                                "<td>"
                                + value.MaCaLamViec +
                                "</td>"
                                +
                                "<td>"
                                + value.TenCaLamViec +
                                "</td>"
                                +
                                "<td>"
                                + value.ThoiGianVao.substring(0, 8) +
                                "</td>"
                                +
                                "<td>"
                                + value.ThoiGianRa.substring(0, 8) +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox' id='cbx" + value.MaCaLamViec + "' onclick='chiaCaLamViecController.capNhatChiaCaLamViec(this);' checked value='" + value.MaCaLamViec + "'>"
                                +
                                "</td>"
                                +
                                "</tr>");
                    } else {
                        $('#listCaLamViec').append(
                                "<tr>"
                                +
                                "<td>"
                                + value.MaCaLamViec +
                                "</td>"
                                +
                                "<td>"
                                + value.TenCaLamViec +
                                "</td>"
                                +
                                "<td>"
                                + value.ThoiGianVao.substring(0, 8) +
                                "</td>"
                                +
                                "<td>"
                                + value.ThoiGianRa.substring(0, 8) +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox' id='cbx" + value.MaCaLamViec + "' onclick='chiaCaLamViecController.capNhatChiaCaLamViec(this);' value='" + value.MaCaLamViec + "'>"
                                +
                                "</td>"
                                +
                                "</tr>");
                    }
                })
            }
        })
    },
    capNhat: function (maNhanVien, maCaLamViec, ngay) {
        $.ajax({
            url: '/Admin/ChiaCaLamViecs/CapNhatDanhSachChiaCaLamViec',
            type: 'POST',
            dataType: "json",
            data: {
                maNhanVien: maNhanVien,
                maCaLamViec: maCaLamViec,
                ngay:ngay
            },
            success: function (response) {
                if (response.status === 1) {
                    chiaCaLamViecController.notify("Chia ca thành công !!!");
                    // phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 2) {
                    chiaCaLamViecController.notify("Chia ca không thành công !!!");
                    //phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 3) {
                    chiaCaLamViecController.notify("Hủy ca thành công !!!");
                    //phanQuyenController.loadDanhSachQuyenHan();
                }
                else if (response.status === 4) {
                    chiaCaLamViecController.notify("Hủy ca không thành công !!!");
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
    search: function (information) {

        $.ajax({
            type: 'GET',
            url: '/Admin/ChiaCaLamViecs/LayDanhSachNhanVien',
            dataType: 'json',
            data: {
                loaiNhanVien: information
            },
            success: function (response) {
                $('#listNhanViens').html('<tr></tr>');
                $.each(response.data, function (index, value) {
                    $('#listNhanViens').append(
                        "<tr>"
                        +
                        "<td>"
                        + value.MaNhanVien +
                        "</td>"
                        +
                        "<td>"
                        + value.TenNhanVien +
                        "</td>"
                       +
                        "</tr>");
                });
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
chiaCaLamViecController.init();