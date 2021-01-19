using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// CreatedBy: DVVUONG (19/01/2021)
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);

        /// <summary>
        /// Lấy danh sách khách hàng theo nhóm khách hàng
        /// </summary>
        /// <param name="groupId">id nhóm khách hàng</param>
        /// <returns>list khách hàng</returns>
        /// CreatedBy: DVVUONG (19/01/2021)
        IEnumerable<Customer> GetCustomerByGroup(Guid groupId);
    }
}
