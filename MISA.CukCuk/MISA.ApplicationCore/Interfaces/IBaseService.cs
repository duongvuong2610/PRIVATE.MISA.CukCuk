using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface giao tiếp giữa tầng Web và Core
    /// </summary>
    /// <typeparam name="TEntity">object generic</typeparam>
    /// CreaetedBy: DVVUONG (17/01/2021)
    public interface IBaseService<TEntity>
    {
        #region Method

        /// <summary>
        /// lấy toàn bộ danh sách 
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// lấy đối tượng theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>object</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        TEntity GetEntityById(Guid entityId);

        /// <summary>
        /// Thực hiện thêm mới object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Object chứa kết quả truy vấn</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Thực hiện cập nhập objet theo khóa chính
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Object chứa kết quả truy vấn</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        ServiceResult Update(TEntity entity);

        /// <summary>
        /// Thực hiện xóa object theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>Object chứa kết quả truy vấn</returns>
        /// createdBy: DVVUONG (17/01/2021)
        ServiceResult Delete(Guid entityId);
        #endregion
    }
}
