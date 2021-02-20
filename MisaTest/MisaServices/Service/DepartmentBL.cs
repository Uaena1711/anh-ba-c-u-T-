using Misa.DL.Interface;
using MisaCommon.Domain;
using MisaServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisaServices.Service
{
    public class DepartmentBL: BaseBL<Department>, IDepartmentBL
    {
        public DepartmentBL(IDbConnector<Department> _departmentDL) : base(_departmentDL)
        {

        }
    }
}
