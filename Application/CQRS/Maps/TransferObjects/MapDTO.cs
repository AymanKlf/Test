using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Application.CQRS.Maps.TransferObjects
{
    public class MapDTO : IMapFrom<Map>
    {
        public MapDTO()
        {
            Center = new CoordinatePointDTO();
            Markers = new List<MarkerDTO>();
            Shapes = new List<ShapeDTO>();
        }

        public int Id { get; set; }

        public int Zoom { get; set; }

        public CoordinatePointDTO Center { get; set; }

        public string Type { get; set; }

        public List<MarkerDTO> Markers { get; set; }

        public List<ShapeDTO> Shapes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Map, MapDTO>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.MapType.ToString()))
                ;
        }
    }
}
