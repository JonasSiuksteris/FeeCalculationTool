using FeeCalculationTool.Rules;
using System.Collections.Generic;
using System.Linq;

namespace FeeCalculationTool
{
    public class RuleEvaluator
    {
        private readonly IEnumerable<IRule> _rules;

        public RuleEvaluator(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        public Payment Apply(Payment payment)
        {
            return _rules.Aggregate(payment, (current, rule) => rule.Execute(current));
        }
    }
}
