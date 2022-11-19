using FluentValidator.Validation;
using FluentValidator;

namespace NotificationPattern.Contracts
{
    public class Validator : Notifiable
    {
        public void Validate<TContract>(object value) where TContract : ValidationContract
        {
            var contract = (TContract)Activator.CreateInstance(typeof(TContract), value);
            AddNotifications(contract);
        }
    }
}
