using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IFireReportService
    {
        Task<bool> UpdateFireProtection(FireProtectionForUpdateDto fire);
        Task<List<FireProtectionDto>> GetAllFireProtectionByConstructions(List<string> ids);
        Task<List<FireProtectionDto>> GetCurrentFireAlertByConstruction(List<string> ids);
        Task<FireProtectionDto> GetFireAlertById(string ids);
        Task<FireProtectionInfo> CheckIdFireProtection(string id);
    }
}
