using NUnit.Framework;
using SeleniumWD_OP.model;

namespace SeleniumWD_OP
{
    [TestFixture]
    public class CustomerRegistrationTests : TestBase
    {
        [Test, TestCaseSource(typeof(DataProviders), "ValidCustomers")]
        public void CanRegisterCustomer(Customer customer)
        {
            ISet<String> oldIds = app.GetCustomerIds();

            app.RegisterNewCustomer(customer);
            
            ISet<String> newIds = app.GetCustomerIds();

            NUnit.Framework.Assert.IsTrue(newIds.IsSupersetOf(oldIds));
            NUnit.Framework.Assert.IsTrue(newIds.Count == oldIds.Count + 1);
        }
    }
}