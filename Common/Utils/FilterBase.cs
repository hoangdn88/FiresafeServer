using Common.Entities.DataTransferObjects.Api;
using Common.Entities.Models;
using Common.MongoDbHelper.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Extenstions
{
    public static class FilterBase<T>  where T : LocationBase
    {
        //public static List<T> FilterWithLocation(List<T> objectDto, List<LocationInfo> locations, List<UserPermission> userPermissions)
        //{
        //    if (userPermissions.Contains(UserPermission.ADMIN))
        //    {
        //        return objectDto;
        //    }
        //    string fieldName = "Location";
        //    bool checkProperty = false;
        //    var filter = Builders<T>.Filter.Empty;
        //    foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        //    {
        //        if (property.Name == fieldName)
        //        {
        //            checkProperty = true;
        //            break;
        //        }
        //    }
        //    if (!checkProperty)
        //    {
        //        return objectDto;
        //    }

        //    List<T> lstObjectDtos = new List<T>();
        //    //var props = objectDto.GetType().GetProperties();
        //    foreach (var location in locations)
        //    {
        //        var temp = new List<T>();
        //        if (location.CityId != null) temp = objectDto
        //            .Where(x =>
        //            {
        //                var a = x.GetType().GetProperty("Location").GetValue(x);
        //                var props = a.GetType().GetProperties();
        //                foreach (var prop in props)
        //                {
        //                    if (prop.Name == "CityId")
        //                    {
        //                        return a.GetType().GetProperty("CityId").GetValue(a).Equals(location.CityId);
        //                    }
        //                }
        //                return false;
        //            }
        //            ).ToList();
        //        if (location.DistrictId != null) temp = objectDto
        //            .Where(x =>
        //            {
        //                var a = x.GetType().GetProperty("Location").GetValue(x);
        //                var props = a.GetType().GetProperties();
        //                foreach (var prop in props)
        //                {
        //                    if (prop.Name == "DistrictId")
        //                    {
        //                        return a.GetType().GetProperty("DistrictId").GetValue(a).Equals(location.DistrictId);
        //                    }
        //                }
        //                return false;
        //            }
        //            ).ToList();
        //        if (location.WardId != null) temp = objectDto
        //           .Where(x =>
        //           {
        //               var a = x.GetType().GetProperty("Location").GetValue(x);
        //               var props = a.GetType().GetProperties();
        //               foreach (var prop in props)
        //               {
        //                   if (prop.Name == "WardId")
        //                   {
        //                       return a.GetType().GetProperty("WardId").GetValue(a).Equals(location.WardId);
        //                   }
        //               }
        //               return false;

        //           }
        //           ).ToList();
        //        //======================
        //        lstObjectDtos = lstObjectDtos.Union(temp).ToList();
        //    }
        //    return lstObjectDtos;
        //}
        public static List<T> FilterWithLocation(List<T> objectDto, List<LocationInfo> locations, List<UserPermission> userPermissions)
        {
            if ((userPermissions?.Count > 0 && userPermissions.Contains(UserPermission.ADMIN)) || objectDto == null)
            {
                return objectDto;
            }
            string fieldName = "Location";
            bool checkProperty = false;
            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.Name == fieldName)
                {
                    checkProperty = true;
                    break;
                }
            }
            if (!checkProperty)
            {
                return objectDto;
            }

            List<T> lstObjectDtos = new List<T>();
            if(locations == null) return objectDto;
            foreach (var location in locations)
            {
                var temp = new List<T>();
                if (location.CityId != null) temp = objectDto.Where(x => x.Location?.CityId == location.CityId)?.ToList();
                if (location.DistrictId != null) temp = temp.Where(x => x.Location?.DistrictId == location.DistrictId)?.ToList();
                if (location.WardId != null) temp = temp.Where(x => x.Location?.WardId == location.WardId)?.ToList();
                //======================
                lstObjectDtos = lstObjectDtos.Union(temp).ToList();
            }
            return lstObjectDtos;
        }

    }

   

}
