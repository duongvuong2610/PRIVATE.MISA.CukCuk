using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity: BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        protected IDbConnection _dbConnection = null;
        protected string _tableName;
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
            var recordAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    // Xử lý các kiểu dữ liệu (mapping dateType)
                    var parameters = MappingDbType(entity);
                    // thực thi commandText
                    recordAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                    // trả về kết quả (số bản ghi thêm mới được)
                    return recordAffects;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return recordAffects;
               
        }

        public int Delete(Guid entityId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { $"{_tableName}Id", entityId.ToString() }
            };
            DynamicParameters parameter = new DynamicParameters(dictionary);
            var res = 0;
            _dbConnection.Open();
            using(var transaction = _dbConnection.BeginTransaction())
            {
                res = _dbConnection.Execute($"Proc_Delele{_tableName}", param: parameter, commandType: CommandType.StoredProcedure);
                transaction.Commit();
            }
            return res;
        }

        public IEnumerable<TEntity> GetEntities()
        {
            // tạo commandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            // trả về dữ liệu 
            return entities;
        }

        public IEnumerable<TEntity> GetEntities(string storeName)
        {
            // tạo commandText
            var entities = _dbConnection.Query<TEntity>($"storeName", commandType: CommandType.Text);
            // trả về dữ liệu 
            return entities;
        }

        public TEntity GetEntityById(Guid entityId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { $"{_tableName}Id", entityId.ToString() }
            };
            DynamicParameters parameter = new DynamicParameters(dictionary);
            // tạo commandText
            var entity = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", param: parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            // trả về dữ liệu 
            return entity;
        }

        public int Update(TEntity entity)
        {
            // Xử lý các kiểu dữ liệu (mapping dateType)
            var parameters = MappingDbType(entity);
            // thực thi commandText
            var recordAffects = _dbConnection.Execute($"Proc_Update{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
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

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if(entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";

            }
            else if(entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entityReturn;
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
    }
}
