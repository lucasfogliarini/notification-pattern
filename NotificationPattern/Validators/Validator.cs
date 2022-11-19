using FluentValidation;

namespace NotificationPattern.Validators
{
    public class Validator
    {
        public List<ValidationError> Errors { get; private set; } = new List<ValidationError>();
        public bool IsValid { get { return Errors.Count == 0; } }
        public void Validate<TValidator, TValue>(TValue value) where TValidator : IValidator<TValue>
        {
            var validator = Activator.CreateInstance<TValidator>();
            var errors = validator.Validate(value).Errors.Select(e => new ValidationError(e.ErrorMessage, e.PropertyName));

            Errors.AddRange(errors);
        }

        public void AddError(string errorMessage, string propertyName)
        {
            Errors.Add(new ValidationError(errorMessage, propertyName));
        }
    }
    public class ValidationError
    {
        public ValidationError(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }

        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }
    }
}
