using System;
using System.ComponentModel.DataAnnotations;

namespace DocUp.Api.Validators
{
    public class NotAllowSpacesAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && !value.ToString().Contains(" ");
        }
    }
}
