using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal rate { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product=_mapper.Map<Domain.Entities.Product>(request);
            //var product = new Domain.Entities.Product();
            //product.name = request.name;
            //product.description = request.description;
            //product.rate = request.rate;

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;

        }
    }
}
