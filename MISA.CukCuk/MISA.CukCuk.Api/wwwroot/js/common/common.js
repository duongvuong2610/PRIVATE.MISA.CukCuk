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
