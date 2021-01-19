using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;

        public BaseEntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        #region Method
        /// <summary>
        /// lấy toàn bộ khách hàng 
        /// </summary>
        /// <returns>danh sách khách hàng</returns>
        /// CreaedBy: dvvuong (18/01/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }


        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="customer">object</param>
        /// <returns></returns>
        /// CreatedBy: dvvuong (17/01/2021)
        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var rowAffects = _baseService.Add(entity);
            return Ok(rowAffects);
        }

        ///// <summary>
        ///// Chỉnh sửa thông tin khách hàng theo id
        ///// </summary>
        ///// <param name="customer">object</param>
        ///// <returns></returns>
        ///// CreatedBy: dvvuong (17/01/2021)
        //[HttpPut]
        //public IActionResult Put([FromBody] Customer customer)
        //{
        //    var resoult = _dbConnector.Update<Customer>(customer);
        //    return Ok(resoult);
        //}

        /// <summary>
        /// xóa khách hàng
        /// </summary>
        /// <param name="customerid">id</param>
        /// <returns></returns>
        /// createdby: dvvuong (17/01/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowAffects = _baseService.Delete(entityId);
            return Ok(rowAffects);
        }

        #endregion
    }
}
