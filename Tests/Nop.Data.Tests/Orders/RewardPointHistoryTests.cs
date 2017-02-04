﻿using System;
using Teromac.Core.Domain.Customers;
using Teromac.Tests;
using NUnit.Framework;

namespace Teromac.Data.Tests.Orders
{
    [TestFixture]
    public class RewardPointHistoryTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_rewardPointHistory()
        {
            var rph = new RewardPointsHistory
            {
                StoreId = 1,
                Customer = GetTestCustomer(),
                Points = 2,
                PointsBalance = 3,
                UsedAmount = 4,
                Message = "Message 5",
                CreatedOnUtc= new DateTime(2010, 01, 04)
            };

            var fromDb = SaveAndLoadEntity(rph);
            fromDb.ShouldNotBeNull();
            fromDb.StoreId.ShouldEqual(1);
            fromDb.Customer.ShouldNotBeNull();
            fromDb.Points.ShouldEqual(2);
            fromDb.PointsBalance.ShouldEqual(3);
            fromDb.UsedAmount.ShouldEqual(4);
            fromDb.Message.ShouldEqual("Message 5");
            fromDb.CreatedOnUtc.ShouldEqual(new DateTime(2010, 01, 04));
        }

        protected Customer GetTestCustomer()
        {
            return new Customer
            {
                CustomerGuid = Guid.NewGuid(),
                AdminComment = "some comment here",
                Active = true,
                Deleted = false,
                CreatedOnUtc = new DateTime(2010, 01, 01),
                LastActivityDateUtc = new DateTime(2010, 01, 02)
            };
        }
    }
}
