using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(string code) : base($"The Category with the code {code} was not found.")
        {
        }
        public CategoryNotFoundException() : base($"The Category was not found.")
        {

        }
    }
}
