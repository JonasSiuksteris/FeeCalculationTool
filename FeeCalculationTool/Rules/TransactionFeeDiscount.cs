namespace FeeCalculationTool.Rules
{
    public class TransactionFeeDiscount : IRule
    {
        private readonly int _feeDiscount;
        private readonly string _merchant;

        /// <summary>Initializes a new instance of the <see cref="T:TransactionFeeDiscount" /> class for the specified file name.</summary>
        /// <param name="feeDiscount">Transaction Fee Discount. (In %)</param>
        /// <param name="merchant">Merchant name.</param>
        public TransactionFeeDiscount(int feeDiscount, string merchant)
        {
            _feeDiscount = feeDiscount;
            _merchant = merchant;
        }
        public Payment Execute(Payment payment)
        {
            if (payment.Merchant == _merchant)
            {
                payment.Fee = payment.Fee * (100 - _feeDiscount) / 100;
            }

            return payment;
        }
    }
}
