using Application.Common.Mappings;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Maps.TransferObjects
{
    public class CoordinatePointDTO : IMapFrom<CoordinatePoint>
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
