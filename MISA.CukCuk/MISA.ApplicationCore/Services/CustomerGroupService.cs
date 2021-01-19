using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class CustomerGroupService : ICustomerGroupService
    {
        ICustomerGroupRepository _customerGroupRepository;

        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
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
    }
}
