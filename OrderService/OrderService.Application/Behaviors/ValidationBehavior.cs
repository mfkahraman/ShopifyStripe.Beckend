using FluentValidation;
using MediatR;
using OrderService.Application.Exceptions;

namespace OrderService.Application.Behaviors
{
    public class ValidationBehavior<TReq, TRes>
        : IPipelineBehavior<TReq, TRes>
        where TReq : notnull
    {
        private readonly IEnumerable<IValidator<TReq>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TReq>> validators)
        {
            _validators = validators;
        }

        public async Task<TRes> Handle(
            TReq request,
            RequestHandlerDelegate<TRes> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TReq>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults
                    .SelectMany(r => r.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                    throw new ApplicationValidationException(failures);
            }

            return await next();
        }
    }
}
