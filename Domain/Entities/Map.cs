using Domain.Enumerations;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Map
    {
        public Map()
        {
            Markers = new HashSet<Marker>();
            Shapes = new HashSet<Shape>();
        }

        public int Id { get; set; }

        public int Zoom { get; set; }

        public MapType MapType { get; set; }

        public CoordinatePoint Center { get; set; }

        public ICollection<Marker> Markers { get; private set; }

        public ICollection<Shape> Shapes { get; private set; }

    }
}