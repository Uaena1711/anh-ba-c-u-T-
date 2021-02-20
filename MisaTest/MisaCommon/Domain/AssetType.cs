using System;
using System.Collections.Generic;
using System.Text;

namespace MisaCommon.Domain
{
    public class AssetType
    {
        public Guid AssetTypeId { get; set; }

        public string AssetTypeCode { get; set; }

        public string AssetTypeName { get; set; }
    }
}
