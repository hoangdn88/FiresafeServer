using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Entities.DataTransferObjects.Api
{
    public class MapResultDto
    {

        public bool? State { set; get; }

        public byte? Errorcode { set; get; }

        public List<DataMapResultDto> Data { set; get; }
    }

    public class MapResultFindRouteDto
    {

        public bool? State { set; get; }

        public byte? Errorcode { set; get; }

        public DataMapRouteDto Data { set; get; }
    }

    public class Coords
    {

        public double? Lng { set; get; }

        public double? Lat { set; get; }
    }

    public class DataMapResultDto
    {

        public byte Shapeid { set; get; }

        public string Kindname { set; get; }

        public string Name { set; get; }

        public string Address { set; get; }

        public List<Coords> Coords { set; get; }
        public LocationInfo Location { set; get; }
    }

    public class DataMapRouteDto
    {

        public int Distance { set; get; }

        public Coords From { set; get; }

        public Coords To { set; get; }

        public List<Coords> Points { set; get; }

        public List<DataSegments> Segments { set; get; }
    }

    public class DataSegments
    {

        public string Name { set; get; }

        public Coords Start { set; get; }

        public int Distance { set; get; }
    }
}
