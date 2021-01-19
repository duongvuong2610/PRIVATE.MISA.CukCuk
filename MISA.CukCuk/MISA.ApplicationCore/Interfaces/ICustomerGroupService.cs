using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface ICustomerGroupService
    {
        IEnumerable<CustomerGroup> GetCustomerGroups();
        CustomerGroup GetCustomerGroupById(Guid customerGroupId);
        ServiceResult AddCustomerGroup(CustomerGroup customerGroup);
        ServiceResult UpdateCustomerGroup(CustomerGroup customerGroup);
        ServiceResult DeleteCustomerGroup(Guid customerGroupId);
    }
}
