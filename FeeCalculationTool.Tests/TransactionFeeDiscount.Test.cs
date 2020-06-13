using FeeCalculationTool.Rules;
using Xunit;

namespace FeeCalculationTool.Tests
{
    public class TransactionFeeDiscountTests
    {
        [Theory]
        [InlineData(10, "TELIA", "TELIA", 1.2, 1.08)]
        [InlineData(10, "TELIA", "TELIA", 2, 1.8)]
        [InlineData(10, "TELIA", "TELIA", 3, 2.7)]
        [InlineData(10, "TELIA", "TELIA", 1.5, 1.35)]
        [InlineData(10, "TELIA", "TELIA", 0, 0)]
        [InlineData(10, "TELIA", "CIRCLE_K", 1.5, 1.5)]
        [InlineData(20, "CIRCLE_K", "CIRCLE_K", 1.2, 0.96)]
        [InlineData(20, "CIRCLE_K", "CIRCLE_K", 2, 1.6)]
        [InlineData(100, "CIRCLE_K", "CIRCLE_K", 2, 0)]
        [InlineData(0, "CIRCLE_K", "CIRCLE_K", 2, 2)]
        public void Execute_FeeShouldBeCorrect(int feeDiscount, string ruleMerchant, string merchant, double startingFee, double expectedFee)
        {
            var payment = new Payment { Fee = startingFee, Merchant = merchant };

            var rule = new TransactionFeeDiscount(feeDiscount, ruleMerchant);

            payment = rule.Execute(payment);

            Assert.Equal(expectedFee, payment.Fee);
        }
    }
}
