using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Repository khách hàng
    /// </summary>
    /// CreatedBy: DVVUONG (14/01/2021)
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructor
        public CustomerRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy khách hàng theo Mã khách hàng
        /// </summary>
        /// <param name="customerCode">Mã khách hàng</param>
        /// <returns>object khách hàng</returns>
        /// CreatedBy: DVVUONG (14/01/2021)
        public Customer GetCustomerByCode(string customerCode)
        {
            var customerDuplicate = _dbConnection.Query<Customer>($"SELECT * FROM Customer WHERE CustomerCode = '{customerCode}'", commandType: CommandType.Text).FirstOrDefault();
            return customerDuplicate;
        }
        #endregion
    }
}
