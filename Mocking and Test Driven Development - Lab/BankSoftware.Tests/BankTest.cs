using Mocking_and_Test_Driven_Development___Lab;
using NUnit.Framework;

namespace BankSoftware.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Transfer_Money_Should_Work()
        {
            
            Bank bank = new Bank(new BankTextDb());
            
            bank.TransferMoney("Peshkata", "Goshkata", 30);
            Assert.AreEqual(20, bank.Users[0].Account.Amount);
            Assert.AreEqual(80, bank.Users[1].Account.Amount);
        }
    }
}