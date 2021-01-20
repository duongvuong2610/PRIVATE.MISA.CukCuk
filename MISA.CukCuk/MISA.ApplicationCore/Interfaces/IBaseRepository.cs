﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        #region Method
        IEnumerable<TEntity> GetEntities();

        TEntity GetEntityById(Guid entityId);

        int Add(TEntity entity);
        
        int Update(TEntity entity);

        int Delete(Guid entityId);

        TEntity GetEntityByProperty(string propertyName, object propertyValue);
        #endregion
    }
}