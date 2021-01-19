$(document).ready(function () {
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

    setApiRouter() {
        this.apiRouter = "/api/employees";
    }
}
