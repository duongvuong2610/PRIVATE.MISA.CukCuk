using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Object Nhân viên
    /// </summary>
    /// CreatedBy: DVVUONG (21/01/2021)
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }


        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số chứng minh thư nhân dân
        /// </summary>
        public string IdentityCardCode { get; set; }

        /// <summary>
        /// Ngày cấp chứng minh thư nhân dân
        /// </summary>
        public DateTime? IdentityCardDate { get; set; }

        /// <summary>
        /// Nơi cấp chứng minh thư nhân dân
        /// </summary>
        public string IdentityCardPlace { get; set; }

        /// <summary>
        /// Email nhân viên
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Id vị trí công việc của nhân viên
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Id phòng ban nhân viên làm việc
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string EmployeeTaxCode { get; set; }

        /// <summary>
        /// Mức lương
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// ngày gia nhập công ty
        /// </summary>
        public DateTime? DateOfJoin { get; set; }

        /// <summary>
        /// Trạng thái công việc (0-nghỉ việc, 1-đang làm việc)
        /// </summary>
        public int? WorkStatus { get; set; }
        #endregion
    }
}
