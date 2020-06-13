using FeeCalculationTool.Rules;
using System;
using System.Collections.Generic;
using System.IO;

namespace FeeCalculationTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;

            var ruleEvaluator = new RuleEvaluator(new List<IRule>
            {
                new TransactionPercentageFee(1),
                new TransactionFeeDiscount(10, "TELIA"),
                new TransactionFeeDiscount(20, "CIRCLE_K"),
                new FixedMonthlyFee(29)
            });

            var file = new StreamReader("../../data/transactions.txt");
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (string.Empty == line) continue;

                var paymentInfo = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                var payment = new Payment
                {
                    Time = DateTime.Parse(paymentInfo[0]),
                    Merchant = paymentInfo[1],
                    Amount = Convert.ToDouble(paymentInfo[2])
                };
                var paymentWithFees = ruleEvaluator.Apply(payment);

                Console.WriteLine(paymentWithFees.Time.ToString("yyyy-MM-dd") + " " + paymentWithFees.Merchant + " " + paymentWithFees.Fee.ToString("F"));
            }
        }
    }
}
