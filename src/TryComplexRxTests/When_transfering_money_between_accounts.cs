using System.Linq;
using NUnit.Framework;
using Should.Fluent;
using TryComplexRx;
using TryComplexRx.Domain;

namespace TryComplexRxTests
{
    public class When_transfering_money_between_accounts
    {
        private Account _account1;
        private Account _account2;
        private EventRecorder<dynamic> _recorder;

        [TestFixtureSetUp]
        public void Given_two_accounts()
        {
            const string context = "TEST";

            _recorder = RxHelpers.Recorder<dynamic>(context);
            Env.Events.Subscribe(_recorder);

            Accounts.Register();
            

            // Business logic
            _account1 = Account.Create(context, "ACC1");
            _account2 = Account.Create(context, "ACC2");

            _account1.SendTransferTo(_account2.Number, 12.0m);            
        }

        [Test]
        public void Should_trnasfer_money_from()
        {
            var transferEvents = _recorder.Messages.OfType<MoneyTransferedFrom>().ToList();
            transferEvents.Should().Contain.One(x => x.AccountNumber == "ACC1" && x.Amount == 12.0m);
        }

        [Test]
        public void Should_trnasfer_money_to()
        {
            _recorder.Messages.OfType<MoneyTransferedTo>().Should().Contain.One(
                x => x.AccountNumber == "ACC2" && x.Amount == 12.0m);
        }

        [Test]
        public void Should_change_current_balance_for_target()
        {
            _account2.CurrentBalance.Should().Equal(12.0m);            
        }

        [Test]
        public void Should_change_current_balance_for_source()
        {
            _account2.CurrentBalance.Should().Equal(-12.0m);
        }
    }
}
