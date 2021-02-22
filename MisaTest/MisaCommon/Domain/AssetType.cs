using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCommon.Domain
{
    /// <summary>
    /// Các kiểu dữ liệu của tài sản
    /// CreatedBy: PNHai (18/01/2022)
    /// </summary>
    public class AssetType
    {
        public Guid AssetTypeId { get; set; }

        public string AssetTypeCode { get; set; }

        public string AssetTypeName { get; set; }
    }
}
