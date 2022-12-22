using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge * -1;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(Convert.ToString(value), out date))
            {
                return date < DateTime.Now.AddYears(_minimumAge);
            }
            return false;
        }
    }
}