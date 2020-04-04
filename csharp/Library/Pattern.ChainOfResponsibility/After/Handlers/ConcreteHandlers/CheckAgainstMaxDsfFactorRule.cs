using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CheckAgainstMaxDsfFactorRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            double maxDsf = double.TryParse(request.MaxDsfSetting, out maxDsf) ? maxDsf : 1.5;
            if (request.DsfFactor > maxDsf)
            {
                request.DsfFactor = maxDsf;
            }
            else
            {
                base.Handle(request);
            }
        }
    }
}
