using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Repository Chức vụ
    /// </summary>
    /// CreatedBy: DVVUONG (21/01/2021)
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        #region Constructor
        public PositionRepository(IConfiguration configuration):base(configuration)
        {

        }
        #endregion
    }
}
