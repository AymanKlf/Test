using Application.Common.Interfaces;

namespace Application.CQRS.Maps.TransferObjects.Shapes
{
    public class Circle : IShape
    {
        public Circle()
        {
            Center = new CoordinatePointDTO();
        }

        public double? Radius { get; set; }

        public CoordinatePointDTO Center { get; set; }
    }
}
