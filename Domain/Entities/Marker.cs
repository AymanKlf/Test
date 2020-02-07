using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   
    public class Marker
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CoordinatePoint Position { get; set; }

        public string Address { get; set; }

        public int MapId { get; set; }

        public Map Map { get; set; }
    }
}
