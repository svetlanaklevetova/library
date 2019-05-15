using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Domain.Infrastructure
{
    public class DateValidatorAttributeNotNull : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is DateTime && value != null;
        }
    }
}