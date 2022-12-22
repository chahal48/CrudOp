using System.ComponentModel.DataAnnotations;

namespace CrudOp.Models
{
    public class MaximumAgeAttribute : ValidationAttribute
    {
        int _MaximumAge;

        public MaximumAgeAttribute(int maximumAge)
        {
            _MaximumAge = maximumAge * -1;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(Convert.ToString(value), out date))
            {
                return date > DateTime.Now.AddYears(_MaximumAge);
            }
            return false;
        }
    }
}