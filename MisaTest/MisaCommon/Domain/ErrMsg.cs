using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCommon.Domain
{
    /// <summary>
    /// Các lỗi thông báo trả về tùy theo lỗi bị gặp 
    /// </summary>
    public class ErrMsg
    {
        public List<string> DevMsg { get; set; } = new List<string>();
        public List<string> UserMsg { get; set; } = new List<string>();
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceId { get; set; }
    }
}
