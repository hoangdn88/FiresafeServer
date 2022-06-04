using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class FireProtectionForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { set; get; } // Số điện thoại
        
        [Required]
        public LocationInfoDto Location { set; get; }

        [Required]
        public string LocationDetail { set; get; }
        public string ConstructionId { set; get; }
        public string ReporterName { set; get; }
        public List<AlertType> AlertType { set; get; } // nguồn báo cháy
        public double Longitude { set; get; }
        public double Latitude { set; get; }
        public string CurrentConstructions { set; get; }
        public string CurrentCustomerId { set; get; }
        public DateTime? FireAlarmTime { set; get; }
        public string Note { set; get; }
    }
}
