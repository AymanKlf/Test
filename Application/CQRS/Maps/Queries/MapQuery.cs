using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.CQRS.Maps.TransferObjects;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Maps.Queries
{
    public class MapQuery: IRequest<MapDTO>
    {
        private int id;

        public MapQuery(int id)
        {
            this.id = id;
        }

        public class MapQueryHandler : IRequestHandler<MapQuery, MapDTO>
        {
            private readonly IContext context;
            private readonly IMapper mapper;

            public MapQueryHandler(IContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<MapDTO> Handle(MapQuery request, CancellationToken cancellationToken)
            {
                var map = await context.Maps
                   .Where(t => t.Id == request.id)
                   .ProjectTo<MapDTO>(mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync(cancellationToken);

                if (map == null)
                {
                    throw new EntityNotFoundException(nameof(Map), request.id);
                }

                return map;
            }
        }

    }
}
