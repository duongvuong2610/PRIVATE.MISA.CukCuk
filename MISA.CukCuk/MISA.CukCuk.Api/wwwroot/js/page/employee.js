$(document).ready(function () {
    $('.m-dialog').hide();
    new EmployeeJS();
})

/**
 * Class quản lý các sự kiện cho trang Employee
 * CreatedBy: dvvuong (31/12/2020)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }

    /**
     * xét lại endpoint cho trang employee
     * Author: DVVUONG (08/01/2021)
     * */
    setApiRouter() {
        this.apiRouter = "/api/v1/employees";
    }
}
