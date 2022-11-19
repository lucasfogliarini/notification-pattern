using NotificationPattern.Validators;

namespace NotificationPattern.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public void Transfer_ShouldValidateBalance_GivenBalanceLessThan0()
        {
            var validator = new Validator();
            var transfer = new TransferInput 
            { 
                FromAccountCpf = "51831697050",
                ToAccountCpf = "53158856077",
                Value = 90,
            };
            new AccountService(validator).Transfer(transfer);

            Assert.Equal(1, validator.Errors.Count);
        }
    }
}