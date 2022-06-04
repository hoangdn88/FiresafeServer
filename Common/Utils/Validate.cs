using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Enum;
using Common.Entities.Models;
using Common.MongoDbHelper.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Utilss
{
    public static class Validate
    {
        private static readonly byte[] _privateKey = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF }; // NOTE: You should use a private-key that's a LOT longer than just 4 bytes.
        private static readonly TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(5);
        private const byte _version = 1; // Increment this whenever the structure of the message changes.

        public static string CreatePasswordResetHmacCode(string userId)
        {
            byte[] message = Enumerable.Empty<byte>()
                .Append(_version)
                .Concat(Encoding.ASCII.GetBytes(userId))
                //.Concat(BitConverter.GetBytes(userId))
                .Concat(BitConverter.GetBytes(DateTime.Now.ToBinary())) // thười gian hiệu lực
                .ToArray();
            var c = Encoding.ASCII.GetBytes(userId);
            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
            {
                byte[] hash = hmacSha256.ComputeHash(buffer: message, offset: 0, count: message.Length);

                byte[] outputMessage = message.Concat(hash).ToArray();
                string outputCodeB64 = Convert.ToBase64String(outputMessage);
                string outputCode = outputCodeB64.Replace('+', '-').Replace('/', '_');
                return outputCode;
            }
        }
        public static bool VerifyPasswordResetHmacCode(string codeBase64Url)
        {
            string base64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            byte[] message = Convert.FromBase64String(base64);

            byte version = message[0];
            if (version < _version) return false;
            Int64 createdUtcBinary = BitConverter.ToInt64(message, startIndex: 1 + Guid.NewGuid().ToString().Length); // Reads bytes message[37,38,,,44]
   
            DateTime createdUtc = DateTime.FromBinary(createdUtcBinary);
            if (createdUtc.Add(_passwordResetExpiry) < DateTime.Now) return false;

            const Int32 _messageLength = 1 + 36 + sizeof(Int64); // 1 + 36 + 8 = 55
            using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
            {
                byte[] hash = hmacSha256.ComputeHash(message, offset: 0, count: _messageLength);
                byte[] messageHash = message.Skip(_messageLength).ToArray();
                return Enumerable.SequenceEqual(hash, messageHash);
            }
        }

        public static string GetIdFromToken(string codeBase64Url)
        {
            string base64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            byte[] message = Convert.FromBase64String(base64);
            byte[] newBytes = new byte[Guid.NewGuid().ToString().Length];
            Buffer.BlockCopy(message, 1, newBytes, 0, Guid.NewGuid().ToString().Length);
            return  Encoding.ASCII.GetString(newBytes);
        }

        // Có tối thiểu 8 kí tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt
        public static bool ValidatePasword(string password)
        {

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password) && hasSpecialChar(password)&&  hasLowerChar.IsMatch(password);

            return isValidated;

        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public static bool IsValidEmail(string email)
        {

            var hasEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var isValidated = hasEmail.IsMatch(email);
            return isValidated;
        }

        public static async Task<bool> IsValidFileUpLoadAsync(FileBusinessDto model)
        {

            string mineType =  MimeType.GetMimeType(await GetBytes(model.UploadedFile), "."+model.FileExtension);

            switch (mineType)
            {
                //case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet": // file XLSX
                //    return true;
                //case "application/vnd.openxmlformats-officedocument.wordprocessingml.document": // DOCX
                //    return true;
                //case "application/msword":// DOC
                //    return true;
                case "application/pdf": // PDF
                    return true;
                case "image/jpeg": //  jpg
                    return true;
                case "image/png": //  png
                    return true;
                default:
                    return false;
            }

        }

        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        public static List<UserPermission> AddPermistion (List<UserPermission> userPermissions )
        {
            if (userPermissions == null) return null;
            List<UserPermission> result = new List<UserPermission>();
            foreach (var permission in userPermissions) result.Add(permission);

            foreach (var permission in userPermissions)
            {
                if (permission == UserPermission.CATEGORY_EDIT && !userPermissions.Contains(UserPermission.CATEGORY_VIEW)){ result.Add(UserPermission.CATEGORY_VIEW);continue;}
                if (permission == UserPermission.CBCS_EDIT && !userPermissions.Contains(UserPermission.CBCS_VIEW)){ result.Add(UserPermission.CBCS_VIEW);continue;}
                if (permission == UserPermission.CERTIFICATE_EDIT && !userPermissions.Contains(UserPermission.CERTIFICATE_VIEW)){ result.Add(UserPermission.CERTIFICATE_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_APPROVAL_EDIT && !userPermissions.Contains(UserPermission.CONSTRUCTION_APPROVAL_VIEW)){ result.Add(UserPermission.CONSTRUCTION_APPROVAL_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_CHECKING_EDIT && !userPermissions.Contains(UserPermission.CONSTRUCTION_CHECKING_VIEW)){ result.Add(UserPermission.CONSTRUCTION_CHECKING_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_CHECKING_PLAN_EDIT && !userPermissions.Contains(UserPermission.CONSTRUCTION_CHECKING_PLAN_VIEW)){ result.Add(UserPermission.CONSTRUCTION_CHECKING_PLAN_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_EDIT && !userPermissions.Contains(UserPermission.CONSTRUCTION_VIEW)){ result.Add(UserPermission.CONSTRUCTION_VIEW);continue;}
                if (permission == UserPermission.CUSTOMER_EDIT && !userPermissions.Contains(UserPermission.CUSTOMER_VIEW)){ result.Add(UserPermission.CUSTOMER_VIEW);continue;}
                if (permission == UserPermission.DEVICE_EDIT && !userPermissions.Contains(UserPermission.DEVICE_VIEW)){ result.Add(UserPermission.DEVICE_VIEW);continue;}
                if (permission == UserPermission.DUTY_REGIST_EDIT && !userPermissions.Contains(UserPermission.DUTY_REGIST_VIEW)){ result.Add(UserPermission.DUTY_REGIST_VIEW);continue;}
                if (permission == UserPermission.FACT_EDIT && !userPermissions.Contains(UserPermission.FACT_VIEW)){ result.Add(UserPermission.FACT_VIEW);continue;}
                if (permission == UserPermission.DUTY_SCHEDULE_EDIT && !userPermissions.Contains(UserPermission.DUTY_SCHEDULE_VIEW)){ result.Add(UserPermission.DUTY_SCHEDULE_VIEW);continue;}
                if (permission == UserPermission.FIRE_FIGHTER_EDIT && !userPermissions.Contains(UserPermission.FIRE_FIGHTER_VIEW)){ result.Add(UserPermission.FIRE_FIGHTER_VIEW);continue;}
                if (permission == UserPermission.FIRE_PROTECTION_EDIT && !userPermissions.Contains(UserPermission.FIRE_PROTECTION_VIEW)){ result.Add(UserPermission.FIRE_PROTECTION_VIEW);continue;}
                if (permission == UserPermission.FIRE_TRUCK_EDIT && !userPermissions.Contains(UserPermission.FIRE_TRUCK_VIEW)){ result.Add(UserPermission.FIRE_TRUCK_VIEW);continue;}
                if (permission == UserPermission.NOTICE_EDIT && !userPermissions.Contains(UserPermission.NOTICE_VIEW)){ result.Add(UserPermission.NOTICE_VIEW);continue;}
                if (permission == UserPermission.PCCC_UNIT_EDIT && !userPermissions.Contains(UserPermission.PCCC_UNIT_VIEW)){ result.Add(UserPermission.PCCC_UNIT_VIEW);continue;}
                if (permission == UserPermission.PERSONAL_ACCOUNT_EDIT && !userPermissions.Contains(UserPermission.PERSONAL_ACCOUNT_VIEW)){ result.Add(UserPermission.PERSONAL_ACCOUNT_VIEW);continue;}
                if (permission == UserPermission.PLANING_EDIT && !userPermissions.Contains(UserPermission.PLANING_EDIT)) { result.Add(UserPermission.PLANING_EDIT); continue; }
                if (permission == UserPermission.PROPAGAE_EDIT && !userPermissions.Contains(UserPermission.PROPAGAE_VIEW)){ result.Add(UserPermission.PROPAGAE_VIEW);continue;}
                if (permission == UserPermission.RESCUE_WORK_EDIT && !userPermissions.Contains(UserPermission.RESCUE_WORK_VIEW)){ result.Add(UserPermission.RESCUE_WORK_VIEW);continue;}
                if (permission == UserPermission.SUPPORT_UNIT_EDIT && !userPermissions.Contains(UserPermission.SUPPORT_UNIT_VIEW)){ result.Add(UserPermission.SUPPORT_UNIT_VIEW);continue;}
                if (permission == UserPermission.USER_ACCOUNT_EDIT && !userPermissions.Contains(UserPermission.USER_ACCOUNT_VIEW)){ result.Add(UserPermission.USER_ACCOUNT_VIEW);continue;}
                if (permission == UserPermission.USER_HISTORY_EDIT && !userPermissions.Contains(UserPermission.USER_HISTORY_VIEW)){ result.Add(UserPermission.USER_HISTORY_VIEW);continue;}
                if (permission == UserPermission.VIOLATION_EDIT && !userPermissions.Contains(UserPermission.VIOLATION_VIEW)){ result.Add(UserPermission.VIOLATION_VIEW);continue;}
                if (permission == UserPermission.WATER_POINT_EDIT && !userPermissions.Contains(UserPermission.WATER_POINT_VIEW)){ result.Add(UserPermission.WATER_POINT_VIEW);continue;}

                if (permission == UserPermission.CATEGORY_DELETE && !userPermissions.Contains(UserPermission.CATEGORY_VIEW)){ result.Add(UserPermission.CATEGORY_VIEW);continue;}
                if (permission == UserPermission.CBCS_DELETE && !userPermissions.Contains(UserPermission.CBCS_VIEW)){ result.Add(UserPermission.CBCS_VIEW);continue;}
                if (permission == UserPermission.CERTIFICATE_DELETE && !userPermissions.Contains(UserPermission.CERTIFICATE_VIEW)){ result.Add(UserPermission.CERTIFICATE_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_APPROVAL_DELETE && !userPermissions.Contains(UserPermission.CONSTRUCTION_APPROVAL_VIEW)){ result.Add(UserPermission.CONSTRUCTION_APPROVAL_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_CHECKING_DELETE && !userPermissions.Contains(UserPermission.CONSTRUCTION_CHECKING_VIEW)){ result.Add(UserPermission.CONSTRUCTION_CHECKING_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_CHECKING_PLAN_DELETE && !userPermissions.Contains(UserPermission.CONSTRUCTION_CHECKING_PLAN_VIEW)){ result.Add(UserPermission.CONSTRUCTION_CHECKING_PLAN_VIEW);continue;}
                if (permission == UserPermission.CONSTRUCTION_DELETE && !userPermissions.Contains(UserPermission.CONSTRUCTION_VIEW)){ result.Add(UserPermission.CONSTRUCTION_VIEW);continue;}
                if (permission == UserPermission.CUSTOMER_DELETE && !userPermissions.Contains(UserPermission.CUSTOMER_VIEW)){ result.Add(UserPermission.CUSTOMER_VIEW);continue;}
                if (permission == UserPermission.DEVICE_DELETE && !userPermissions.Contains(UserPermission.DEVICE_VIEW)){ result.Add(UserPermission.DEVICE_VIEW);continue;}
                if (permission == UserPermission.DUTY_REGIST_DELETE && !userPermissions.Contains(UserPermission.DUTY_REGIST_VIEW)){ result.Add(UserPermission.DUTY_REGIST_VIEW);continue;}
                if (permission == UserPermission.FACT_DELETE && !userPermissions.Contains(UserPermission.FACT_VIEW)){ result.Add(UserPermission.FACT_VIEW);continue;}
                if (permission == UserPermission.DUTY_SCHEDULE_DELETE && !userPermissions.Contains(UserPermission.DUTY_SCHEDULE_VIEW)){ result.Add(UserPermission.DUTY_SCHEDULE_VIEW);continue;}
                if (permission == UserPermission.FIRE_FIGHTER_DELETE && !userPermissions.Contains(UserPermission.FIRE_FIGHTER_VIEW)){ result.Add(UserPermission.FIRE_FIGHTER_VIEW);continue;}
                if (permission == UserPermission.FIRE_PROTECTION_DELETE && !userPermissions.Contains(UserPermission.FIRE_PROTECTION_VIEW)){ result.Add(UserPermission.FIRE_PROTECTION_VIEW);continue;}
                if (permission == UserPermission.FIRE_TRUCK_DELETE && !userPermissions.Contains(UserPermission.FIRE_TRUCK_VIEW)){ result.Add(UserPermission.FIRE_TRUCK_VIEW);continue;}
                if (permission == UserPermission.NOTICE_DELETE && !userPermissions.Contains(UserPermission.NOTICE_VIEW)){ result.Add(UserPermission.NOTICE_VIEW);continue;}
                if (permission == UserPermission.PCCC_UNIT_DELETE && !userPermissions.Contains(UserPermission.PCCC_UNIT_VIEW)){ result.Add(UserPermission.PCCC_UNIT_VIEW);continue;}
                if (permission == UserPermission.PERSONAL_ACCOUNT_DELETE && !userPermissions.Contains(UserPermission.PERSONAL_ACCOUNT_VIEW)){ result.Add(UserPermission.PERSONAL_ACCOUNT_VIEW);continue;}
                if (permission == UserPermission.PLANING_DELETE && !userPermissions.Contains(UserPermission.PLANING_VIEW)){ result.Add(UserPermission.PLANING_VIEW); continue; }
                if (permission == UserPermission.PROPAGAE_DELETE && !userPermissions.Contains(UserPermission.PROPAGAE_VIEW)){ result.Add(UserPermission.PROPAGAE_VIEW);continue;}
                if (permission == UserPermission.RESCUE_WORK_DELETE && !userPermissions.Contains(UserPermission.RESCUE_WORK_VIEW)){ result.Add(UserPermission.RESCUE_WORK_VIEW);continue;}
                if (permission == UserPermission.SUPPORT_UNIT_DELETE && !userPermissions.Contains(UserPermission.SUPPORT_UNIT_VIEW)){ result.Add(UserPermission.SUPPORT_UNIT_VIEW);continue;}
                if (permission == UserPermission.USER_ACCOUNT_DELETE && !userPermissions.Contains(UserPermission.USER_ACCOUNT_VIEW)){ result.Add(UserPermission.USER_ACCOUNT_VIEW);continue;}
                if (permission == UserPermission.USER_HISTORY_DELETE && !userPermissions.Contains(UserPermission.USER_HISTORY_VIEW)){ result.Add(UserPermission.USER_HISTORY_VIEW);continue;}
                if (permission == UserPermission.VIOLATION_DELETE && !userPermissions.Contains(UserPermission.VIOLATION_VIEW)){ result.Add(UserPermission.VIOLATION_VIEW);continue;}
                if (permission == UserPermission.WATER_POINT_DELETE && !userPermissions.Contains(UserPermission.WATER_POINT_VIEW)){ result.Add(UserPermission.WATER_POINT_VIEW);continue;}
                
            }
            return result;
        }
  

    }

   

}
