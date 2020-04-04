using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CheckAgeRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            int minAge = int.TryParse(request.MinAgeSetting, out minAge) ? minAge : 3;
            if (request.Age < minAge)
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
