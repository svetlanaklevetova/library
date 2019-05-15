using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Domain.Infrastructure
{
    public class DateValidatorAttributeNull: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is DateTime || value == null;
        }
    }
}
