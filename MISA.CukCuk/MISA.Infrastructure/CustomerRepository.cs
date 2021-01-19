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
    public class CustomerRepository : ICustomerRepository
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        #endregion

        #region Contructor
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        public int AddCustomer(Customer customer)
        {
            // Xử lý các kiểu dữ liệu (mapping dateType)
            var parameters = MappingDbType(customer);
            // kết nối csdl
            var properties = customer.GetType().GetProperties();

            // Xử lý các kiểu dữ liệu (mapping dateType)
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(customer);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(customer).ToString();
                }
                parameters.Add($"@{propertyName}", propertyValue);
            }

            // thực thi commandText
            var recordAffects = _dbConnection.Execute($"Proc_InsertCustomer", param: parameters, commandType: CommandType.StoredProcedure);
            // trả về kết quả (số bản ghi thêm mới được)
            return recordAffects;
        }

        public int DeleteCustomer(Guid customerId)
        {
            var res = _dbConnection.Execute("Proc_DeleteCustomer", new {CustomerId = customerId.ToString() },commandType: CommandType.StoredProcedure);
            return res;
        }

        public Customer GetCustomerByCode(string customerCode)
        {
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerByCode", commandType: CommandType.StoredProcedure, param: new { CustomerCode = customerCode }).FirstOrDefault();
            return res;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            // tạo commandText
            var customer = _dbConnection.Query<Customer>("Proc_GetCustomerById", param: new { CustomerId = customerId}, commandType: CommandType.StoredProcedure).FirstOrDefault();
            // trả về dữ liệu 
            var res = _dbConnection.Query<Customer>("Proc_GetCustomerById", commandType: CommandType.StoredProcedure, param: new { CustomerId = customerId }).FirstOrDefault();
            return res;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            // tạo commandText
            var customers = _dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu 
            return customers;
        }

        public int UpdateCustomer(Customer customer)
        {
            // Xử lý các kiểu dữ liệu (mapping dateType)
            var parameters = MappingDbType(customer);
            // thực thi commandText
            var recordAffects = _dbConnection.Execute($"Proc_UpdateCustomer", param: parameters, commandType: CommandType.StoredProcedure);
            // trả về kết quả (số bản ghi thêm mới được)
            return recordAffects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType<TEntity>(TEntity entity)
        {
            var parameters = new DynamicParameters();
            var properties = entity.GetType().GetProperties();

            // Xử lý các kiểu dữ liệu (mapping dateType)
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
                {
                    propertyValue = property.GetValue(entity).ToString();
                }
                parameters.Add($"@{propertyName}", propertyValue);
            }
            return parameters;
        }
        #endregion
    }
}
