using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Api
{
    /// <summary>
    /// Base Constroller Api
    /// </summary>
    /// <typeparam name="TEntity">object generic</typeparam>
    /// CreatedBy: DVVUONG (20/01/2021)

    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        #region Declare
        IBaseService<TEntity> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// lấy toàn bộ danh sách
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreaedBy: dvvuong (20/01/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }

        /// <summary>
        /// lấy danh sách theo id 
        /// </summary>
        /// <returns>IActionResult</returns>
        /// CreaedBy: dvvuong (20/01/2021)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entities = _baseService.GetEntityById(id);
            return Ok(entities);
        }


        /// <summary>
        /// Thêm mới object
        /// </summary>
        /// <param name="customer">object</param>
        /// <returns>IActionResult</returns>
        /// CreatedBy: dvvuong (20/01/2021)
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var serviceResult = _baseService.Add(entity);
            if(serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
        }

        /// <summary>
        /// Chỉnh sửa thông tin object
        /// </summary>
        /// <param name="customer">object</param>
        /// <returns></returns>
        /// CreatedBy: dvvuong (20/01/2021)
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id ,[FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if(keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if (keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }
            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
        }

        /// <summary>
        /// xóa object
        /// </summary>
        /// <param name="customerid">khóa chính</param>
        /// <returns></returns>
        /// Createdby: dvvuong (20/01/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var serviceResult = _baseService.Delete(entityId);
            if (serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
        }

        #endregion
    }
}
