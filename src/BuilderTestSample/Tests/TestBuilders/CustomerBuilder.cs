﻿using BuilderTestSample.Model;
using System;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        public const int TEST_CUSTOMER_ID = 123;
        public const string TEST_CUSTOMER_FIRST_NAME = "first";
        public const string TEST_CUSTOMER_LAST_NAME = "last";
        public const int TEST_CUSTOMER_CREDIT_RATING = 400;
        public const decimal TEST_CUSTOMER_TOTAL_PURCHASES = 1.23m;

        private int _id;
        private Address _address;
        private string _firstName;
        private string _lastName;
        private int _creditRating;
        private decimal _totalPurchases;

        public CustomerBuilder()
        {
            _id = TEST_CUSTOMER_ID;
            _firstName = TEST_CUSTOMER_FIRST_NAME;
            _lastName = TEST_CUSTOMER_LAST_NAME;
            _address = new Address();
            _creditRating = TEST_CUSTOMER_CREDIT_RATING;
            _totalPurchases = TEST_CUSTOMER_TOTAL_PURCHASES;
        }

        public CustomerBuilder WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        public CustomerBuilder WithCreditRating(int rating)
        {
            _creditRating = rating;
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
        public CustomerBuilder WithTotalPurchases(decimal totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id)
            {
                CreditRating = _creditRating,
                HomeAddress = _address,
                FirstName = _firstName,
                LastName = _lastName,
                TotalPurchases = _totalPurchases
            };
        }
    }

}