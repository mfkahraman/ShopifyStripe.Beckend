using FluentValidation.Results;

namespace OrderService.Application.Exceptions
{
    public class ApplicationValidationException : Exception
    {
        public IReadOnlyCollection<ValidationFailure> Errors { get; }

        public ApplicationValidationException(
            IEnumerable<ValidationFailure> failures)
            : base("One or more validation errors occurred.")
        {
            Errors = failures.ToList().AsReadOnly();
        }
    }
}
