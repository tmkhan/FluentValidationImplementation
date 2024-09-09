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
    public class UpdateProductCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal rate { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product=await _context.Product.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (product != null)
            {
               product.Id = request.Id;
                product.name = request.name;
                product.description = request.description;
                product.rate = request.rate;

               // _context.Product.Update(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
            return default;

        }
    }
}
