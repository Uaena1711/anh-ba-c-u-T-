using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCommon.Domain
{
    public class Department
    {
        public Guid DepartmentId { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }
    }
}
