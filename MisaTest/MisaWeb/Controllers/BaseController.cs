using Microsoft.AspNetCore.Mvc;
using MisaServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaWeb.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity>: ControllerBase
    {
       private readonly  IBaseBL<TEntity> _baseBL;


        #region CONSTRUCTOR
        public BaseController(IBaseBL<TEntity> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion


        #region CURD

        /// <summary>
        /// <summary>
        /// Phương thức GET - Đọc dữ liệu
        /// </summary>
        /// <returns>Data and Status Code </returns>
        /// CreatedBy: PNHai (18/02/2021)

        [HttpGet]
        public IActionResult Get()
        {
            // Lấy dữ liệu
            var result = _baseBL.GetData();
            // Ép kiểu thành dạng List<TEntity> để có thể kiểm tra số lượng bản ghi
            var entities = result.Data as List<TEntity>;
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
        /// <summary>
        /// Post dữ liệu vào bảng asset 
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <returns>Data and Status Code </returns>
        /// CreatedBy: PNHai (18/02/2021)

        [HttpPost]
        public IActionResult Post([FromBody] TEntity entity)
        {
            var result = _baseBL.Insert(entity);
            if (result.Success == false)
                return StatusCode(218, result.Data);
            return StatusCode(201, result.Data);
        }
        #endregion

        /// <summary>
        /// Sửa 1 thực thể đang có trong bảng 
        /// </summary>
        /// <param name="entity">Thực thể sau khi đã sửa vài thuộc tính</param>
        /// <returns>Data and Status Code </returns>
        /// CreatedBy: PNHai (18/02/2021)

        [HttpPut]
        public IActionResult Put([FromBody] TEntity entity)
        {
            // Kết quả trả về
            var result = _baseBL.Update(entity);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(400, result.Data);
            else if (result.Success == true && (int)result.Data > 0)
                return StatusCode(201, result.Data);
            return StatusCode(200, result.Data);
        }

        /// <summary>
        /// Xóa thực thể khỏi bảng
        /// </summary>
        /// <param name="id">Id của bản ghi</param>
        /// <returns>Data and Status Code </returns>
        /// CreatedBy: PNHai (18/02/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            // Kết quả trả về
            var result = _baseBL.Delete(id);
            // Kiểm tra trạng thái trả về
            if (result.Success == false)
                return StatusCode(404, result.Data);
            return StatusCode(204, result.Data);
        }
    }
}
