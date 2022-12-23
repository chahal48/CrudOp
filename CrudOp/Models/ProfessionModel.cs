using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public class ProfessionModel
    {
        [DisplayName("Profession ID")]
        [Required(ErrorMessage = "Id is mandatory!!")]
        public int ProfessionID { get; set; }

        [DisplayName("Profession Name")]
        [Required(ErrorMessage = "Profession name is mandatory!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Profession name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        [Remote("IsProfessionAvailable", "Profession", ErrorMessage = "Profession is already in use.", AdditionalFields = "initialProfession")]
        public string Profession { get; set; }

        [DisplayName("Description")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Description character length should be in between 3 to 200.")]
        [RegularExpression("^[a-zA-Z0-9',/@&#.\\s]*$", ErrorMessage = "Sorry, only letters (a-z), numbers (0-9), and periods ('@&#.) are allowed.")]
        public string? Description { get; set; }
        public DateTime? LastModified { get; set; }

        public string initialProfession
        {
            get
            {
                if(Profession != null)
                {
                    return Profession.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}