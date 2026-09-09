using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using eCommerce.ProductService.BusinessLogicLayer.DTOs;

namespace eCommerce.ProductService.BusinessLogicLayer.Validator
{
    public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        
        private const string GuidPattern =
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z\s])[^\s]{8,}$";

        private static readonly Regex GuidRegex =
            new(GuidPattern, RegexOptions.Compiled, TimeSpan.FromMilliseconds(200));

        public ProductUpdateRequestValidator()
        {
            RuleFor(temp => temp.ProductID).NotEmpty().WithMessage("Guid is required.");
            RuleFor(temp => temp.ProductName).NotEmpty().WithMessage("Product name is required.");
            RuleFor(temp => temp.Category).IsInEnum().WithMessage("Invalid category option.");
            RuleFor(temp => temp.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("Unit price must be greater than or equal to 0.");
            RuleFor(temp => temp.QuantityInStock).GreaterThanOrEqualTo(0).WithMessage("Quantity in stock must be greater than or equal to 0.");
        }

        private static bool BeValidGuid(string guid)
      => GuidRegex.IsMatch(guid);
    }
}

