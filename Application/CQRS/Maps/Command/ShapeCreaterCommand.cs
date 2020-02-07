using Application.Common.Interfaces;
using Application.Common.Parsers;
using Application.CQRS.Maps.TransferObjects;
using Domain.Entities;
using Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Maps.Command
{
    public class ShapeCreaterCommand : IRequest<int>
    {
        public ShapeDTO EntityDTO { get; private set; }

        public ShapeCreaterCommand(ShapeDTO dto)
        {
            EntityDTO = dto;
        }

        public class ShapeCreaterCommandHandler : IRequestHandler<ShapeCreaterCommand, int>
        {
            private IContext context;

            public ShapeCreaterCommandHandler(IContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(ShapeCreaterCommand request, CancellationToken cancellationToken)
            {
                Shape newShape = new Shape()
                {
                    MapId = request.EntityDTO.MapId,
                    Type = EnumParser.ToEnum<ShapeType>(request.EntityDTO.Type),
                    Xml = XmlParser.Serialize<IShape>(request.EntityDTO.Data),                    
                };
            
                context.Shapes.Add(newShape);

                await this.context.SaveChangesAsync(cancellationToken);

                return newShape.Id;
            }
        }
    }
}
