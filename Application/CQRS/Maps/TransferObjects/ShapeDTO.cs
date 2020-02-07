using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Parsers;
using AutoMapper;
using Domain.Entities;
using Domain.Enumerations;

namespace Application.CQRS.Maps.TransferObjects
{
    public class ShapeDTO : IMapFrom<Shape>
    {
        public int Id { get; set; }

        public int MapId { get; set; }

        private string type;
        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (this.type != value)
                {
                    this.type = value;

                    ShapeFactory shapeFactory = new ShapeFactory(EnumParser.ToEnum<ShapeType>(value));                    
                    this.Data = shapeFactory.GetShape();
                }
            }
        }

        public IShape Data { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Shape, ShapeDTO>()
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type.ToString()))
                .ForMember(d => d.Data, opt => opt.MapFrom(s => ShapeDTO.ToShape(s.Xml, s.Type)))
                ;
        }

        private static IShape ToShape(string xmlData, ShapeType type)
        {
            ShapeFactory shapeFactory = new ShapeFactory(type);
            IShape shape = shapeFactory.GetShape(xmlData);
            return shape;
        }
    }
}
