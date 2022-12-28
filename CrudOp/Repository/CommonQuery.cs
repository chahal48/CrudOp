using System.Data.SqlClient;
using System.Data;

namespace CrudOp.Repository
{
    public class CommonQuery : ICommonQuery
    {
        private readonly string DefaultConnection = string.Empty;

        public CommonQuery(IConfiguration configuration)
        {
            DefaultConnection = configuration.GetConnectionString("DefaultConnection");
        }

        #region CommonQuery
        public bool Query(SqlCommand cmd)
        {
            using(var conn = new SqlConnection(DefaultConnection))
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                int affectedRows = cmd.ExecuteNonQuery();
                if(affectedRows > 0)
                    return true;
                else return false;
            }
        }
        #endregion

        #region CommonFetchQuery
        public DataTable FetchQuery(SqlCommand cmd)
        {
            using (var conn = new SqlConnection(DefaultConnection))
            {
                conn.Open();
                cmd.Connection= conn;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
        #endregion
    }
}