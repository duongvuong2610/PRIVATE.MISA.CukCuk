using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Service Nhân viên
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository): base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion
    }
}
