﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MISA.CukCuk.Web.Api;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api
{
    /// <summary>
    /// Api khách hàng
    /// </summary>
    /// CreatedBy: dvvuong (16/01/2021)
    public class CustomersController : BaseEntityController<Customer>
    {
        #region Declare
        ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomersController(ICustomerService customerService) :base(customerService)
        {
            _customerService = customerService;
        }
        #endregion
    }
}
