namespace FeeCalculationTool.Rules
{
    public interface IRule
    {
        Payment Execute(Payment payment);
    }
}
