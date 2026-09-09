using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.BusinessLogicLayer.DTOs;

namespace eCommerce.BusinessLogicLayer.Validator
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(temp => temp.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(temp => temp.Category).IsInEnum().WithMessage("Invalid category option.");
            RuleFor(temp => temp.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");
            RuleFor(temp => temp.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be greater than or equal to 0.");
        }


    }
}
