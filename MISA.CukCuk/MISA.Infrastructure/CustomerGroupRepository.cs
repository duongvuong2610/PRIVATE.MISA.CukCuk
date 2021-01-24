using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Repository nhóm khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (14/01/2021)
    public class CustomerGroupRepository : ICustomerGroupRepository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Constructor
        public CustomerGroupRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public int AddCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomerGroup(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public CustomerGroup GetCustomerGroupByCode(string customerGroupCode)
        {
            throw new NotImplementedException();
        }

        public CustomerGroup GetCustomerGroupById(Guid customerGroupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerGroup> GetCustomerGroups()
        {
            return _dbConnection.Query<CustomerGroup>("SELECT * FROM CustomerGroup");
        }

        public int UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
