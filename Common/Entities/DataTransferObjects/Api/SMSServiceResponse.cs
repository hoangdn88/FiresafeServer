using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class SMSRequest
    {
        public string ApiKey { set; get; }
        public string ToNumber { set; get; }
        public string Content { set; get; }
        public string Checksum => GetCheckSum();

        public string GetCheckSum()
        {
            var md5String = string.Format("{0}{1}{2}", ApiKey, ToNumber, Content);
            return Utils.Convert.GetMD5Hash(md5String);
        }
    }

    public class SMSServiceResponse
    {
        public ErrorCode ErrorCode;
        public string Message;
    }
    public enum ErrorCode
    {
        OK = 0, // OK
        API_KEY_INVALID, // API Key invalid
        DATA_INVALID, // Data invalid
        CHECKSUM_INVALID,
        CALL_REJECT,
        PHONE_NUMBER_INVALID,

        INTERNAL_ERROR = 255
    }
}
