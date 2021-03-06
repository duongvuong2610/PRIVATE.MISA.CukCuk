﻿using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Base Service 
    /// </summary>
    /// <typeparam name="TEntity">object generic</typeparam>
    /// CreatedBy: DVVUONG (18/01/2021)
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        #region Declare
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Enums.MISACode.Success };
           
        }
        #endregion

        #region Method
        /// <summary>
        /// Thêm mới object
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Object chứa thông tin kết quả truy vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.AddNew;
            var isValid = Validate(entity);
            
            if(isValid == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Messenger = Properties.Resources.Msg_AddSuccess;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Xóa Object
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>Object chứa thông tin kết quả truy vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            _serviceResult.MISACode = Enums.MISACode.Success;
            _serviceResult.Messenger = Properties.Resources.Msg_DeleteSuccess;
            return _serviceResult;
        }

        /// <summary>
        /// lấy toàn bộ danh sách đối tượng
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        public virtual IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        /// <summary>
        /// lấy đối tượng theo khóa chính
        /// </summary>
        /// <param name="entityId">khóa chính</param>
        /// <returns>object</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        public TEntity GetEntityById(Guid entityId)
        {
            return _baseRepository.GetEntityById(entityId);
        }

        /// <summary>
        /// cập nhật thông tin object 
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>Object chứa thông tin kết quả truy vấn</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValid = Validate(entity);
            if (isValid == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.Success;
                _serviceResult.Messenger = Properties.Resources.Msg_UpdateSuccess;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Hàm kiểm tra dữ liệu/ nghiệp vụ
        /// </summary>
        /// <param name="entity">object</param>
        /// <returns>boolean</returns>
        /// CreatedBy: DVVUONG (18/01/2021)
        private bool Validate(TEntity entity)
        {
            var mesArr = new List<string>();
            var isValidate = true;
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayNameAttributes.Length > 0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;
                }
                // kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // check bat buoc nhap
                    if (propertyValue == null || propertyValue.ToString() == "")
                    {
                        isValidate = false;
                        mesArr.Add(string.Format(Properties.Resources.Msg_Required, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // check trùng dữ liệu
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                        mesArr.Add(string.Format(Properties.Resources.Msg_Dulicate, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }

                if (property.IsDefined(typeof(MaxLength), false))
                {
                    // lay do dai da khai bao
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxLength as MaxLength).Value;
                    var msg = (attributeMaxLength as MaxLength).ErrorMsg;
                    if(propertyValue.ToString().Trim().Length > length)
                    {
                        isValidate = false;
                        mesArr.Add(msg??$"Thông tin này vượt quá {length} ky tu cho phep");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }
            }
            _serviceResult.Data = mesArr;
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }
            return isValidate;
        }

        /// <summary>
        /// Hàm kiểm tra dữ liệu/ nghiệp vụ tùy chỉnh
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }

        #endregion
    }
}
