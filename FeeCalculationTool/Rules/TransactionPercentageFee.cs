namespace FeeCalculationTool.Rules
{
    public class TransactionPercentageFee : IRule
    {
        private readonly int _feePercentage;

        /// <summary>Initializes a new instance of the <see cref="T:TransactionPercentageFee" /> class for the specified file name.</summary>
        /// <param name="feePercentage">Transaction Percentage Fee that all merchants are charges with. (In %)</param>
        public TransactionPercentageFee(int feePercentage)
        {
            _feePercentage = feePercentage;
        }
        public Payment Execute(Payment payment)
        {

            payment.Fee += payment.Amount * _feePercentage / 100;

            return payment;
        }
    }
}
