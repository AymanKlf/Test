using Application.Common.Interfaces;
using System.Collections.Generic;

namespace Application.CQRS.Maps.TransferObjects.Shapes
{
    public class Polygon : IShape
    {
        public Polygon()
        {
            Points = new List<CoordinatePointDTO>();
        }

        public List<CoordinatePointDTO> Points { get; set; }
    }
}
