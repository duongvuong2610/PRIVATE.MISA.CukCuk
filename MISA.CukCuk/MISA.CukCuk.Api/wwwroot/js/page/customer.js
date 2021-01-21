$(document).ready(function () {
    $('.m-dialog').hide();
    new CustomerJS();
    //dialogDetail = $('.m-dialog').dialog(
    //    autoOpen: false,
    //);
    
})

/**
 * Class quản lý các sự kiện cho trang Customer
 * CreatedBy: dvvuong (31/12/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }

    setApiRouter() {
        this.apiRouter = "/api/v1/customers";
    }


}

