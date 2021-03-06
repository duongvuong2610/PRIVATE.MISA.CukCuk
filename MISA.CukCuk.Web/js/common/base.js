﻿
class BaseJS {
    constructor() {
        this.host = "http://localhost:50060";
        this.apiRouter = null;
        this.setApiRouter();
        this.initEvents();
        this.loadData();
    }

    setApiRouter() {

    }


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

       

        // Hiển thi thông tin chi tiết khi nhấn đúp chuột vào 1 bản ghi trên danh sách dữ liệu

        $('table tbody').on('dblclick', 'tr', function () {
            $(this).find('td').addClass('row-selected');
            // load form
            var selects = $('select[fieldName]');
            selects.empty();
            $.each(selects, function (index, select) {
                // lấy dữ liệu nhóm khách hàng
                var api = $(select).attr('api');
                var fieldName = $(select).attr('fieldName');
                var fieldValue = $(select).attr('fieldValue');
                $('.loading').show();
                $.ajax({
                    url: me.host + api,
                    method: "GET",
                }).done(function (res) {
                    if (res) {
                        $.each(res, function (index, obj) {
                            var option = $(`<option value="${obj[fieldName]}">${obj[fieldValue]}</option>`);
                            select.append(option);
                        })

                    }
                    $('.loading').hide();
                }).fail(function (res) {
                    $('.loading').hide();
                })
            })
            
            // them trang thái form 
            me.FormMode = 'Edit';
            // lấy khóa chính của bản ghi
            var recordId = $(this).data('recordId');
            me.CustomerId = recordId;
            console.log(recordId);
            // gọi service lấy thông tin chi tiết qua id
            $.ajax({
                url: me.host + me.apiRouter + `/${recordId}`,
                method: 'GET',
            }).done(function (res) {
                // bindding dữ liệu lên form thông tin chi tiết    
                console.log(res);
                // lấy tất cả các control nhập liệu
                var inputs = $('input[fieldName], select[fieldName]');
                var entity = {};
                $.each(inputs, function (index, input) {
                    var propertyName = $(this).attr('fieldName');
                    var value = res[propertyName];
                    $(this).val(value);
                    //console.log(value);
                    // check với trường hợp input là radio, thì chỉ lấy value của input có attribute là checked
                    //if ($(this).attr("type") == "radio") {
                    //    if (this.checked) {
                    //        entity[propertyName] = value;
                    //    }
                    //}
                    //else {
                    //    entity[propertyName] = value;
                    //}
                })
            }).fail(function (res) {

            })
            $('.m-dialog').show();
        })

        /*
         * validate bắt buộc nhập 
         * Created: dvvuong (11/01/2021)
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

    }

    /**
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
                async: false,
            }).done(function (res) {
                $.each(res, function (index, obj) {
                    var tr = $(`<tr></tr>`);
                    $(tr).data('recordId', obj.CustomerId);
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
            var me = this;
            me.FormMode = 'Add';
            // Hiển thị dialog thông tin chi tiết
            $('.m-dialog').show();
            $('input').val(null);
            // load dữ liệu cho các combobox
            var select = $('select#cbxCustomerGroup');
            select.empty();
            // lấy dữ liệu nhóm khách hàng
            $('.loading').show();
            $.ajax({
                url: me.host + "/api/customergroups",
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
        var inputValidate = $('input[required], input[type = "email"]');
        $.each(inputValidate, function (index, input) {
            $(input).trigger('blur');
        })
        var inputNotValis = $('input[validate="false"]');
        if (inputNotValis && inputNotValis.length > 0) {
            alert("Dữ liệu không hợp lệ vui lòng kiểm tra lại.");
            inputNotValis[0].focus();
            return;
        }
        // thu thập thông tin dữ liệu được nhập -> build thành object
        // lấy tất cả các control nhập liệu
        var inputs = $('input[fieldName], select[fieldName]');
        var entity = {};
        $.each(inputs, function (index, input) {
            var propertyName = $(this).attr('fieldName');
            var value = $(this).val();
            // check với trường hợp input là radio, thì chỉ lấy value của input có attribute là checked
            if ($(this).attr("type") == "radio") {
                if (this.checked) {
                    entity[propertyName] = value;
                }
            }
            else {
                entity[propertyName] = value;
            }
        })
        // gọi service tương ứng thực hiện lưu dữ liệu
        var method = "POST";
        if (me.FormMode == "Edit") {
            method = "PUT";
            entity.CustomerId = me.CustomerId;
        }
        $.ajax({
            url: me.host + me.apiRouter,
            method: method,
            data: JSON.stringify(entity),
            contentType: 'application/json',
        }).done(function (res) {
            // sau khi lưu thành công thi: 
            // + đưa ra thông báo thành công
            // + ẩn form chi tiết
            // + load lại dữ liệu
            alert("Thêm dữ liệu thành công");
            $('.m-dialog').hide();
            me.loadData();
        }).fail(function (res) {
            alert("fail insert data");
        })
    }


    /**------------------------------------------
     * hàm thực hiện khi nhấn button Refresh
     * Author: dvvuong (12/01/2021)
     * */
    btnRefreshOnClick() {
        var me = this;
        me.loadData();
    }

    /**------------------------------------------
    * hàm thực hiện khi nhấn button Huy và khi đóng form chi tiết
    * Author: dvvuong (12/01/2021)
    * */
    btnCancelOnClick() {
        // Hiển thị dialog thông tin chi tiết
        $('.m-dialog').hide();
    }

}