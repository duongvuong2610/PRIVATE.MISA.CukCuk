﻿using Dapper;
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
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="TEntity">object generic</typeparam>
    /// CreatedBy: DVVUONG (17/01/2021)
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

        /// <summary>
        /// Thực hiện thêm mới object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
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
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return recordAffects;

        }

        /// <summary>
        /// Xóa object
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        public int Delete(Guid entityId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { $"{_tableName}Id", entityId.ToString() }
            };
            DynamicParameters parameter = new DynamicParameters(dictionary);
            var res = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    res = _dbConnection.Execute($"Proc_Delete{_tableName}", param: parameter, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            return res;
        }

        /// <summary>
        /// lấy toàn bộ danh sách
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        public IEnumerable<TEntity> GetEntities()
        {
            
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// lấy toàn bộ danh sách
        /// </summary>
        /// <param name="storeName">store procedure</param>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        public IEnumerable<TEntity> GetEntities(string storeName)
        {
            // tạo commandText
            var entities = _dbConnection.Query<TEntity>($"storeName", commandType: CommandType.Text);
            // trả về dữ liệu 
            return entities;
        }

        /// <summary>
        /// lấy object theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>object</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
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

        /// <summary>
        /// Cập nhật thông tin object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
        public int Update(TEntity entity)
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
                    recordAffects = _dbConnection.Execute($"Proc_Update{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                
            }

            return recordAffects;
        }

        /// <summary>
        /// Mapping data type
        /// </summary>
        /// <typeparam name="TEntity">objec generic</typeparam>
        /// <param name="entity">object</param>
        /// <returns></returns>
        /// CreatedBy: DVVUONG (17/01/2021)
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

        /// <summary>
        /// lấy object theo property
        /// </summary>
        /// <param name="entity">object</param>
        /// <param name="property">property</param>
        /// <returns>object</returns>
        /// CreatedBy: DVVUONG (17/01/2021)
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

        /// <summary>
        /// Ngắt kết nói tới CSDL
        /// </summary>
        /// CreatedBy: DVVUONG (22/01/2021)
        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
    }
}
