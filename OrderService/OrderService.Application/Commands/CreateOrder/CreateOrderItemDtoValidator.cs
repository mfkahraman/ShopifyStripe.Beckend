using FluentValidation;
using OrderService.Application.Dtos;

namespace OrderService.Application.Commands.CreateOrder
{
    public class CreateOrderItemDtoValidator
        : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThan(0);

            RuleFor(x => x.UnitPrice)
                .NotNull();

            RuleFor(x => x.UnitPrice.Amount)
                .GreaterThan(0);
        }
    }
}
