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
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        #region Method

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
