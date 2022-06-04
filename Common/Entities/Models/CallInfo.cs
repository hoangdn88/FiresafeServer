using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Models
{
    public class CallInfo
    {
        public string Id { get; set; }
        public string ToNumber { get; set; }
        public string Text { get; set; }
        public object Result { get; set; }
        public string Status { get; set; }
        public int? Duration { get; set; }
        public int? AnswerDuration { get; set; }
        public DateTime? Time { get; set; }
    }
}
