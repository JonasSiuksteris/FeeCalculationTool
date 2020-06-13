using System;

namespace FeeCalculationTool
{
    public class Payment
    {
        public DateTime Time { get; set; }
        public string Merchant { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }

        public Payment()
        {
            Fee = 0;
        }
    }
}
