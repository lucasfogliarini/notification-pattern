// See https://aka.ms/new-console-template for more information

using ConsoleTables;
using NotificationPattern.Accounts;
using NotificationPattern.Validators;

while (true)
{
    var validator = new Validator();
    var transfer = new TransferInput();
    Console.WriteLine("Digite o cpf da conta de origem (ex. 51831697050):");
    transfer.FromAccountCpf = Console.ReadLine();
    Console.WriteLine("Digite o cpf da conta de destino (ex. 53158856077):");
    transfer.ToAccountCpf = Console.ReadLine();
    Console.WriteLine("Digite o valor que deseja transferir:");
    decimal value;
    var valueIsDecimal = decimal.TryParse(Console.ReadLine(), out value);
    transfer.Value = value;
    if (!valueIsDecimal)
        validator.AddError("O valor digitado deve ser um número decimal", "Value");

    var accountService = new AccountService(validator);
    accountService.Transfer(transfer);

    if (accountService.Validator.IsValid)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Transferência concluída. R${transfer.Value} foram transferidos para a conta {transfer.ToAccountCpf}");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        ConsoleTable
          .From(accountService.Validator.Errors)
          .Write();
    }
    Console.ResetColor();
}





