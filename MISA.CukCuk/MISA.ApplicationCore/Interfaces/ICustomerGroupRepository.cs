using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface Repository nhóm khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public interface ICustomerGroupRepository
    {
        #region Method
        /// <summary>
        /// Lấy danh sách nhóm khách hàng
        /// </summary>
        /// <returns>Danh sách nhóm khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        IEnumerable<CustomerGroup> GetCustomerGroups();

        /// <summary>
        /// Lấy nhóm khách hàng theo id
        /// </summary>
        /// <param name="CustomerGroupId">id khách hàng</param>
        /// <returns>object nhóm khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        CustomerGroup GetCustomerGroupById(Guid customerGroupId);

        /// <summary>
        /// Thêm mới nhóm khách hàng
        /// </summary>
        /// <param name="CustomerGroup">object nhóm khách hàng</param>
        /// <returns>số bản ghi thêm mới được</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int AddCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Chỉnh sửa thông tin nhóm khách hàng
        /// </summary>
        /// <param name="CustomerGroup">object nhóm khách hàng</param>
        /// <returns>số bản ghi bị ảnh hưởng(chỉnh sửa được)</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int UpdateCustomerGroup(CustomerGroup customerGroup);

        /// <summary>
        /// Xóa nhóm khách hàng theo id
        /// </summary>
        /// <param name="CustomerGroupId">id nhóm khách hàng</param>
        /// <returns>số bản ghi bị ảnh hưởng(bị xóa)</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        int DeleteCustomerGroup(Guid customerGroupId);

        /// <summary>
        /// Lấy nhóm khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="CustomerGroupCode">mã nhóm khách hàng</param>
        /// <returns>object nhóm khách hàng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        CustomerGroup GetCustomerGroupByCode(string customerGroupCode);
        #endregion
    }
}
