using System.Collections.Generic;
using MediatR;
using Domain;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
namespace Application.Activities
{
  public class List
  {
    public class Query : IRequest<List<Activity>> { }

    public class Handler : IRequestHandler<Query, List<Activity>>
    {
      public readonly DataContext _context;
      
      public Handler(DataContext context, ILogger<List> logger)
      {
        _context = context;
      }

      public async Task<List<Activity>> Handle(Query query, CancellationToken cancellationToken)
      {
        var activities = await _context.Activities.ToListAsync();
        return activities;
      }
    }
  }
}