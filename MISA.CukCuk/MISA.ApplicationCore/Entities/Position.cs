using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Object chức vụ
    /// </summary>
    /// CreatedBy: DVVUONG (20/01/2021)
    public class Position : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên chức vụ
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả 
        /// </summary>
        public string Description { get; set; }
        #endregion

    }
}
