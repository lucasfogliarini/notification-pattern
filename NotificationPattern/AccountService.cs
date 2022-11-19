using FluentValidator;
using FluentValidator.Validation;
using System.Security.Principal;

namespace notification_pattern
{
    public class AccountService
    {
        private readonly Validator _validator;

        public AccountService(Validator validator) 
        {
            _validator = validator;
        }

        public void Transfer(TransferInput transfer)
        {
            var account = MockDb.Accounts.Where(e => e.Cpf == transfer.FromAccountCpf);
            _validator.Validate<TransferContract>(transfer);
        }
    }

    public class TransferContract : ValidationContract
    {
        public TransferContract(TransferInput transfer)
        {
            IsNotNullOrEmpty(transfer.FromAccountCpf, nameof(transfer.FromAccountCpf), "FromAccountCpf")
            .IsNotNullOrEmpty(transfer.ToAccountCpf, nameof(transfer.ToAccountCpf), "ToAccountCpf")
            .IsGreaterThan(0, transfer.Value, nameof(transfer.Value), "Value")
            .IsNotNull(transfer.FromAccount, nameof(transfer.FromAccount), "FromAccount")
            .IsGreaterOrEqualsThan(transfer.Value, transfer.FromAccount.Balance, nameof(transfer.FromAccount?.Balance), "Value")
            .IsNotNull(transfer.ToAccount, nameof(transfer.ToAccount), "ToAccount");
        }
    }

    public class Validator : Notifiable
    {
        public void Validate<TContract>(object value) where TContract : ValidationContract
        {
            var contract = (TContract)Activator.CreateInstance(typeof(TContract), value);
            AddNotifications(contract);
        }
    }
}
