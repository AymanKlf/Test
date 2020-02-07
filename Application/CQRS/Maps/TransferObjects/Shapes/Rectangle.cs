using Application.Common.Interfaces;

namespace Application.CQRS.Maps.TransferObjects.Shapes
{
    public class Rectangle : IShape
    {
        public Rectangle()
        {
            Bounds = new Bounds();
        }
        public Bounds Bounds { get; set; }
    }

    public class Bounds
    {
        public double? North { get; set; }
        public double? South { get; set; }
        public double? East { get; set; }
        public double? West { get; set; }
    }
}
