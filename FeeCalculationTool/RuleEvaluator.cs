using FeeCalculationTool.Rules;
using System.Collections.Generic;
using System.Linq;

namespace FeeCalculationTool
{
    public class RuleEvaluator
    {
        private readonly IList<IRule> _rules;

        /// <summary>Initializes a new instance of the <see cref="T:RuleEvaluator" /> class for the specified file name without defined rules.</summary>
        public RuleEvaluator()
        {
            _rules = new List<IRule>();
        }

        /// <summary>Initializes a new instance of the <see cref="T:RuleEvaluator" /> class for the specified file name with defined rules.</summary>
        /// <param name="rules">A list of rules</param>
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
