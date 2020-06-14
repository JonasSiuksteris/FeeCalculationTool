using FeeCalculationTool.Rules;
using System.Collections.Generic;
using System.Linq;

namespace FeeCalculationTool
{
    public class RuleEvaluator
    {
        private readonly IList<IRule> _rules;

        public RuleEvaluator()
        {
            _rules = new List<IRule>();
        }
        public RuleEvaluator(IList<IRule> rules)
        {
            _rules = rules;
        }

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }

        public Payment Apply(Payment payment)
        {
            return _rules.Aggregate(payment, (current, rule) => rule.Execute(current));
        }
    }
}
