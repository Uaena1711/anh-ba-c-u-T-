using MisaCommon.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaServices.Interface
{
    public interface IAssetBL: IBaseBL<Asset>
    {
        ServiceResult GetDataFilter(string? filter, int? year, Guid? DepartId, Guid? TypeId);

    }
}
