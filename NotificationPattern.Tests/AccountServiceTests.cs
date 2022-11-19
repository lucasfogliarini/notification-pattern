namespace notification_pattern.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public void Test1()
        {
            var validator = new Validator();
            var transfer = new TransferInput 
            { 
                FromAccountCpf = "",
                ToAccountCpf = "",
                Value = 50
            };
            new AccountService(validator).Transfer(transfer);

        }
    }
}