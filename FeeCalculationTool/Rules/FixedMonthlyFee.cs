using System.Collections.Generic;

namespace FeeCalculationTool.Rules
{
    public class FixedMonthlyFee : IRule
    {
        private readonly int _monthlyFee;
        private readonly Dictionary<string, int> _lastTransactionMonth;

        /// <summary>Initializes a new instance of the <see cref="T:FixedMonthlyFee" /> class for the specified file name.</summary>
        /// <param name="monthlyFee">Fixed fee for merchants after their first transaction of the month</param>
        public FixedMonthlyFee(int monthlyFee)
        {
            _monthlyFee = monthlyFee;
            _lastTransactionMonth = new Dictionary<string, int>();
        }
        public Payment Execute(Payment payment)
        {
            if (payment.Fee == 0)
                return payment;

            if (!_lastTransactionMonth.ContainsKey(payment.Merchant))
            {
                _lastTransactionMonth.Add(payment.Merchant, payment.Time.Month);
                payment.Fee += _monthlyFee;
                return payment;
            }

            if (_lastTransactionMonth[payment.Merchant] == payment.Time.Month)
                return payment;

            _lastTransactionMonth[payment.Merchant] = payment.Time.Month;
            payment.Fee += _monthlyFee;
            return payment;
        }
    }
}
