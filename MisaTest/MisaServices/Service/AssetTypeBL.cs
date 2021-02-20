using Misa.DL.Interface;
using MisaCommon.Domain;
using MisaServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisaServices.Service
{
    public class AssetTypeBL: BaseBL<AssetType>, IAssetTypeBL
    {
        public AssetTypeBL(IDbConnector<AssetType> _assetDL) : base(_assetDL)
        {
            
        }
    }
}
