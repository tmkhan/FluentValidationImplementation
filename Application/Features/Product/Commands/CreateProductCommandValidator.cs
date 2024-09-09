using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product.Commands
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.name)
            .NotEmpty()
            .NotNull().WithMessage("{PropertyName} is manadatory").
            Length(3, 12).WithMessage("{PropertyName} Can be between 3 and 4 characters");

            RuleFor(x => x.description).NotEmpty().NotNull().WithMessage("{PropertyName} is manadtory");

            RuleFor(x => x.rate).NotNull().NotEqual(0).WithMessage("Rate can neither be null nor zero");
        }
    }
}
