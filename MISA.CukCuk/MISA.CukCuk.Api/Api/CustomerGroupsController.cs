using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Api
{
    /// <summary>
    /// Api nhóm khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (21/01/2021)

    public class CustomerGroupsController : BaseEntityController<CustomerGroup>
    {
        #region Declare
        IBaseService<CustomerGroup> _baseService;
        #endregion

        #region Constructor
        public CustomerGroupsController(IBaseService<CustomerGroup> baseService):base(baseService)
        {
            _baseService = baseService;
        }
        #endregion
    }
}
