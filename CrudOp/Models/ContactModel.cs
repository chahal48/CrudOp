using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public enum Category
    {
        [Display(Name ="Client")]
        Client,
        [Display(Name = "Vendor")]
        Vendor
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class ContactModel
    {
        //ProfessionModel professionModel = new ProfessionModel();

        [DisplayName("Contact ID")]
        [Required(ErrorMessage = "Id is mandatory")]
        public int ContactID { get; set; }

        [DisplayName("Profession")]
        [Required(ErrorMessage = "Sorry, Profession is not selected.")]
        public int ProfessionID { get; set; }

        public string? Profession { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is mandatory!!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name character length should be in between 3 to 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string fName { get; set; }

        [DisplayName("Last Name")]
        [StringLength(30, ErrorMessage = "Last name character length should be less than 30.")]
        [RegularExpression("^[A-Za-z -]*$", ErrorMessage = "Sorry, only letters (a-z) are allowed.")]
        public string? lName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is mandatory!!")]
        //[EmailAddress(ErrorMessage = "Sorry, email is invalid.")]
        [StringLength(100, ErrorMessage = "Email character length should be less than 100.")]
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Sorry, email is invalid.")]
        [Remote(action: "IsEmailAvailable", controller: "Home", AdditionalFields = "initialEmail",ErrorMessage = "Email is already in use.")]
        public string emailAddr { get; set; }

        [DisplayName("Company")]
        [Required(ErrorMessage = "Company is mandatory!!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "First name character length should be in between 3 to 100.")]
        [RegularExpression("^[a-zA-Z0-9'@&#.\\s]*$", ErrorMessage = "Sorry, only letters (a-z), numbers (0-9), and periods ('@&#.) are allowed.")]
        public string Company { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Sorry, Category is not selected.")]
        public Category Category { get; set; }

        [DisplayName("Gender :")]
        [Required(ErrorMessage = "Sorry, Gender is not selected.")]
        public Gender Gender { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
                return string.Concat(fName, " ", lName);
            }
        }

        [ValidDateCheck(ErrorMessage = "Date should be valid and not null !!")]
        [Required(ErrorMessage = "Date should be valid and not null !!")]
        [MinimumAge(5, ErrorMessage = "Minimum age requirement is 5 or more.")]
        [MaximumAge(60, ErrorMessage = "Maximum age requirement is 60 or less.")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Brith")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [DisplayName("Slack")]
        public bool ModeSlack { get; set; }
        [DisplayName("Whatsapp")]
        public bool ModeWhatsapp { get; set; }
        [DisplayName("Email")]
        public bool ModeEmail { get; set; }
        [DisplayName("Phone")]
        public bool ModePhone { get; set; }

        //public HttpPostedFileBase Image { get; set; }s
        public string? ContactImage { get; set; }

        public DateTime? LastModified { get; set; }

        public string? initialEmail
        {
            get
            {
                if (emailAddr != null)
                {
                    return emailAddr.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        [DisplayName("Mode of communication :")]
        public string Mode
        {
            get
            {
                string result = string.Empty;
                List<string> ModeList = new List<string>();
                if (ModeSlack) { ModeList.Add("Slack"); }
                if (ModeEmail) { ModeList.Add("Email"); }
                if (ModePhone) { ModeList.Add("Phone"); }
                if (ModeWhatsapp) { ModeList.Add("Whatsapp"); }
                if (ModeList.Any()) { result = ModeList.Aggregate((a, b) => a + ", " + b); }
                
                return result;
            }
        }
    }
}