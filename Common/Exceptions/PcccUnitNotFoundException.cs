using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class PcccUnitNotFoundException : NotFoundException
    {
        public PcccUnitNotFoundException(string id) : base($"The Unit PCCC with the id {id} was not found.")
        {

        }
        public PcccUnitNotFoundException() : base($"Không tìm thấy đơn vị phòng cháy chữa cháy")
        {

        }
        public PcccUnitNotFoundException(bool checkExits, string cityId) : base($"Không tìm thấy đơn vị phòng cháy chữa cháy trong thành phố có mã id {cityId} ")
        {

        }
    }
}
