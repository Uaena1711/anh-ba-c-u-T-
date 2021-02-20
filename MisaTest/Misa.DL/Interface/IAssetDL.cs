using MisaCommon.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.DL.Interface
{
    /// <summary>
    /// Interface của Asset liên kết trực tiếp với Database 
    /// </summary>
    public interface IAssetDL: IDbConnector<Asset>
    {
        public bool Duplicate(string propertyName, string propertyValue, string tableName);
        public IEnumerable<Asset> GetDataFilter(string? filter, int? year, Guid? DepartId, Guid? TypeId);

       
    }
}
