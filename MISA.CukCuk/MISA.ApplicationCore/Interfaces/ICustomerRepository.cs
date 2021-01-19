using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface danh mục khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public interface ICustomerRepository
    {
        #region Method
        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// Lấy khách hàng theo id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns>object khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        Customer GetCustomerById(Guid customerId);

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns>số bản ghi thêm mới được</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int AddCustomer(Customer customer);

        /// <summary>
        /// Chỉnh sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">object khách hàng</param>
        /// <returns>số bản ghi bị ảnh hưởng(chỉnh sửa được)</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int UpdateCustomer(Customer customer);

        /// <summary>
        /// Xóa khách hàng theo id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns>số bản ghi bị ảnh hưởng(bị xóa)</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int DeleteCustomer(Guid customerId);

        /// <summary>
        /// Lấy khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerCode">mã khách hàng</param>
        /// <returns>object khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        Customer GetCustomerByCode(string customerCode);
        #endregion
    }
}
