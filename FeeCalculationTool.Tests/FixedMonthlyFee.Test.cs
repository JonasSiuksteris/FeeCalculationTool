using FeeCalculationTool.Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FeeCalculationTool.Tests
{
    public class FixedMonthlyFeeTests
    {
        [Theory]
        [ClassData(typeof(TestDataForSinglePayment))]
        public void Execute_FeeShouldBeCorrectWithSinglePayment(string merchant, DateTime time, double startingFee, double expectedFee, int monthlyFee)
        {
            var payment = new Payment { Fee = startingFee, Merchant = merchant, Time = time };

            var rule = new FixedMonthlyFee(monthlyFee);

            payment = rule.Execute(payment);

            Assert.Equal(expectedFee, payment.Fee);
        }

        [Theory]
        [ClassData(typeof(TestDataForMultiplePayments))]
        public void Execute_FeeShouldBeCorrectWithMultiple(List<Payment> payments, int monthlyFee, double expectedFee)
        {
            var rule = new FixedMonthlyFee(monthlyFee);
            double finalFee = 0;
            foreach (var payment in payments)
            {
                finalFee = rule.Execute(payment).Fee;
            }

            Assert.Equal(expectedFee, finalFee);
        }

        public class TestDataForSinglePayment : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "TELIA", new DateTime(2018, 09, 02), 1.2, 30.2, 29 };
                yield return new object[] { "TELIA", new DateTime(2018, 09, 02), 0, 0, 29 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class TestDataForMultiplePayments : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new List<Payment>
                {
                    new Payment()
                    {
                        Merchant = "TELIA",
                        Time = new DateTime(2018, 09, 02),
                        Fee= 1.2
                    },
                    new Payment()
                    {
                        Merchant = "TELIA",
                        Time = new DateTime(2018, 09, 21),
                        Fee= 1.2
                    }
                },
                    29,
                    1.2
                };

                yield return new object[] { new List<Payment>
                    {
                        new Payment()
                        {
                            Merchant = "TELIA",
                            Time = new DateTime(2018, 09, 02),
                            Fee= 1.2
                        },
                        new Payment()
                        {
                            Merchant = "CIRCLE_K",
                            Time = new DateTime(2018, 09, 21),
                            Fee= 1.2
                        },
                        new Payment()
                        {
                            Merchant = "TELIA",
                            Time = new DateTime(2018, 09, 24),
                            Fee= 1.2
                        },
                        new Payment()
                        {
                            Merchant = "TELIA",
                            Time = new DateTime(2018, 10, 02),
                            Fee= 0.1
                        }
                    },
                    29,
                    29.1
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
