using Common.Entities.DataTransferObjects.Api.Alert;
using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Interfaces
{
    public interface IFireHandlerService
    {
        Task<List<FireAlertInfoDto>> GetCurrentFireAlertByConstruction(List<string> constructionId);
        Task<List<FireAlertInfoDto>> GetAllFireAlertByConstruction(List<string> constructionId);
        Task<FireAlertInfoDto> GetFireById(string id);
        Task<List<FireAlertInfoDto>> GetFireByCity(string id);
        Task<List<FireAlertInfoDto>> GetAllFireByUser(string id);
    }
}
