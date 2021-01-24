using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    /// <summary>
    /// Service Chức vụ
    /// </summary>
    /// CreatedBy: DVVUONG (18/01/2021)
    public class PositionService : BaseService<Position>, IPositionService
    {
        #region Declare
        IPositionRepository _positionRepository;
        #endregion

        #region Constructor
        public PositionService(IPositionRepository positionRepository): base(positionRepository)
        {
            _positionRepository = positionRepository;
        }
        #endregion
    }
}
