using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SearchMapByKeyWords
    {

        public string Keys { get; set; } // Từ khóa tìm kiếm

        public int? Size { get; set; } // Số lượng kết quả trả về

        public double? Distance { get; set; } // Khoảng cách kilomet

        public Coords Location { get; set; } // cặp tọa độ vị trí tìm kiếm

        public string Searchstr { get; set; } // Từ khóa dùng để tìm kiếm lại
    }
}
