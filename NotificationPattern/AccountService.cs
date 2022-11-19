using NotificationPattern.Contracts;

namespace NotificationPattern
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
            transfer.FromAccount = MockDb.Accounts.FirstOrDefault(e => e.Cpf == transfer.FromAccountCpf);
            transfer.ToAccount = MockDb.Accounts.FirstOrDefault(e => e.Cpf == transfer.ToAccountCpf);
            _validator.Validate<TransferContract>(transfer);
            if(_validator.Valid)
            {
                transfer.FromAccount.Balance -= transfer.Value;
                transfer.ToAccount.Balance += transfer.Value;
            }
        }
    }
}
