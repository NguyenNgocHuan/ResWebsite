
var chamCongController = {
    init: function () {
        chamCongController.registerEvent();

    },
    registerEvent: function () {
        $('#btnSearch').off('click').on('click', function () {
            var information = $('#txtChucVu').val();
            chamCongController.search(information);
        });

        $("body").on("click", "#table tbody tr", function () {
            $('#tenNhanVien').html('Chấm công cho nhân viên : ');
            $('#tenNhanVien').append(this.cells[1].innerHTML);
            //alert(this.cells[0].innerHTML);
            $('#idTemp').val(this.cells[0].innerHTML);
            var maNhanVien = this.cells[0].innerHTML;
            var ngayLamViec = $('#txtNgayLamViec').val();
            chamCongController.loadDanhSachChiaCaLamViec(maNhanVien, ngayLamViec);
        });
        $('#btnResetSearch').off('click').on('click', function () {
            alert("abc");
        });
        $('#txtChucVu').change(function () {
            $('#listCaLamViec').html('');
        });
    },
    capNhatNew: function (obj) {
        var maNhanVien = $('#idTemp').val();
        var ngay = $('#txtNgayLamViec').val();
        var timeIn = $('#In' + obj.value).val();
        var timeOut = $('#Out' + obj.value).val();
        var caLamViec = $('#caLV' + obj.value).val();
        if ($('#cbx' + obj.value).prop('checked') === true) {
            chamCongController.capNhat(maNhanVien, caLamViec, ngay, timeIn, timeOut);
            chamCongController.loadDanhSachChiaCaLamViec(maNhanVien, ngay);
        }
        else {
            chamCongController.notifyWarning("Không thể chấm công vì nhân viên chưa được chia ca này !!!");
        }
        
    },
    ngayGioRaVao: function (obj) {
        var maNhanVien = $('#idTemp').val();
        var ngay = $('#txtNgayLamViec').val();
        if (obj.checked) {
       //     alert("checked");
            var timeIn = $('#In' + obj.value).val();
            $('#In' + obj.value).replaceWith("<input type='time'   class='form form-control' id='In" + obj.value + "' value='" + timeIn + "' disabled='disabled'/>");

            var timeOut = $('#Out' + obj.value).val();
            $('#Out' + obj.value).replaceWith("<input type='time'  class='form form-control' id='Out" + obj.value + "' value='" + timeOut + "' disabled='disabled'/>");
            //$("body").on("click", "#tableCa tbody tr", function () {

            //});
        }
        else {
           // alert("unchecked");
            var timeIn = $('#In' + obj.value).val();
            $('#In' + obj.value).replaceWith("<input type='time'  class='form form-control' id='In" + obj.value + "' value='" + timeIn + "'>");

            var timeOut = $('#Out' + obj.value).val();
            $('#Out' + obj.value).replaceWith("<input type='time'  class='form form-control' id='Out" + obj.value + "' value='" + timeOut + "'>");
            //$("body").on("click", "#tableCa tbody tr", function () {

            //});
        }
    },
    capNhatChiaCaLamViec: function (obj) {
        var maNhanVien = $('#idTemp').val();
        var ngay = $('#txtNgayLamViec').val();
        if (obj.checked) {

            //  alert("đã check" + obj.value + "mã nhân viên" + maNhanVien+" ngày"+ngay);
            chamCongController.capNhat(maNhanVien, obj.value, ngay);

        }
        else {
            //   alert("hủy check");
            chamCongController.capNhat(maNhanVien, obj.value, ngay);
        }
    },
    xacNhanDaChamCong: function (maNhanVien, caLamViec, ngay,maCaLamViec) {
        $.ajax({
            url: '/Admin/ChamCongs/XacNhanDaChamCong',
            type: 'POST',
            dataType: "json",
            data: {
                maNhanVien: maNhanVien,
                caLamViec: caLamViec,
                ngay: ngay,
            },
            success: function (response) {
                // return response.status;
                if (response.status === true) {
                 //   alert("đã chấm")
                    $('#daCham' + maCaLamViec).replaceWith("<input  class='btn btn-success' id='caLV" + maCaLamViec + "' value='Đã chấm' disabled>");
                    $('#In' + maCaLamViec).replaceWith("<input type='time'  class='form form-control' id='In" + maCaLamViec + "' value='" + response.thoiGianVao + "'>");

                    $('#Out' + maCaLamViec).replaceWith("<input type='time'  class='form form-control' id='Out" + maCaLamViec + "' value='" + response.thoiGianRa + "'>");
                }
                else {
                   // alert("chưa chấm")
                    $('#daCham' + maCaLamViec).replaceWith("<input  class='btn btn-danger' id='caLV" + maCaLamViec + "' value='Chưa chấm' disabled>");
                   // $('#thongBao').val("Chưa chấm công");
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
    },
    loadDanhSachChiaCaLamViec: function (maNhanVien, ngayLamViec) {
        $.ajax({
            type: "GET",
            url: "/Admin/ChamCongs/LayDanhSachChamCong",
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
                        chamCongController.xacNhanDaChamCong(maNhanVien, value.TenCaLamViec, ngayLamViec,value.MaCaLamViec);
                     //   alert($('#thongBao').val())
                        $('#listCaLamViec').append(
                                "<tr>"
                                +
                                "<td>"
                                +
                                "<input class='btn btn-success' id='caLV" + value.MaCaLamViec + "' value='" + value.TenCaLamViec + "'disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<input type='time'  class='form form-control'  id='In" + value.MaCaLamViec + "' value='" + value.ThoiGianVao.substring(0, 8) + "' />"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<input type='time'  class='form form-control'  id='Out" + value.MaCaLamViec + "' value='" + value.ThoiGianRa.substring(0, 8) + "' />"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox' id='cbx" + value.MaCaLamViec + "' onclick='chiaCaLamViecController.capNhatChiaCaLamViec(this);' checked value='" + value.MaCaLamViec + "' disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox'  id='cbxDungGio" + value.MaCaLamViec + "' onclick='chamCongController.ngayGioRaVao(this);' value='" + value.MaCaLamViec + "'>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<input class='btn btn-success' id='daCham" + value.MaCaLamViec + "' disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<button  class='btn btn-success' onclick='chamCongController.capNhatNew(this);' value='" + value.MaCaLamViec + "' data-id='" + value.TenCaLamViec + "'>Xác nhận</button>"
                                +
                                "</td>"
                                +
                                "</tr>");
                        
                    }
                    else {
                        chamCongController.xacNhanDaChamCong(maNhanVien, value.TenCaLamViec, ngayLamViec, value.MaCaLamViec);
                  //      alert($('#thongBao').val())
                        $('#listCaLamViec').append(
                                "<tr>"
                                +
                                "<td>"
                                +
                                "<input class='btn btn-success' id='caLV" + value.MaCaLamViec + "' value='" + value.TenCaLamViec + "' disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<input type='time'  class='form form-control' id='In" + value.MaCaLamViec + "' value='" + value.ThoiGianVao.substring(0, 8) + "'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<input type='time'  class='form form-control' id='Out" + value.MaCaLamViec + "' value='" + value.ThoiGianRa.substring(0, 8) + "'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox' id='cbx" + value.MaCaLamViec + "' onclick='chiaCaLamViecController.capNhatChiaCaLamViec(this);' value='" + value.MaCaLamViec + "' disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input type='CheckBox' id='cbxDungGio" + value.MaCaLamViec + "' onclick='chamCongController.ngayGioRaVao(this);' value='" + value.MaCaLamViec + "'>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                 "<input class='btn btn-success' id='daCham" + value.MaCaLamViec + "' disabled='disabled'/>"
                                +
                                "</td>"
                                +
                                "<td>"
                                +
                                "<button  class='btn btn-success' onclick='chamCongController.capNhatNew(this);' value='" + value.MaCaLamViec + "'  data-id='" + value.TenCaLamViec + "'>Xác nhận</button>"
                                +
                                "</td>"
                                +
                                "</tr>");
                    }

                    
                   // alert($('#thongBao').val())
                })
            }
        })
    },

    capNhat: function (maNhanVien, caLamViec, ngay, thoiGianVao, thoiGianRa) {
        $.ajax({
            url: '/Admin/ChamCongs/CapNhatDanhSachChamCong',
            type: 'POST',
            dataType: "json",
            data: {
                maNhanVien: maNhanVien,
                caLamViec: caLamViec,
                ngay: ngay,
                thoiGianVao: thoiGianVao,
                thoiGianRa: thoiGianRa,
            },
            success: function (response) {
                if (response.status === 1) {
                    chamCongController.notify("Chấm công thành công !!!");
                    
                }
                else if (response.status === 2) {
                    chamCongController.notify("Chấm công không thành công !!!");
                    
                }
                else if (response.status === 3) {
                    chamCongController.notify("Cập nhật chấm công thành công !!!");
                   
                }
                else if (response.status === 4) {
                    chamCongController.notify("Cập nhật chấm công không thành công !!!");
                    
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
            url: '/Admin/ChamCongs/LayDanhSachNhanVien',
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
    notifyWarning: function (message) {
        $.notify(
            message, {
            animate: {
                enter: 'animated bounceIn',
                exit: 'animated bounceOut',
                type: 'danger'
            },
            
        });
    },

}
chamCongController.init();