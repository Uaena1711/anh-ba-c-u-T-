using Microsoft.AspNetCore.Mvc;
using MisaCommon.Domain;
using MisaServices.Interface;


namespace MisaWeb.Controllers
{
    [Route("api/v1/[controller]")]
    public class DepartmentController: BaseController<Department>
    {
        public DepartmentController(IDepartmentBL _departmentBL) : base(_departmentBL)
        {


        }

    }
}
