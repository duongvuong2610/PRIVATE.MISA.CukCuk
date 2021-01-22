using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Vị trí công việc
    /// </summary>
    public class Position : BaseEntity
    {
        public Guid PositionId { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string Description { get; set; }

    }
}
