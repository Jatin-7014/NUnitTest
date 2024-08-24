namespace BankNUnitTest
{
    public class Tests
    {
        BankAccount _bankAccount;
        BankAccount _toAccount;
        BankAccount account =null;
        [SetUp]
        public void Setup()
        {
            _bankAccount = new BankAccount();
            _toAccount = new BankAccount();
        }

        [TestCase(1000,6000)]
        
        public void CheckDeposit(double amountToAdd,double expectedBalance)
        {
            _bankAccount.Deposit(amountToAdd);
            double actualBalance =_bankAccount.GetBalance();

            Assert.AreEqual(actualBalance,expectedBalance);
        }
        [Test]
        public void CheckDepositAmountIsValid()
        {
            Assert.Throws<ArgumentException>(_CheckDepositAmountIsValidBody);
        }

        private void _CheckDepositAmountIsValidBody()
        {
            _bankAccount.Deposit(-1000);
        }
        [TestCase(1000, 4000)]
        public void CheckWithDraw(double amountToWithdraw, double expectedBalance)
        {
            _bankAccount.Withdraw(amountToWithdraw);
            double actualBalance = _bankAccount.GetBalance();

            Assert.AreEqual(actualBalance, expectedBalance);
        }
        [Test]
        public void Test2()
        {
            Assert.Throws<ArgumentException>(_TestBody2);
        }

        private void _TestBody2()
        {
            _bankAccount.Withdraw(0);
        }
        [Test]
        public void Test3()
        {
            Assert.Throws<InvalidOperationException>(_TestBody3);
        }

        private void _TestBody3()
        {
            _bankAccount.Withdraw(8000);
        }
        
        [TestCase(1000, 4000,6000)]
         public void CheckTransfer(double amount,double expectedBalanceFrom, double expectedBalanceTo)
         {
            _bankAccount.Transfer(_toAccount,amount);
            double actualBalanceFrom = _bankAccount.GetBalance();
            double actualBalanceTo=_toAccount.GetBalance();

            Assert.AreEqual(expectedBalanceFrom, actualBalanceFrom);
            Assert.AreEqual(expectedBalanceTo, actualBalanceTo);
         }
        
        [Test]
        public void Test4()
        {
            Assert.Throws<ArgumentNullException>(_TestBody4);
        }

        private void _TestBody4()
        {
            _bankAccount.Transfer(account,2000);
        }
    }
}