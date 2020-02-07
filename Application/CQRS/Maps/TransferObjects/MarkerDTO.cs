using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Maps.TransferObjects
{
    public class MarkerDTO : IMapFrom<Marker>
    {
        public MarkerDTO()
        {
            Position = new CoordinatePointDTO();
        }

        public int Id { get; set; }
        
        public int MapId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public CoordinatePointDTO Position { get; set; }
    }
}
