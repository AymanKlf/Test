using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Shape
    {
        public int Id { get; set; }

        public int MapId { get; set; }

        public Map Map { get; set; }

        public ShapeType Type { get; set; }

        public string Xml { get; set; }
    }
}

