using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Service nhóm khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public class CustomerGroupService : ICustomerGroupService
    {
        #region Declare
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        #region Constructor
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        #endregion

        #region Method
        public ServiceResult AddCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteCustomerGroup(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public CustomerGroup GetCustomerGroupById(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroups()
        {
            return _customerGroupRepository.GetCustomerGroups();
        }

        public ServiceResult UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
