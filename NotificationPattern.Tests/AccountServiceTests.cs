using NotificationPattern.Contracts;

namespace NotificationPattern.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public void Transfer()
        {
            var validator = new Validator();
            var transfer = new TransferInput 
            { 
                FromAccountCpf = "51831697050",
                ToAccountCpf = "53158856077",
                Value = 10,
            };
            new AccountService(validator).Transfer(transfer);

            var noti = validator.Notifications;

        }
    }
}