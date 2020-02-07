using Application.Common.Interfaces;
using System.Collections.Generic;

namespace Application.CQRS.Maps.TransferObjects.Shapes
{
    public class Polyline: IShape
    {
        public Polyline()
        {
            Points = new List<CoordinatePointDTO>();
        }

        public List<CoordinatePointDTO> Points { get; private set; }
    }
}
