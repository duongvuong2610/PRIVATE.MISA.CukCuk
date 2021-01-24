using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Api
{
    /// <summary>
    /// Api Nhân viên
    /// </summary>
    /// CreatedBy: DVVUONG (21/01/2021)
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region Declare
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion


    }
}
