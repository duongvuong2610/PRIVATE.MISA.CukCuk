using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        IBaseRepository<TEntity> _baseRepository;

        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        #endregion

        #region Method
        public virtual int Add(TEntity entity)
        {
            var isValid = Validate(entity);
            if(isValid == true)
            {
                return _baseRepository.Add(entity);
            }
            else
            {
                return 0;
            }
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        public virtual IEnumerable<TEntity> GetEntities()
        {
            return _baseRepository.GetEntities();
        }

        public TEntity GetEntityById(Guid entityId)
        {
            return _baseRepository.GetEntityById(entityId);
        }

        public int Update(TEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        private bool Validate(TEntity entity)
        {
            var isValidate = true;
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                // kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // check bat buoc nhap
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        isValidate = false;
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // check trùng dữ liệu
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(property.Name, property.GetValue(entity));
                    if (entityDuplicate != null)
                    {
                        isValidate = false;
                    }
                }


            }
            return isValidate;
        }

        #endregion
    }
}
