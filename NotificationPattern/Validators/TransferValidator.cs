using FluentValidation;

namespace NotificationPattern.Validators
{
    public class TransferValidator : AbstractValidator<TransferInput>
    {
        public TransferValidator()
        {
            RuleFor(e => e.FromAccountCpf).NotEmpty().WithMessage("FromAccountCpf deve conter valor.");
            RuleFor(e => e.ToAccountCpf).NotEmpty().WithMessage("ToAccountCpf deve conter valor.");
            RuleFor(e => e.Value).GreaterThan(0).WithMessage("Value deve ser maior do que 0.");

            string accountNotFoundMessage = $"Não foi encontrado nenhuma conta com o cpf informado";
            RuleFor(e => e.FromAccount).NotEmpty().WithMessage(e=>$"{accountNotFoundMessage} ({e.FromAccountCpf})");
            RuleFor(e => e.ToAccount).NotEmpty().WithMessage(e=> $"{accountNotFoundMessage} ({e.ToAccountCpf})");

            When(e => e.FromAccount != null, () =>
            {
                RuleFor(e => e.FromAccount.Balance).GreaterThanOrEqualTo(e=>e.Value).WithMessage(e=> $"FromAccount.Balance ({e.FromAccount.Balance}) deve ser maior ou igual ao valor de transferência. ({e.Value})");
            });
        }
    }
}
