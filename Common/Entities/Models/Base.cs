using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class Base
    {
        public string Id { set; get; } // Id
        public bool DeleteFlag { set; get; }

        public Base()
        {
            Id = Guid.NewGuid().ToString();
            DeleteFlag = false;
        }
    }
}
