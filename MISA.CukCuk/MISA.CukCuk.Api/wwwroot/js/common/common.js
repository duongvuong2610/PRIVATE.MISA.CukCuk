/**------------------------------------------------------
 * format dữ liệu ngày tháng sang ngay/thang/nam
 * @param {any} date tham số có kiểu dữ liêu bất kỳ
 * CreatedBy: dvvuong (30/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    if (Number.isNaN(date.getTime())) {
        return "";
    }
    else {
        var day = date.getDate(),
            month = date.getMonth() + 1,
            year = date.getFullYear();
        day = day < 10 ? '0' + day : day;
        month = month < 10 ? '0' + month : month;
        return day + '/' + month + '/' + year;
    }

}

/** --------------------------------
 * Hàm định dạng hiển thị tiền tệ
 * @param {Number} money số tiền
 * CreatedBy: dvvuong (30/12/2020)
 */
function formatMoney(money) {
    if (money) {
        return money.toFixed(0).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
    }
    return "";
}

/**------------------------------------
 * Hàm định dạng hiển thị giới tính
 * @param {Number} gender giới tính
 * CreatedBy: DVVUONG (21/01/2021)
 */
function formatGender(gender) {
    if (gender == 0)
        return "Nam";
    else if (gender == 1)
        return "Nữ";
    else if (gender == 2)
        return "Khác";
    else
        return "";
}

/**-------------------------------------------
 * Hàm định dạng hiển thị trạng thái công việc
 * @param {number} status trạng thái
 * CreatedBy: DVVUONG (21/01/2021)
 */
function formatWorkStatus(status) {
    if (status == 0)
        return "Nghỉ việc";
    else if (status == 1)
        return "Đang làm việc";
    else
        return "";
}