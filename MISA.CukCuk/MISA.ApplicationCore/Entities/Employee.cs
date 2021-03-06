﻿using System;
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
        /// 
        [PrimaryKey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// 
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã nhân viên")]
        [MaxLength(20, "Mã nhân viên không vượt quá 20 ký tự")]
        public string EmployeeCode { get; set; }


        /// <summary>
        /// Họ và tên nhân viên
        /// </summary>
        /// 
        [Required]
        [DisplayName("Họ và tên")]
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
        /// 
        [Required]
        [CheckDuplicate]
        [DisplayName("Số chứng minh thư nhân dân")]
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
        /// 
        [Required]
        [CheckDuplicate]
        [DisplayName("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại nhân viên
        /// </summary>
        /// 
        [Required]
        [CheckDuplicate]
        [DisplayName("Số điện thoại")]
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

        /// <summary>
        /// Tên vị trí công việc
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Tên phòng ban làm việc
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion
    }
}
