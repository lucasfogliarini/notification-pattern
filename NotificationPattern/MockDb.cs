namespace NotificationPattern
{
    internal static class MockDb
    {
        public static ICollection<Account> Accounts { get; set; } = new List<Account>()
        {
            new Account() { Cpf = "51831697050", Balance = -10 },
            new Account() { Cpf = "53158856077", Balance = 0 }
        };
    }
    public class Account
    {
        public string Cpf { get; set; }
        public decimal Balance { get; set; }
    }
}
