using System;
using System.IO;

namespace FeeCalculationTool
{
    public class PaymentProcessor
    {
        public RuleEvaluator RuleEvaluator { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:PaymentProcessor" /> class for the specified file name.</summary>
        /// <param name="ruleEvaluator">Instance of ruleEvaluator</param>
        public PaymentProcessor(RuleEvaluator ruleEvaluator)
        {
            RuleEvaluator = ruleEvaluator;
        }

        public void Parse(StreamReader transactions)
        {
            string transaction;
            while ((transaction = transactions.ReadLine()) != null)
            {
                transaction = transaction.Trim();
                if (string.Empty == transaction) continue;

                WriteToConsole(RuleEvaluator.Apply(SplitInfo(transaction)));
            }
        }

        private static Payment SplitInfo(string transaction)
        {
            var paymentInfo = transaction.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            return new Payment
            {
                Time = DateTime.Parse(paymentInfo[0]),
                Merchant = paymentInfo[1],
                Amount = Convert.ToDouble(paymentInfo[2])
            };
        }

        private static void WriteToConsole(Payment payment)
        {
            Console.WriteLine(payment.Time.ToString("yyyy-MM-dd") + " " + payment.Merchant + " " + payment.Fee.ToString("F"));

        }
    }
}
