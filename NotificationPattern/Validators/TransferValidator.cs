using FluentValidation;
using NotificationPattern.Accounts;

namespace NotificationPattern.Validators
{
    public class TransferValidator : AbstractValidator<TransferInput>
    {
        public TransferValidator()
        {
            RuleFor(e => e.FromAccountCpf).Length(11).WithMessage("CPF de origem deve ter exatamente 11 caracteres.");
            RuleFor(e => e.ToAccountCpf).Length(11).WithMessage("CPF de destino deve exatamente 11 caracteres.");
            RuleFor(e => e.Value).GreaterThan(0).WithMessage("Valor deve ser maior do que 0.");

            string accountNotFoundMessage = $"Não foi encontrado nenhuma conta com o cpf informado";
            RuleFor(e => e.FromAccount).NotEmpty().WithMessage(e=>$"{accountNotFoundMessage} ({e.FromAccountCpf})");
            RuleFor(e => e.ToAccount).NotEmpty().WithMessage(e=> $"{accountNotFoundMessage} ({e.ToAccountCpf})");

            When(e => e.FromAccount != null, () =>
            {
                RuleFor(e => e.FromAccount.Balance).GreaterThanOrEqualTo(e=>e.Value).WithMessage(e=> $"O saldo da conta (R${e.FromAccount.Balance}) deve ser maior ou igual ao valor de transferência. (R${e.Value})");
            });
        }
    }
}
