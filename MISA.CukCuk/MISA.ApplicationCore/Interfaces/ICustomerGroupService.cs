using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Iterface Service nhóm khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public interface ICustomerGroupService
    {
        #region Method
        /// <summary>
        /// lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>danh sách nhóm khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        IEnumerable<CustomerGroup> GetCustomerGroups();

        /// <summary>
        /// lấy nhóm khách hàng theo khóa chính
        /// </summary>
        /// <param name="customerGroupId">khóa chính</param>
        /// <returns>object</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        CustomerGroup GetCustomerGroupById(Guid customerGroupId);

        /// <summary>
        /// thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">object</param>
        /// <returns>Object chứa kết quả try vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        ServiceResult AddCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// cập nhật thông tin nhóm khách hàng
        /// </summary>
        /// <param name="customerGroup">object</param>
        /// <returns>Object chứa kết quả try vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        ServiceResult UpdateCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// xóa nhóm khách hàng theo khóa chính
        /// </summary>
        /// <param name="customerGroupId">khóa chính</param>
        /// <returns>Object chứa kết quả try vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        ServiceResult DeleteCustomerGroup(Guid customerGroupId);
        #endregion
    }
}
