
using MisaCommon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaServices.Interface
{
    /// <summary>
    /// INTERFACE Base tầng Business Layer
    /// </summary>
    /// <typeparam name="TEntity">Object</typeparam>
    /// CreatedBy: PNHai (18/02/2021)
    public interface IBaseBL<TEntity>
    {
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        ///CreatedBy: PNHai (18/02/2021)
        ServiceResult GetData();

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        ServiceResult Insert(TEntity entity);

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        ServiceResult Update(TEntity entity);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        ServiceResult Delete(string id);
    }
}
