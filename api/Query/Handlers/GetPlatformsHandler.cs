﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using api.Storage;
using api.ViewModels;
using MediatR;

namespace api.Query.Handlers
{
    public class GetPlatformsHandler : IRequestHandler<GetPlatforms, IEnumerable<PlatformViewModel>>
    {
        private readonly GameTrackerContext _context;

        public GetPlatformsHandler(GameTrackerContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<PlatformViewModel>> Handle(GetPlatforms request, CancellationToken cancellationToken)
        {
            return Task.FromResult((from p in _context.Platforms
                                    select new PlatformViewModel
                                    {
                                        Id = p.Id,
                                        Name = p.Name
                                    }).AsEnumerable());
        }
    }
}