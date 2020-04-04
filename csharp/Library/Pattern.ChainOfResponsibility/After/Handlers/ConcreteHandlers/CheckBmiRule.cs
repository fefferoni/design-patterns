using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CheckBmiRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            var bmi = request.Weight / (request.Height * request.Height);
            if (bmi > 18.5 || bmi > 25)
            {
                request.DsfFactor = 1;
            }
            else
            {
                base.Handle(request);
            }
        }
    }
}
