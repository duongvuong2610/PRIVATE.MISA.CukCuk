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
    /// Api Phòng ban
    /// </summary>
    /// CreatedBy: DVVUONG (19/01/2021)
    public class DepartmentsController : BaseEntityController<Department>
    {
        #region Declare
        IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DepartmentsController(IDepartmentService departmentService):base(departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion 
    }
}
