using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        public const int TEST_CUSTOMER_ID = 123;

        private int _id;
        private Address _address;
        private string _firstName;
        private string _lastName;

        public CustomerBuilder()
        {
            _id = TEST_CUSTOMER_ID;
            _address = new Address();
        }

        public CustomerBuilder WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id)
            {
                
                HomeAddress = _address,
                FirstName = _firstName,
                LastName = _lastName
            };
        }

    }

}