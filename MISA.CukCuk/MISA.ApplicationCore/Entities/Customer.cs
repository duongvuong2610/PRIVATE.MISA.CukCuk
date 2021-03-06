﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (16/01/2021)
    public class Customer : BaseEntity
    {
        #region Property
        /// <summary>
        /// Id khách hàng
        /// </summary>
        [PrimaryKey]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
       
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã khách hàng")]
        [MaxLength(20, "Ma khach hang khong vuot qua 20 ky tu")]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ tên khách hàng
        /// </summary>
        /// 
        [DisplayName("Họ và đệm")]
        public string FullName { get; set; }

        /// <summary>
        /// Mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Mã nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Số điện thoại khách hàng
        /// </summary>
        /// 
        [CheckDuplicate]
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        
        /// <summary>
        /// Tên công ty khách hàng làm việc
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string Address { get; set; }
        #endregion
    }
}
