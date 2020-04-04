using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CheckAgainstMinDsfFactorRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            double minDsf = double.TryParse(request.MinDsfSetting, out minDsf) ? minDsf : 0.1;
            if (request.DsfFactor < minDsf)
            {
                request.DsfFactor = minDsf;
            }
            else
            {
                base.Handle(request);
            }
        }
    }
}
