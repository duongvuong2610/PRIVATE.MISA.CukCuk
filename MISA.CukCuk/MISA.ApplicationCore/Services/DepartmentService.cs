using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Service Phòng ban
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public class DepartmentService: BaseService<Department>, IDepartmentService
    {
        #region Declare
        IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository) :base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
    }
}
