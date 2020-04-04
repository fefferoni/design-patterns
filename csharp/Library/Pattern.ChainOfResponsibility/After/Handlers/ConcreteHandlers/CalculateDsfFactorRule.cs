using Pattern.ChainOfResponsibility.After.Handlers.Abstractions;
using Pattern.ChainOfResponsibility.After.Models;

namespace Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers
{
    public class CalculateDsfFactorRule : BaseRuleHandler<DsfRequest>
    {
        public override void Handle(DsfRequest request)
        {
            var desicionSupportfactor = (request.Weight - request.Age) / (request.AverageHealthPoints * 7);
            request.DsfFactor = (desicionSupportfactor + 5) / 10;

            base.Handle(request);
        }
    }
}
