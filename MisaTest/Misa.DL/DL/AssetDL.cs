using Dapper;
using MisaCommon.Domain;
using Misa.DL.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Misa.DL.DL
{
    public class AssetDL: DbConnector<Asset>, IAssetDL
    {
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="AssetCode">string</param>
        /// <returns>Int (Số lượng bản ghi tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public override int Delete(string AssetCode)
        {
            // Xóa khách hàng theo mã khách hàng (sử dụng QUERY STRING)
            var sqlQuery = $"DELETE FROM Asset WHERE CustomerCode = '{AssetCode}'";

            return _dbConnection.Execute(sqlQuery);
        }

        /// <summary>
        /// Kiểm tra trùng mã tài sản
        /// </summary>
        /// <param name="AssetCode">Mã khách hàng</param>
        /// <returns>Bool (true - mã tài sản bị trùng, false - mã tài sản không bị trùng)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public bool Duplicate(string propertyName, string propertyValue, string tableName)
        {
            // Kiểm tra trùng mã tài sản (sử dụng QUERY STRING)
            string sqlQuery = @"select  a.AssetId, a.AssetCode, a.AssetName, a.IncreaseDate, if( a.AssetTypeId is not null, a.AssetTypeId, """") as 
                              AssetTypeId , a.IncreaseDate, if( a.DepartmentId is not null, a.DepartmentId, """") as DepartmentId, 
                              a.TimeUse,a.WearRate, a.OriginalPrice, a.WearValue, a.IsUsed, a.CreatedDate, a.CreatedBy, a.ModifiedDate, a.ModifiedBy ";


            // Kết quả trả về (null - không bị trùng, !null - đã bị trùng)
            string sql2 = $"from {tableName} a where {propertyName} = '{propertyValue}';";

            string final = sqlQuery + sql2;
            var asset = _dbConnection.Query<Asset>(final,null,commandType: CommandType.Text).FirstOrDefault();

            if (asset != null)
                return true;
            return false;
        }

        /// <summary>
        /// Lấy dữ liệu theo tiêu chí khác nhau
        /// </summary>
        /// <param name="filter">Tham số để tìm theo AssetCode hoặc AssetName</param>
        /// <param name="year">Tìm theo năm</param>
        /// <param name="DepartId">Tìm theo phòng</param>
        /// <param name="TypeId">Tìm theo loại tài sản</param>
        /// <returns>Entities</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public  IEnumerable<Asset> GetDataFilter(string? filter, int? year, Guid? DepartId, Guid? TypeId)
        {
            // nếu filter rỗng thì chuyển thành một empty string
            var input = filter != null ? filter : string.Empty;


            var param = new DynamicParameters();
            param.Add("@AssetCode", input, DbType.String);
            param.Add("@AssetName", input, DbType.String);
            param.Add("@DepartmentId", DepartId, DbType.String);
            param.Add("@AssetTypeId", TypeId, DbType.String);
            param.Add("@IncreaseDate", year, DbType.Int32);


            // Lấy tên bảng
            var tableName = typeof(Asset).Name;
            // Tạo câu Query lấy tất cả bản ghi
            var sqlCommand = $"Proc_Filter{tableName}";
            // Lấy dữ liệu
            var entities = _dbConnection.Query<Asset>(sqlCommand, param, commandType: CommandType.StoredProcedure);

            return entities;

        }

        



    }
}
