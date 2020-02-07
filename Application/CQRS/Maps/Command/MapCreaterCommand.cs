using Application.Common.Interfaces;
using Application.CQRS.Maps.TransferObjects;
using Application.CQRS.Maps.TransferObjects.Shapes;
using Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static Application.CQRS.Maps.Command.MarkerCreaterCommand;

namespace Application.CQRS.Maps.Command
{
    public class MapCreaterCommand: IRequest<int>
    {
        public MapDTO EntityDTO { get; private set; }

        public MapCreaterCommand(MapDTO dto)
        {
            EntityDTO = dto;
        }

        public class MapCreaterCommandHandler : IRequestHandler<MapCreaterCommand, int>
        {            
            private IContext context;
            private IMediator mediator;
            public MapCreaterCommandHandler(IContext context, IMediator mediator)
            {
                this.context = context;
                this.mediator = mediator;
            }

            private MapDTO entityDTO;
            public async Task<int> Handle(MapCreaterCommand request, CancellationToken cancellationToken)
            {
                entityDTO = request.EntityDTO;

                Map newMap = new Map()
                {
                    Zoom = request.EntityDTO.Zoom,
                    Center = Domain.ValueObjects.CoordinatePoint.For(request.EntityDTO.Center.Latitude, request.EntityDTO.Center.Longitude),
                };

                context.Maps.Add(newMap);

                await this.context.SaveChangesAsync(cancellationToken);

                entityDTO.Id = newMap.Id;
                
                await this.CreateMapMarkers();
                await this.CreateMapShapes();

                return newMap.Id;
            }

            private async Task CreateMapMarkers()
            {
                foreach (MarkerDTO item in entityDTO.Markers)
                {
                    item.MapId = entityDTO.Id;

                    await mediator.Send(new MarkerCreaterCommand(item));
                }
            }

            private async Task CreateMapShapes()
            {
                foreach (ShapeDTO item in entityDTO.Shapes)
                {
                    item.MapId = entityDTO.Id;

                    await mediator.Send(new ShapeCreaterCommand(item));
                }
            }
        }
    }
}
