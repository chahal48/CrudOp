using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CrudOp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;

namespace CrudOp.Repository
{
    public class ContactsRepository : CommonQuery
    {
        private readonly string DefaultConnection = string.Empty;

        public ContactsRepository(IConfiguration configuration) : base(configuration)
        {
            DefaultConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public List<ContactModel> GetAllContacts()
        {
            List<ContactModel> ContactsList = new List<ContactModel>();

            SqlCommand com = new SqlCommand("GetAllContact");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            dt = FetchQuery(com);

            foreach (DataRow dr in dt.Rows)
            {
                ContactsList.Add(

                    new ContactModel
                    {
                        ContactID = Convert.ToInt32(dr["ContactID"]),
                        fName = Convert.ToString(dr["fName"]),
                        lName = Convert.ToString(dr["lName"]),
                        emailAddr = Convert.ToString(dr["emailAddr"]),
                        Company = Convert.ToString(dr["Company"]),
                        Category = (Category)Convert.ToInt32(dr["Category"]),
                        Profession = Convert.ToString(dr["Profession"]),
                        ProfessionID = Convert.ToInt32(dr["ProfID"]),
                        Gender = (Gender)Convert.ToInt32((dr["Gender"])),
                        DOB = (DateTime)dr["DOB"],
                        ModeSlack = Convert.ToBoolean(dr["ModeSlack"]),
                        ModeWhatsapp = Convert.ToBoolean(dr["ModeWhatsapp"]),
                        ModePhone = Convert.ToBoolean(dr["ModePhone"]),
                        ModeEmail = Convert.ToBoolean(dr["ModeEmail"]),
                        ContactImage = Convert.ToString(dr["ContactImage"]),
                        LastModified = Convert.ToDateTime(dr["LastModified"])
                    }
                    );
            }
            return ContactsList;
        }

        public bool AddContact(ContactModel obj)
        {
            SqlCommand com = new SqlCommand("AddContact");
            com.Parameters.AddWithValue("@ProfessionID", obj.ProfessionID);
            com.Parameters.AddWithValue("@fName", obj.fName);
            com.Parameters.AddWithValue("@lName", obj.lName);
            com.Parameters.AddWithValue("@emailAddr", obj.emailAddr);
            com.Parameters.AddWithValue("@Company", obj.Company);
            com.Parameters.AddWithValue("@Category", obj.Category);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@DOB", obj.DOB);
            com.Parameters.AddWithValue("@ModeSlack", obj.ModeSlack);
            com.Parameters.AddWithValue("@ModeEmail", obj.ModeEmail);
            com.Parameters.AddWithValue("@ModePhone", obj.ModePhone);
            com.Parameters.AddWithValue("@ModeWhatsapp", obj.ModeWhatsapp);
            com.Parameters.AddWithValue("@ContactImage", obj.ContactImage);

            return Query(com);
        }

        public bool UpdateContact(ContactModel obj)
        {
            SqlCommand com = new SqlCommand("UpdateContact");
            com.Parameters.AddWithValue("@ContactID", obj.ContactID);
            com.Parameters.AddWithValue("@ProfessionID", obj.ProfessionID);
            com.Parameters.AddWithValue("@fName", obj.fName);
            com.Parameters.AddWithValue("@lName", obj.lName);
            com.Parameters.AddWithValue("@emailAddr", obj.emailAddr);
            com.Parameters.AddWithValue("@Company", obj.Company);
            com.Parameters.AddWithValue("@Category", obj.Category);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@DOB", obj.DOB);
            com.Parameters.AddWithValue("@ModeSlack", obj.ModeSlack);
            com.Parameters.AddWithValue("@ModeEmail", obj.ModeEmail);
            com.Parameters.AddWithValue("@ModePhone", obj.ModePhone);
            com.Parameters.AddWithValue("@ModeWhatsapp", obj.ModeWhatsapp);
            com.Parameters.AddWithValue("@ContactImage", obj.ContactImage);

            return Query(com);
        }

        public bool DeleteContact(int Id)
        {
            SqlCommand com = new SqlCommand("DeleteContact");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ContactID", Id);

            return Query(com);
        }
    }
}