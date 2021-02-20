
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Misa.DL.Interface;
using System.Linq;

namespace Misa.DL.DL
{
    /// <summary>
    /// Cơ sở dữ liệu: TEST.MISA.QLTS   
    /// </summary>
    /// <typeparam name="TEntity">Object</typeparam>
    public class DbConnector<TEntity> : IDbConnector<TEntity>
    {
        #region DECLARE
        // Khởi tạo chuỗi kết nối

        protected string _connectionString = "User=dev;Host=47.241.69.179;" +
            "Database=TEST.MISA.QLTS;port=3306;password=12345678;";
        // Khởi tạo kết nối
        protected IDbConnection _dbConnection;
        #endregion

        #region CONSTRUCTOR
        // Hàm khởi tạo
        public DbConnector()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region METHODS
        
        public IEnumerable<TEntity> GetData(string sqlCommand = null, object parameters = null, CommandType commandType = CommandType.Text)
        {
            // Nếu sqlCommand là rỗng thì lấy mặc định theo tên bảng
            if (sqlCommand == null)
            {
                // Lấy tên bảng
                var tableName = typeof(TEntity).Name;
                // Tạo câu Query lấy tất cả bản ghi
                sqlCommand = $"SELECT * FROM {tableName}";
                // Lấy dữ liệu
                var entities = _dbConnection.Query<TEntity>(sqlCommand);
                

                return entities;
            }
            else
            {
                // Lấy dữ liệu theo tiêu chí
                var entities = _dbConnection.Query<TEntity>(sqlCommand, param: parameters, commandType: commandType);

                return entities;
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public int Insert(TEntity entity)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Insert{tableName}";
            // Lưu bản ghi vào cơ sở dữ liệu và trả về số bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }

        /// <summary>
        /// Cập nhập thông tin bản ghi
        /// </summary>
        /// <param name="entity">Object</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public int Update(TEntity entity)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Update{tableName}";
            // Cập nhật bản ghi vào cơ sở dữ liệu và trả về số bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, entity, commandType: CommandType.StoredProcedure);
            

            return affectedRows;
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Int (Số hàng tác động vào cơ sở dữ liệu)</returns>
        /// CreatedBy: PNHai (18/02/2021)
        public virtual int Delete(string id)
        {
            // Lấy tên bảng
            var tableName = typeof(TEntity).Name;
            // Lấy tên Procedure
            var storeName = $"Proc_Delete{tableName}";
            // Lấy Parameter
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{tableName}Id", id);
            // Xóa bản ghi và trả lại số lượng bản ghi tác động vào cơ sở dữ liệu
            var affectedRows = _dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);

            return affectedRows;
        }
        #endregion
    }
}
