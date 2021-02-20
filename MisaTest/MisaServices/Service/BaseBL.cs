using MisaCommon.Domain;

using Misa.DL.Interface;

using MisaServices.Interface;
using System;

namespace MisaServices.Service
{
    /// <summary>
    /// Lớp Base cho tầng business layer
    /// </summary>
    /// <typeparam name="TEntity">Object</typeparam>
    /// CreatedBy: PNHai (18/02/2021)
    public class BaseBL<TEntity> : IBaseBL<TEntity>
    {
        #region DECLARE
        IDbConnector<TEntity> _baseDL;
        protected ServiceResult _serviceResult;
        #endregion

        #region CONSTRUCTOR
        public BaseBL(IDbConnector<TEntity> baseDL)
        {
            _serviceResult = new ServiceResult();
            _baseDL = baseDL;
        }
        #endregion

        #region METHOD
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public virtual ServiceResult Delete(string id)
        {
            // Gọi đến tầng DataLayer để xóa bản ghi
            _serviceResult.Data = _baseDL.Delete(id);
            // Kiểm tra kết quả trả về
            if ((int)_serviceResult.Data > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public virtual ServiceResult GetData()
        {
            _serviceResult.Success = true;
            _serviceResult.Data = _baseDL.GetData();

            return _serviceResult;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public virtual ServiceResult Insert(TEntity entity)
        {
            // Khởi tạo object thông báo lỗi
            var errMsg = new ErrMsg();
            // Xử lý nghiệp vụ
            var isValidated = ValidateInsertAndUpdateData(entity, errMsg);
            // Kiểm tra và gửi lên tầng DataLayer thực hiện thêm mới vào cơ sở dữ liệu
            if (isValidated)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _baseDL.Insert(entity);
            }
            else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }

            return _serviceResult;
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>ServiceResult</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public ServiceResult Update(TEntity entity)
        {
            // Khởi tạo object thông báo lỗi
            var errMsg = new ErrMsg();
            // Xử lý nghiệp vụ
            var isValidated = ValidateInsertAndUpdateData(entity, errMsg);
            // Kiểm tra và gửi lên tầng DataLayer thực hiện cập nhật vào cơ sở dữ liệu
            if (isValidated)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = _baseDL.Update(entity);
            }
            else
            {
                _serviceResult.Success = false;
                _serviceResult.Data = errMsg;
            }

            return _serviceResult;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - nếu hợp lệ, false nếu không</returns>
        /// CreatedBy: PNHai (18/02/2021)
        protected virtual bool ValidateInsertAndUpdateData(TEntity entity, ErrMsg errMsg)
        {
            return true;
        }

        



        #endregion
    }
}
