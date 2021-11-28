using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _id;

        public CustomerBuilder()
        {
            _id = 0;
        }
        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id);
        }
    }

}