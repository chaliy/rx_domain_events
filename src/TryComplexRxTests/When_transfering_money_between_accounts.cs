namespace TryComplexRxTests
{
    using System.Linq;
    using NUnit.Framework;
    using Should.Fluent;
    using TryComplexRx;
    using TryComplexRx.Domain.Accounts;

    public class When_transfering_money_between_accounts
    {
        Account account1;
        Account account2;
        EventRecorder<dynamic> recorder;

        [TestFixtureSetUp]
        public void Given_two_accounts()
        {
            recorder = EventRecorder.Recorder<dynamic>();

            var exec = new Execution();
            exec.Events.Subscribe(recorder);
            var accounts = exec.Resolve<AccountsModule>();

            // Business logic
            account1 = accounts.CreateAccount("ACC1");
            account2 = accounts.CreateAccount("ACC2");

            account1.SendTransferTo(account2.Number, 12.0m);                                   
        }

        [Test]
        public void Should_trnasfer_money_to()
        {
            recorder.Messages.OfType<MoneyTransferedTo>().Should().Contain.One(
                x => x.TargetAccountNumber == "ACC2" && x.Amount == 12.0m);
        }

        [Test]
        public void Should_trnasfer_money_from()
        {
            recorder.Messages.OfType<MoneyTransferedFrom>()
                .Should().Contain.One(x => x.SourceAccountNumber == "ACC1" && x.Amount == 12.0m);
        }

        [Test]
        public void Should_change_current_balance_for_target()
        {
            account2.CurrentBalance.Should().Equal(12.0m);            
        }

        [Test]
        public void Should_change_current_balance_for_source()
        {
            account1.CurrentBalance.Should().Equal(-12.0m);
        }
    }
}
