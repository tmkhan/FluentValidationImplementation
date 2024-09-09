using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Queries
{
    public class GetProductByIdQuery:IRequest<IEnumerable<Domain.Entities.Product>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _context;
        public GetProductByIdHandler(IApplicationDbContext context)
        {
                _context=context;
        }
        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result=await _context.Product.Where(x=>x.Id==request.Id) .ToListAsync(cancellationToken);
            return result;
            
        }
    }

    //This class to be developed in domain
    
}
