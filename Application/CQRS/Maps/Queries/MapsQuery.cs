using Application.Common.Interfaces;
using Application.CQRS.Maps.TransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Maps.Queries
{
    public class MapsQuery: IRequest<List<MapDTO>>
    {
        public class MapsQueryHandler : IRequestHandler<MapsQuery, List<MapDTO>>
        {
            private readonly IContext context;
            private readonly IMapper mapper;

            public MapsQueryHandler(IContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<List<MapDTO>> Handle(MapsQuery request, CancellationToken cancellationToken)
            {
                var maps = await context.Maps
                    .ProjectTo<MapDTO>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return maps;
            }
        }
    }
}
