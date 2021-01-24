using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Api
{
    /// <summary>
    /// Api Chức vụ
    /// </summary>
    /// CreatedBy: DVVUONG (21/01/2021)
    public class PositionsController : BaseEntityController<Position>
    {
        #region Declare
        IPositionService _positionService;
        #endregion

        #region Constructor
        public PositionsController(IPositionService positionService):base(positionService)
        {
            _positionService = positionService;
        }
        #endregion
    }
}
