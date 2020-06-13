using FeeCalculationTool.Rules;
using Xunit;

namespace FeeCalculationTool.Tests
{
    public class TransactionPercentageFeeTests
    {
        [Theory]
        [InlineData(1, 120, 1.2)]
        [InlineData(1, 200, 2)]
        [InlineData(1, 300, 3)]
        [InlineData(1, 150, 1.5)]
        [InlineData(2, 150, 3)]
        [InlineData(100, 200, 200)]
        [InlineData(0, 100, 0)]
        public void Execute_FeeShouldBeCorrect(int feePercentage, double paymentAmount, double expectedFee)
        {
            var payment = new Payment { Amount = paymentAmount };

            var rule = new TransactionPercentageFee(feePercentage);

            payment = rule.Execute(payment);

            Assert.Equal(expectedFee, payment.Fee);
        }
    }
}
