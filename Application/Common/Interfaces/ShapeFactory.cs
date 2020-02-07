using Application.Common.Parsers;
using Application.CQRS.Maps.TransferObjects.Shapes;
using Domain.Enumerations;
using Newtonsoft.Json;
using System;

namespace Application.Common.Interfaces
{
    public class ShapeFactory
    {
        private ShapeType type;
        public ShapeFactory(ShapeType type)
        {
            this.type = type;
        }

        public IShape GetShape(string xmlData = null)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    {
                        if (string.IsNullOrEmpty(xmlData))
                        {
                            return new Circle();
                        }

                        return XmlParser.Deserialize<Circle>(xmlData);
                    }

                case ShapeType.Polygon:
                    {
                        if (string.IsNullOrEmpty(xmlData))
                        {
                            return new Polygon();
                        }

                        return XmlParser.Deserialize<Polygon>(xmlData);
                    }

                case ShapeType.Polyline:
                    {
                        if (string.IsNullOrEmpty(xmlData))
                        {
                            return new Polyline();
                        }

                        return XmlParser.Deserialize<Polyline>(xmlData);
                    }

                case ShapeType.Rectangle:
                    {
                        if (string.IsNullOrEmpty(xmlData))
                        {
                            return new Rectangle();
                        }

                        return XmlParser.Deserialize<Rectangle>(xmlData);
                    }
            }

            return null;
        }
    }
}
