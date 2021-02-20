using AutoMapper;
using Misa.DL.DL;
using Misa.DL.Interface;
using MisaCommon.Domain;



using MisaServices.Interface;
using System;

namespace MisaServices.Service
{
   
    public class AssetBL : BaseBL<Asset>, IAssetBL
    {
        private readonly IAssetDL assetDL;
        
        #region CONSTRUCTOR
        public AssetBL(IDbConnector<Asset> _assetDL, IAssetDL dL) : base(_assetDL)
        {
            assetDL = dL;
        }
        #endregion

        #region FUNCTION

        public ServiceResult GetDataFilter(string? filter, int? year, Guid? DepartId, Guid? TypeId)
        {
            _serviceResult.Success = true;
            _serviceResult.Data = assetDL.GetDataFilter(filter, year, DepartId, TypeId);

            return _serviceResult;
        }

        
        /// <summary>
        /// Kiểm tra dữ liệu khi thêm mới
        /// </summary>
        /// <param name="asset">Object</param>
        /// <param name="errMsg">Thông báo lỗi</param>
        /// <returns>bool (true - valid, false - invalid)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        protected override bool ValidateInsertAndUpdateData(Asset asset, ErrMsg errMsg)
        {
            var isValid = true;




                var properties = asset.GetType().GetProperties();

                foreach (var property in properties)
                {
                    var propertyValue = property.GetValue(asset);
               


                    if (property.IsDefined(typeof(Required), true))
                    {
                    // check trường bắt buộc 
                        if (propertyValue == null )
                        {
                          isValid = false;
                          errMsg.UserMsg.Add($"{property.Name} trống, hãy kiểm tra lại; ");

                        }
                        else if (string.IsNullOrEmpty(propertyValue.ToString()))
                        {
                        isValid = false;

                        errMsg.UserMsg.Add($"{property.Name} trống, hãy kiểm tra lại; ");
                        }

                }

                    if (property.IsDefined(typeof(CheckDuplicate), true))
                    {


                        // check trường duy nhất trong cột 

                        if (propertyValue != null)
                        {

                            var duplicate = assetDL.Duplicate(property.Name, propertyValue.ToString(), "Asset");
                            if (duplicate)
                            {
                                isValid = false;
                                errMsg.DevMsg.Add("Trường dữ liệu có giá trị duy nhất bị lặp lại");
                                errMsg.UserMsg.Add($"{property.Name} không được trùng; ");
                            }

                        }

                    }
                
                }
            

            

            return isValid;
        }



        #endregion
    }
}
