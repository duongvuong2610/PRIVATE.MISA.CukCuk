using MISA.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    
    /// <summary>
    /// Attribute kiểm tra không được để trống
    /// </summary>
    /// CreatedBy: DVVUONG (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class Required: Attribute
    {

    }
    /// <summary>
    /// Attribute kiểm tra không được trùng
    /// </summary>
    /// CreatedBy: DVVUONG (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate:Attribute
    {

    }

    /// <summary>
    ///  Attribute kiểm tra khóa chính
    /// </summary>
    /// CreatedBy: DVVUONG (22/02/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey:Attribute
    {

    }
    /// <summary>
    /// Attribute gán tên cho Property
    /// </summary>
    /// CreatedBy: DVUONG (22/01/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class DisplayName : Attribute
    {
        #region Property
        /// <summary>
        /// Tên thuộc tính muốn đặt
        /// </summary>
        public string Name { get; set; }
        #endregion
        #region Constructor
        public DisplayName(string name = null)
        {
            this.Name = name;
        }
        #endregion
    }

    /// <summary>
    /// Attribute kiểm tra độ dài theo yêu cầu
    /// </summary>
    /// CreatedBy: DVVUONG (22/01/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        #region Property
        /// <summary>
        /// Giá trị độ dài muốn đặt
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// chuỗi thông báo
        /// </summary>
        public string ErrorMsg { get; set; }
        #endregion

        #region Constructor
        public MaxLength(int lengh, string erroMsg = null)
        {
            this.Value = lengh;
            this.ErrorMsg = erroMsg;
        }
        #endregion
    }

    /// <summary>
    /// BaseEntity
    /// </summary>
    /// CreatedBy: DVVUONG (22/01/2021)
    /// 
    public class BaseEntity
    {
        #region Property
        /// <summary>
        /// Trạng thái của entity (Add, Update, Delete)
        /// </summary>
        public EntityState EntityState { get; set; } = EntityState.AddNew;

        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
