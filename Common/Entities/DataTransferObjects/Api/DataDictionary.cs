using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.DataTransferObjects.Api
{
    public class DataDictionary
    {
        public string Key { set; get; } // Nội dung hành vi 
        public double Value { set; get; } // Đường dẫn đến file đính kèm
        public string Name { set; get; } // title
    }
}
