using System.Data;
using System.Data.SqlClient;

namespace CrudOp.Repository
{
    public interface ICommonQuery
    {
        public bool Query(SqlCommand cmd);
        public DataTable FetchQuery(SqlCommand cmd);
    }
}
