﻿using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.ApplicationCore
{
    public class CustomerService : BaseService<Customer> ,ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion


        #region Method

        public override ServiceResult Add(Customer entity)
        {
            return base.Add(entity);
        }

        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        // sửa thông tin khách hàng

        // xóa khách hàng

        #endregion
    }
}
