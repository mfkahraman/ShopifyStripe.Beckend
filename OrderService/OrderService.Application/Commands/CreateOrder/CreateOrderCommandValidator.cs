using FluentValidation;

namespace OrderService.Application.Commands.CreateOrder
{
    public class CreateOrderCommandValidator
        : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.ExternalOrderId)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.TotalAmount)
                .NotNull();

            RuleFor(x => x.TotalAmount.Amount)
                .GreaterThan(0);

            RuleFor(x => x.TotalAmount.Currency)
                .NotEmpty()
                .Length(3);

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemDtoValidator());
        }
    }
}
