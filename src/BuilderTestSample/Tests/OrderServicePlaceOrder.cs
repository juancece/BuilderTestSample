using System;
using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new ();
        private readonly OrderBuilder _orderBuilder = new ();
        private readonly CustomerBuilder _customerBuilder = new();

        [Fact]
        public void CreatesOrderGivenOrderWithNoId()
        {
            var order = _orderBuilder
                .WithId(0)
                .Build();

            Assert.NotNull(order);
            Assert.Equal(CustomerBuilder.TEST_CUSTOMER_ID, order.Customer.Id);
            Assert.Equal(CustomerBuilder.TEST_CUSTOMER_TOTAL_PURCHASES, order.Customer.TotalPurchases);
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithId(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWith0TotalAmount()
        {
            var order = _orderBuilder
                .WithTotalAmount(0)
                .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithNoAssoiatedCustomer()
        {
            var order = _orderBuilder
                .WithCustomer(null)
                .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithCustomerWitId0()
        {
            var customer = _customerBuilder
                .WithId(0)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithCustomerWithAddressNull()
        {
            var customer = _customerBuilder
                .WithAddress(null)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("juan", "")]
        [InlineData("", "carmona")]
        [InlineData("juan", null)]
        [InlineData(null, "carmona")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void ThrowsExceptionGivenOrderWithCustomerWithEmptyFirstOrLastName(string firstName, string lastName)
        {
            var customer = _customerBuilder
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(199)]
        public void ThrowsExceptionGivenOrderWithCustomerWithCreditUnder200(int rating)
        {
            var customer = _customerBuilder
                .WithCreditRating(rating)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Action action = () => _orderService.PlaceOrder(order);

            var exception = Assert.Throws<InsufficientCreditException>(action);
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithCustomerWithNoTotalPurchases()
        {
            var customer = _customerBuilder
                .WithTotalPurchases(0m)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Action action = () => _orderService.PlaceOrder(order);

            var exception = Assert.Throws<InvalidCustomerException>(action);
        }
    }
}
