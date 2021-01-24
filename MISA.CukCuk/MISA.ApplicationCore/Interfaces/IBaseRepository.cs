using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface giao tiếp giữa Core và Infrastructure
    /// </summary>
    /// <typeparam name="TEntity">Object generic</typeparam>
    /// CreaetedBy: DVVUONG (17/01/2021)
    public interface IBaseRepository<TEntity>
    {
        #region Method
        /// <summary>
        /// lấy toàn bộ danh sách
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        IEnumerable<TEntity> GetEntities();

        /// <summary>
        /// lấy toàn bộ danh sách
        /// </summary>
        /// <param name="storeName">store procedure</param>
        /// <returns>danh sách đối tượng</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        IEnumerable<TEntity> GetEntities(string storeName);

        /// <summary>
        /// lấy đối tượng theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>object</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        TEntity GetEntityById(Guid entityId);

        /// <summary>
        /// Thêm mới object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>số lượng bản ghi bị ảnh hưởng</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        int Add(TEntity entity);

        /// <summary>
        /// Cập cập thông tin object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        int Update(TEntity entity);

        /// <summary>
        /// Xóa object theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        int Delete(Guid entityId);

        /// <summary>
        /// Lấy object theo thuộc tính
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="property">property</param>
        /// <returns>object thỏa mã có property là tham số truyền vào</returns>
        /// CreaetedBy: DVVUONG (17/01/2021)
        TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
        #endregion
    }
}
