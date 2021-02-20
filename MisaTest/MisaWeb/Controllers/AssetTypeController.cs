
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
    public class AssetTypeController: BaseController<AssetType>
    {
        public AssetTypeController(IAssetTypeBL _assetBL) : base(_assetBL)
        {
           

        }
    }
}
