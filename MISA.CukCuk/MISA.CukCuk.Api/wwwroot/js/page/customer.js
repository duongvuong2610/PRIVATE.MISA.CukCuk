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

    /**
     * xét lại endpoint cho trang customer
     * Author: DVVUONG (08/01/2021)
     * */
    setApiRouter() {
        this.apiRouter = "/api/v1/customers";
    }


}

