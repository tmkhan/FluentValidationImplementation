using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    public class ValidationsBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationsBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Pre -processsing

            if(_validator.Any())
            {
                var validationContext=new ValidationContext<TRequest>(request);
                var result =await Task.WhenAll( _validator.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
                var failures=result.SelectMany(r => r.Errors).Where(failure=>failure!=null).ToList();
                if(failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            //Next
            var response=await next();
            // Post Processing Logic

            return response;
            //throw new NotImplementedException();

        }
    }
}
