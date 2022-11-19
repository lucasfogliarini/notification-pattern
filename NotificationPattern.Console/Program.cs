// See https://aka.ms/new-console-template for more information

using ConsoleTables;
using NotificationPattern.Accounts;
using NotificationPattern.Validators;

var transfer = new TransferInput();
Console.WriteLine("Digite o cpf da conta de origem (ex. 51831697050):");
transfer.FromAccountCpf = Console.ReadLine();
Console.WriteLine("Digite o cpf da conta de destino (ex. 53158856077):");
transfer.ToAccountCpf = Console.ReadLine();
Console.WriteLine("Digite o valor que deseja transferir:");
transfer.Value = Convert.ToDecimal(Console.ReadLine());

var accountService = new AccountService(new Validator());
accountService.Transfer(transfer);

if (accountService.Validator.IsValid)
{
    Console.WriteLine($"Transferência concluída. R${transfer.Value} foram transferidos para a conta {transfer.ToAccountCpf}");
}
else
{
    ConsoleTable
      .From(accountService.Validator.Errors)
      .Write();
}



