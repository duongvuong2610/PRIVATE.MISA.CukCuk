using MISA.ApplicationCore.Entities;
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

        //public override int Add(Customer entity)
        //{
        //    // validate thông tin 
        //    var isValid = true;
        //    // 1. check trung ma khach hang
        //    var customerDuplicate = _customerRepository.GetCustomerByCode(entity.CustomerCode);
        //    if(customerDuplicate != null)
        //    {
        //        isValid = false;
        //    }
        //    // logic validate
        //    if (isValid == true)
        //    {
        //        return base.Add(entity);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

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
