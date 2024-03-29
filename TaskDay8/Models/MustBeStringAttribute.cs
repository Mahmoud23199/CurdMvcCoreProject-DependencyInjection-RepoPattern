
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TaskDay8.Models
{
    internal class MustBeStringAttribute : ValidationAttribute
    {
        public MustBeStringAttribute() { }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            else if (value is string)
            {
                return !ContainsNumbers((string)value);
            }

            return false;
        }

        private bool ContainsNumbers(string value)
        {
            Regex regex = new Regex(@"\d");

            return regex.IsMatch(value);
        }
    }
}