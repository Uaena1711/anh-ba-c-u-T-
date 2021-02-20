using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCommon.Domain
{
    public class ServiceResult
    {
        #region Declare

        /// <summary>
        /// Khởi tạo trạng thái success luôn bằng true
        /// </summary>
        public ServiceResult()
        {
            Success = true;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Trạng thái của Service (true - thành công, false - thất bại)
        /// </summary>
        public bool Success { get; set; }
        public object Data { get; set; }
        public string MISACode { get; set; }

        #endregion
    }
}
