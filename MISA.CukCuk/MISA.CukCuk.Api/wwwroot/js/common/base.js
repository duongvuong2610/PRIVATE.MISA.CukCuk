/**
 * Class quản lý các sự kiện cho trang giao diện
 * CreatedBy: dvvuong (03/01/2020)
 * */
class BaseJS {
    constructor() {
        this.host = "";
        this.apiRouter = null;
        this.setApiRouter();
        this.initEvents();
        this.loadData();
    }

    /**
     * xét endpoint 
     * Author: DVVUONG (08/01/2021)
     * */
    setApiRouter() {

    }

    /**
     * hàm thực hiện các sự kiện 
     * Author: DVVUONG (17/01/2021)
     * */
    initEvents() {
        var me = this;
        // Sự kiện click khi nhấn thêm mới
        $('#btnAdd').click(me.btnAddOnClick.bind(me));

        // Load lại dữ liệu khi nhấn button nạp
        $('#btnRefresh').click(me.btnRefreshOnClick.bind(me));

        // Ẩn form chi tiết khi nhấn hủy
        $('#btnCancel, #btnClose').click(me.btnCancelOnClick);


        // Thực hiện lưu dữ liệu khi nhấn button [Lưu] trên form form thêm
        $('#btnSave').click(me.btnSaveOnClick.bind(me))

        // Thực hiện đóng form xác nhận xóa, khi nhấp nút [Không]
        $('#m-btn-cancel2').click(function () {
            $('#m-popup-confirmDel').hide();
        });

       

        /*
         Hiển thi thông tin chi tiết khi nhấn đúp chuột vào 1 bản ghi trên danh sách dữ liệu
         Author: DVVUONG (16/01/2021)
         */
        $('table tbody').on('dblclick', 'tr', function () {
            // hiển thị nút Xóa
            $('#v-btnDelete').show();

            $(this).find('td').addClass('row-selected');
            $('input').removeClass('border-red');
            // load dữ liệu cho các combobox
            me.loadCombobox();

            // them trang thái form 
            me.FormMode = 'Edit';
            // lấy khóa chính của bản ghi
            var recordId = $(this).data('recordId');
            me.EmployeeId = recordId;
            var recordCode = $(this).data('recordCode');
            me.EmployeeCode = recordCode;
            console.log(recordId);
            // gọi service lấy thông tin chi tiết qua id
            $('.loading').show();
            $.ajax({
                url: me.host + me.apiRouter + `/${recordId}`,
                method: 'GET',
                async: true,
            }).done(function (res) {
                // bindding dữ liệu lên form thông tin chi tiết
                //console.log(res);
                // lấy tất cả các control nhập liệu
                var inputs = $('input[fieldName], select[fieldName]');
                var entity = {};
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = res[propertyName];
                    //$(this).val(value);
                    ////console.log(value);
                    ////check với trường hợp input là radio, thì chỉ lấy value của input có attribute là checked
                    //if ($(this).attr("type") == "radio") {
                    //    if (this.checked) {
                    //        entity[propertyName] = value;
                    //    }
                    //}
                    //else {
                    //    entity[propertyName] = value;
                    //}
                    // Đối với dropdowlist (select option):
                    if (this.tagName == "SELECT") {
                        if (this.id == "cbxGender" || this.id == "cbxWorkStatus") {
                            $(this).val(value);
                        }
                        else {
                            var propValueName = $(this).attr('fieldValue');
                            value = res[propValueName];
                        }
                    }
                   
                    // Đối với các input là radio:
                    if ($(this).attr('type') == "radio") {
                        var inputValue = this.value;

                        if (value == inputValue) {
                            this.checked = true;
                        } else {
                            this.checked = false;
                        }
                    }
                    // Đối với các input là date:
                    if ($(this).attr('type') == "date") {
                        var date = new Date(value);
                        var day = date.getDate();
                        var month = date.getMonth() + 1;
                        var year = date.getFullYear();
                        day = day < 10 ? '0' + day : day;
                        month = month < 10 ? '0' + month : month;
                        value = year + "-" + month + "-" + day;
                    }
                    $(this).val(value);
                })
                $('.loading').hide();
            }).fail(function (res) {
                $('.loading').hide();
            })
            $('.m-dialog').show();
        })


        /*-------------------------------
         Thực hiện form xác nhận xóa
         Author: DVVUONG (17/01/2021)
         */
        $('#v-btnDelete').click(function () {
            var span = $('#idRowDel');
            span.empty();
            span.append(me.EmployeeCode);
            // hiển thị form xác nhận xóa
            $('#m-popup-confirmDel').show();
        });

        /*----------------------------------------------------------------------
         Thực hiện xóa record khi nhấn nút [Xóa] trên form giao diện xác nhận xóa
         Author: DVVUONG (17/01/2021)
         */
        $('#btnDel').click(function () {
            var stringUrl = me.host + me.apiRouter + `/${me.EmployeeId}`;
            $.ajax({
                url: stringUrl,
                method: 'DELETE',
                data: JSON.stringify(),
                contentType: 'application/json',
            }).done(function (res) {
                // sau khi lưu thành công thi: 
                // + đưa ra thông báo thành công
                // + ẩn form chi tiết
                // + load lại dữ liệu

                var showPopup = $('div .warning-success');
                showPopup.empty();
                showPopup.append($(`<i class="fas fa-info-circle"></i>&nbsp;<p>` + res.Messenger + `</p>`));
                $(".m-inform").show().delay(5000).fadeOut(
                );
                $('#m-popup-confirmDel').hide();
                $('.m-dialog').hide();
                me.loadData();

            }).fail(function (res) {
                var MISACode = res.responseJSON.MISACode;
                var Msgs = res.responseJSON["Data"];
                if (MISACode == 900) {
                    var ul = $('#pop-up ul');
                    ul.empty();
                    for (var i = 0; i < Msgs.length; i++) {
                        var value = Msgs[i];
                        var li = $('<li><i class="fas fa-exclamation-triangle"></i></li>');
                        li.append(value);
                        ul.append(li);
                    }
                    $("#pop-up").show().delay(5000).fadeOut();
                }
            })
        });


       
        /*---------------------------------
         * validate bắt buộc nhập 
         * Author: dvvuong (11/01/2021)
         */
        $('input[required]').blur(function () {
            // kiểm tra dữ liệu đã nhập, nếu để trống thì cảnh báo
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', "Trường này không được phép trống");
                $(this).attr('validate', false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })

        /*--------------------------------------
         validate Email
         Author: dvvuong (13/01/2021)
         */
        $('input[type="email"]').blur(function () {
            var valueToTest = $(this).val();
            var testEmail = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            if (!testEmail.test(valueToTest)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Email không đúng định dạng');
                $(this).attr("validate", false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        })

        /*--------------------------------
         validate Salary
         Author: DVVUONG (15/01/2021)
         */
        $('input[id="txtSalary"], input[id="txtPhoneNumber"]').blur(function () {
            var valueToTest = $(this).val();
            var testSalary = /^\d+$/;
            if (!testSalary.test(valueToTest)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không đúng định dạng');
                $(this).attr("validate", false);
            }
            else {
                $(this).removeClass('border-red');
                $(this).attr("validate", true);
            }
        })

    }

    /**------------------------------------
     * Load dữ liệu
     * CreatedBy: dvvuong (31/12/2020)
     * */
    loadData() {
        var me = this;
        try {
            $('table tbody').empty();
            // lấy thông tin các cột dữ liệu
            var columns = $('table thead th');
            var getDataUrl = this.getDataUrl;
            $('.loading').show();
            $.ajax({
                url: me.host + me.apiRouter,
                method: "GET",
                async: true,
            }).done(function (res) {
                //console.log(res);
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $(tr).data('recordId', obj.EmployeeId);
                    $(tr).data('recordCode', obj.EmployeeCode);
                    // lấy thông tin dữ liệu sẽ map tương ứng với các cột
                    $.each(columns, function (index, th) {
                        var td = $('<td><div><span></span></div></td>');
                        var fieldName = $(th).attr('fieldname');
                        var value = obj[fieldName];
                        var formatType = $(th).attr('formatType');
                        switch (formatType) {
                            case "ddmmyyyy":
                                td.addClass("text-align-center");
                                value = formatDate(value);
                                break;
                            case "MoneyVND":
                                td.addClass("text-align-right");
                                value = formatMoney(value);
                                break;
                            case "Gender":
                                value = formatGender(value);
                                break;
                            case "WorkStatus":
                                value = formatWorkStatus(value);
                                break;
                            default:
                                break;
                        }
                        td.append(value);
                        $(tr).append(td);
                    })
                    $('table tbody').append(tr);
                })
                $('.loading').hide();
            }).fail(function (res) {
                $('.loading').hide();
                // ghi log lỗi
            })
        } catch (e) {
            console.log(e);

        }

    }

    /**----------------------------------------
     * hàm thực hiện khi nhấn button thêm mới
     * Author: dvvuong (12/01/2021)
     * */
    btnAddOnClick() {
        try {
            // ẩn nút xóa
            $('#v-btnDelete').hide();
            //focus input 
            //$('input[id=txtEmployeeCode]').focus(function () {
            //    //$(this).blur();
            //    $(this).addClass('border-red');
            //});
            var me = this;
            me.FormMode = 'Add';
            //$('input[id="txtEmployeeCode"]').focus();
            // Hiển thị dialog thông tin chi tiết
            $('.m-dialog').show();
            $('input').val(null);
            // load dữ liệu cho các combobox
            me.loadCombobox();
            // lấy dữ liệu nhóm khách hàng
            $('.loading').show();
            $.ajax({
                url: me.host + "/api/v1/customergroups",
                method: "GET",
            }).done(function (res) {
                if (res) {
                    $.each(res, function (index, obj) {
                        var option = $(`<option value="${obj.CustomerGroupId}">${obj.CustomerGroupName}</option>`);
                        select.append(option);
                    })

                }
                $('.loading').hide();
            }).fail(function (res) {
                $('.loading').hide();
            })
        } catch (e) {
            console.log(e);
        }
    }

    /**------------------------------------------
     * hàm thực hiện khi nhấn button Lưu
     * Author: dvvuong (12/01/2021)
     * */
    btnSaveOnClick() {
        var me = this;
        // Validate dữ liệu
        var inputValidate = $('input[required], input[type ="email"], input[id="txtSalary"]');
        $.each(inputValidate, function (index, input) {
            $(input).trigger('blur');
        })
        var inputNotValis = $('input[validate="false"]');
        if (inputNotValis && inputNotValis.length > 0) {
            $(".warning").show().delay(3000).fadeOut();
            inputNotValis[0].focus();
            return;
        }
        // thu thập thông tin dữ liệu được nhập -> build thành object
        // lấy tất cả các control nhập liệu
        var inputs = $('input[fieldName], select[fieldName]');

        var entity = {};
        $.each(inputs, function (index, input) {
            var propertyName = $(this).attr('fieldName');
            var propertyValue = $(this).attr('fieldValue');
            var value = $(this).val();
            // check với trường hợp input là radio, thì chỉ lấy value của input có attribute là checked
            if ($(this).attr("type") == "radio") {
                if (this.checked) {
                    entity[propertyName] = value;
                }
            }
            else if (propertyValue) {
                entity[propertyValue] = value;
            }
            else {
                entity[propertyName] = value;
            }
            

        })
        // gọi service tương ứng thực hiện lưu dữ liệu
        var method = "POST";
        if (me.FormMode == "Edit") {
            method = "PUT";
            entity.EmployeeId = me.EmployeeId;
        }
        var stringUrl = me.host + me.apiRouter;
        if (me.FormMode == "Edit") {
            stringUrl = me.host + me.apiRouter + `/${entity.EmployeeId}`;
        }
        
        $.ajax({
            url: stringUrl,
            method: method,
            data: JSON.stringify(entity),
            contentType: 'application/json',
            async: true,
        }).done(function (res) {
            // sau khi lưu thành công thi: 
            // + đưa ra thông báo thành công
            // + ẩn form chi tiết
            // + load lại dữ liệu

            var showPopup = $('div .warning-success');
            showPopup.empty();
            showPopup.append($(`<i class="fas fa-info-circle"></i>&nbsp;<p>` + res.Messenger + `</p>`));
            $(".m-inform").show().delay(5000).fadeOut(
            );
   
            $('.m-dialog').hide();
            me.loadData();
            
        }).fail(function (res) {
            var MISACode = res.responseJSON.MISACode;
            var Msgs = res.responseJSON["Data"];
            if (MISACode == 900) {
                var ul = $('#pop-up ul');
                ul.empty();
                for (var i = 0; i < Msgs.length; i++) {
                    var value = Msgs[i];
                    var li = $('<li><i class="fas fa-exclamation-triangle"></i></li>');
                    li.append(value);
                    ul.append(li);
                }
                $("#pop-up").show().delay(6000).fadeOut();
            }
        })
    }


    /**------------------------------------------
     * hàm thực hiện khi nhấn button Refresh
     * Author: dvvuong (12/01/2021)
     * */
    btnRefreshOnClick() {
        
        var me = this;
        me.loadData();
        var showPopup = $('div .warning-success');
        showPopup.empty();
        showPopup.append($(`<i class="fas fa-info-circle"></i>&nbsp;<p>` + `Load dữ liệu thành công` + `</p>`));
        $(".m-inform").show().delay(5000).fadeOut(
        );
    }

    /**------------------------------------------
    * hàm thực hiện khi nhấn button Huy và khi đóng form chi tiết
    * Author: dvvuong (12/01/2021)
    * */
    btnCancelOnClick() {
        // Hiển thị dialog thông tin chi tiết
        $('.m-dialog').hide();
    }

    /**
     * hàm thực hiện load dữ liêu cho các combobox
     * */
    loadCombobox() {
        var me = this;
        var selects = $('select[api]');
        $.each(selects, function (index, select) {
            $(select).empty();
            var api = $(select).attr('api');
            if (api == "/api/v1/positions") {
                // lấy dữ liệu combobox
                $('.loading').show();
                $.ajax({
                    url: me.host + api,
                    method: "GET",
                }).done(function (res) {
                    if (res) {
                        $.each(res, function (index, obj) {
                            var option = $(`<option value="${obj.PositionId}">${obj.PositionName}</option>`);
                            $('select[fieldName=PositionName]').append(option);
                        })

                    }
                    $('.loading').hide();
                }).fail(function (res) {
                    $('.loading').hide();
                })
            }
            if (api == "/api/v1/departments") {
                // lấy dữ liệu combobox
                $('.loading').show();
                $.ajax({
                    url: me.host + api,
                    method: "GET",
                }).done(function (res) {
                    if (res) {
                        $.each(res, function (index, obj) {
                            var option = $(`<option value="${obj.DepartmentId}">${obj.DepartmentName}</option>`);
                            $('select[fieldName=DepartmentName]').append(option);
                        })

                    }
                    $('.loading').hide();
                }).fail(function (res) {
                    $('.loading').hide();
                })
            }
        })
    }

}