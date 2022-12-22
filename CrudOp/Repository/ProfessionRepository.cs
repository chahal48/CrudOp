using System.Data.SqlClient;
using System.Data;
using CrudOp.Models;

namespace CrudOp.Repository
{
    public class ProfessionRepository : CommonQuery
    {
        private readonly string DefaultConnection = string.Empty;
        public ProfessionRepository(IConfiguration configuration) : base(configuration)
        {
            DefaultConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public bool AddProfession(ProfessionModel obj)
        {
            SqlCommand com = new SqlCommand("AddNewProfession");
            com.Parameters.AddWithValue("@Profession", obj.Profession);
            com.Parameters.AddWithValue("@Description", obj.Description);

            return Query(com);
        }

        public List<ProfessionModel> GetAllProfessions()
        {
            List<ProfessionModel> ProfessionsList = new List<ProfessionModel>();

            SqlCommand com = new SqlCommand("GetAllProfessions");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            dt = FetchQuery(com);

            foreach (DataRow dr in dt.Rows)
            {
                ProfessionsList.Add(

                    new ProfessionModel
                    {
                        ProfessionID = Convert.ToInt32(dr["ProfessionID"]),
                        Profession = Convert.ToString(dr["Profession"]),
                        Description = Convert.ToString(dr["Description"])
                    }
                    );
            }

            return ProfessionsList;
        }

        public bool UpdateProfession(ProfessionModel obj)
        {
            SqlCommand com = new SqlCommand("UpdateProfession");
            com.Parameters.AddWithValue("@ProfessionID", obj.ProfessionID);
            com.Parameters.AddWithValue("@Profession", obj.Profession);
            com.Parameters.AddWithValue("@Description", obj.Description);

            return Query(com);
        }
        public bool DeleteProfession(int Id)
        {
            SqlCommand com = new SqlCommand("DeleteProf_Contact");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ProfessionID", Id);

            return Query(com);
        }
    }
}