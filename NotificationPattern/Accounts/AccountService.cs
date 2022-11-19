using NotificationPattern.Validators;

namespace NotificationPattern.Accounts
{
    public class AccountService
    {
        public Validator Validator { get; private set; }

        public AccountService(Validator validator)
        {
            Validator = validator;
        }

        public void Transfer(TransferInput transfer)
        {
            transfer.FromAccount = MockDb.Accounts.FirstOrDefault(e => e.Cpf == transfer.FromAccountCpf);
            transfer.ToAccount = MockDb.Accounts.FirstOrDefault(e => e.Cpf == transfer.ToAccountCpf);
            Validator.Validate<TransferValidator, TransferInput>(transfer);
            if (Validator.IsValid)
            {
                transfer.FromAccount.Balance -= transfer.Value;
                transfer.ToAccount.Balance += transfer.Value;
            }
        }
    }
}
