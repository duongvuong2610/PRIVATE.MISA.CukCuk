using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Object lưu kết quả truy vấn
    /// </summary>
    /// CreatedBy: DVVUONG (20/01/2021)
    public class ServiceResult
    {
        #region Property

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Lời thông báo
        /// </summary>
        public string Messenger { get; set; }

        /// <summary>
        /// MISACode của kết quả truy vấn
        /// </summary>
        public MISACode MISACode { get; set; }
        #endregion
    }
}
