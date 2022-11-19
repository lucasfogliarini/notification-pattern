using FluentValidator.Validation;

namespace NotificationPattern.Contracts
{
    public class TransferContract : ValidationContract
    {
        public TransferContract(TransferInput transfer)
        {
            IsNotNullOrEmpty(transfer.FromAccountCpf, nameof(TransferInput.FromAccountCpf), "FromAccountCpf não pode ser vazio.");
            IsNotNullOrEmpty(transfer.ToAccountCpf, nameof(TransferInput.ToAccountCpf), "ToAccountCpf não pode ser vazio.");
            IsGreaterThan(transfer.Value, 0, nameof(TransferInput.Value), "Value não pode ser menor do que 0.");

            string accountNotFoundMessage = $"Não foi encontrado nenhuma conta com o cpf informado";
            IsNotNull(transfer.FromAccount, nameof(TransferInput.FromAccountCpf), $"{accountNotFoundMessage} ({transfer.FromAccountCpf})");
            IsNotNull(transfer.ToAccount, nameof(TransferInput.ToAccountCpf), $"{accountNotFoundMessage} ({transfer.ToAccountCpf})");

            if (transfer.FromAccount != null)
            {
                IsGreaterOrEqualsThan(transfer.Value, transfer.FromAccount.Balance, nameof(Account.Balance), "FromAccount.Balance não pode ser menor do que o valor de transferência.");
            }
        }
    }
}
