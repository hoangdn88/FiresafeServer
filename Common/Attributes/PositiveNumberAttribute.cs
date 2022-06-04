using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attributes
{
    public class PositiveNumberAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int dateTime = Convert.ToInt32(value);
            return dateTime >= 0;
        }
    }
}
