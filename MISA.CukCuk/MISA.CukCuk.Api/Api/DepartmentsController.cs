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
    public class DepartmentsController : BaseEntityController<Department>
    {
        IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService):base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
