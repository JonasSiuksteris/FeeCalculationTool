using FeeCalculationTool.Rules;
using System.IO;

namespace FeeCalculationTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paymentInfoReader = new PaymentProcessor(new RuleEvaluator());

            paymentInfoReader.RuleEvaluator.AddRule(new TransactionPercentageFee(1));
            paymentInfoReader.RuleEvaluator.AddRule(new TransactionFeeDiscount(10, "TELIA"));
            paymentInfoReader.RuleEvaluator.AddRule(new TransactionFeeDiscount(20, "CIRCLE_K"));
            paymentInfoReader.RuleEvaluator.AddRule(new FixedMonthlyFee(29));

            paymentInfoReader.Parse(new StreamReader("../../data/transactions.txt"));

        }
    }
}
