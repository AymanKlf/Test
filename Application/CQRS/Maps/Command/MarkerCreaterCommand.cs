using Application.Common.Interfaces;
using Application.CQRS.Maps.TransferObjects;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Maps.Command
{
    public class MarkerCreaterCommand : IRequest<int>
    {
        public MarkerDTO EntityDTO { get; private set; }

        public MarkerCreaterCommand(MarkerDTO dto)
        {
            EntityDTO = dto;
        }

        public class MarkerCreaterCommandHandler : IRequestHandler<MarkerCreaterCommand, int>
        {
            private IContext context;

            public MarkerCreaterCommandHandler(IContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(MarkerCreaterCommand request, CancellationToken cancellationToken)
            {
                Marker newMarker = new Marker()
                {
                    MapId = request.EntityDTO.MapId,
                    Name = request.EntityDTO.Name,
                    Position = Domain.ValueObjects.CoordinatePoint.For(request.EntityDTO.Position.Latitude, request.EntityDTO.Position.Longitude),
                    Address = request.EntityDTO.Address,
                };

                context.Markers.Add(newMarker);

                await this.context.SaveChangesAsync(cancellationToken);

                return newMarker.Id;
            }

        }
    }
}
