using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion

        public int Add(TEntity entity)
        {
            // Xử lý các kiểu dữ liệu (mapping dateType)
            var parameters = MappingDbType(entity);
            // thực thi commandText
            var recordAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
            // trả về kết quả (số bản ghi thêm mới được)
            return recordAffects;
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetEntities()
        {
            // tạo commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu 
            return entities;
        }

        public TEntity GetEntityById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            // Xử lý các kiểu dữ liệu (mapping dateType)
            var parameters = MappingDbType(entity);
            // thực thi commandText
            var recordAffects = _dbConnection.Execute($"Proc_UpdateCustomer", param: parameters, commandType: CommandType.StoredProcedure);
            // trả về kết quả (số bản ghi thêm mới được)
            return recordAffects;
        }

        /// <summary>
        /// Mapping data type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType(TEntity entity)
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
    }
}
