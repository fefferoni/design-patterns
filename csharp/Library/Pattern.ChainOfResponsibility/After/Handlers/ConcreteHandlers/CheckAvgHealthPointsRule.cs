using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CheckAvgHealthPointsRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            double factor = double.TryParse(request.FactorSetting, out factor) ? factor : 0.75;
            if (request.AverageHealthPoints * factor <= 1)
            {
                request.DsfFactor = 3;
            }
            else
            {
                base.Handle(request);
            }
        }
    }
}
