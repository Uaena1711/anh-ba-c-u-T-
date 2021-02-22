using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCommon.Domain
{
    /// <summary>
    /// Các kiểu dữ liệu của phòng ban
    /// CreatedBy: PNHai (18/01/2022)
    /// </summary>
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }
    }
}
