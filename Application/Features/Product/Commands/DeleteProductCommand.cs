using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class DeleteProductCommand:IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product=await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (product != null)
            {
               _context.Product.Remove(product);

               // _context.Product.Update(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
            return default;

        }
    }
}
