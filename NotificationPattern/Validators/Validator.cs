using FluentValidation;
using FluentValidation.Results;

namespace NotificationPattern.Validators
{
    public class Validator : ValidationResult
    {
        public void Validate<TValidator, TValue>(TValue value) where TValidator : IValidator<TValue>
        {
            var validator = Activator.CreateInstance<TValidator>();
            Errors.AddRange(validator.Validate(value).Errors);
        }
    }
}
