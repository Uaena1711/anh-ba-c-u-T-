using Microsoft.AspNetCore.Mvc;
using MisaCommon.Domain;
using MisaServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaWeb.Controllers
{
    [Route("api/v1/[controller]")]
    public class AssetController: BaseController<Asset>
    {
        private readonly IAssetBL assetBL;
        public AssetController(IAssetBL _assetBL, IAssetBL BL) : base(_assetBL)
        {
            assetBL = BL;

        }


        /// <summary>
        /// Lấy dữ liệu theo tiêu chí khác nhau
        /// </summary>
        /// <param name="filter">Tham số để tìm theo AssetCode hoặc AssetName</param>
        /// <param name="year">Tìm theo năm</param>
        /// <param name="DepartId">Tìm theo phòng</param>
        /// <param name="TypeId">Tìm theo loại tài sản</param>
        /// <returns>Data and Status Code </returns>
        /// CreatedBy: PNHai (18/02/2021)

        [HttpGet("filter")]
        public  IActionResult Get([FromQuery] string filter, [FromQuery] int? year, [FromQuery] Guid? DepartId, [FromQuery] Guid? TypeId)
        {
            // Lấy dữ liệu
            var result = assetBL.GetDataFilter(filter, year, DepartId, TypeId);
            // Ép kiểu thành dạng List<TEntity> để có thể kiểm tra số lượng bản ghi
            var entities = result.Data as List<Asset>;
            // Kiểm tra trạng thái trả về
            if (result.Success)
            {
                if (entities.Count == 0)
                    return StatusCode(204, entities);
                else
                    return StatusCode(200, entities);
            }
            else
            {
                return StatusCode(404, entities);
            }
        }

       
    }
}
