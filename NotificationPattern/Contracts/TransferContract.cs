using FluentValidator.Validation;

namespace NotificationPattern.Contracts
{
    public class TransferContract : ValidationContract
    {
        public TransferContract(TransferInput transfer)
        {
            IsNotNullOrEmpty(transfer.FromAccountCpf, nameof(TransferInput.FromAccountCpf), "FromAccountCpf deve conter valor.");
            IsNotNullOrEmpty(transfer.ToAccountCpf, nameof(TransferInput.ToAccountCpf), "ToAccountCpf deve conter valor.");
            IsGreaterThan(transfer.Value, 0, nameof(TransferInput.Value), "Value deve ser maior do que 0.");

            string accountNotFoundMessage = $"Não foi encontrado nenhuma conta com o cpf informado";
            IsNotNull(transfer.FromAccount, nameof(TransferInput.FromAccountCpf), $"{accountNotFoundMessage} ({transfer.FromAccountCpf})");
            IsNotNull(transfer.ToAccount, nameof(TransferInput.ToAccountCpf), $"{accountNotFoundMessage} ({transfer.ToAccountCpf})");

            if (transfer.FromAccount != null)
            {
                IsGreaterOrEqualsThan(transfer.FromAccount.Balance, transfer.Value, nameof(Account.Balance), $"FromAccount.Balance ({transfer.FromAccount.Balance}) deve ser maior ou igual ao valor de transferência. ({transfer.Value})");
            }
        }
    }
}
