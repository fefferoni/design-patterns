using Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers;
using Pattern.ChainOfResponsibility.After.Models;
using Pattern.ChainOfResponsibility.Before;
using System;
using Xunit;

namespace Patterns.Tests
{
    public class ChainOfResponsibility
    {
        [Theory]
        [InlineData(36, 70, 170, 7.4)]
        [InlineData(1, 10, 50, 8)]
        [InlineData(90, 58, 169, 3.4)]
        public void RefactoredCodeProducesSameResultAsOriginalCode(int age, int weight, int height, double avgHealthPoints)
        {
            // Arrange
            var oldDsfHandler = new OldDsfHandler(new SettingsRepo());

            var actualRequest = new DsfRequest(age, weight, height, avgHealthPoints, "", "", "", "");

            var handler = new CheckBmiRule();
            handler.SetNext(new CheckAgeRule())
                .SetNext(new CheckAvgHealthPointsRule())
                .SetNext(new CalculateDsfFactorRule())
                .SetNext(new CheckAgainstMaxDsfFactorRule())
                .SetNext(new CheckAgainstMinDsfFactorRule());

            // Act
            var expectedDsfValue = oldDsfHandler.GetDecisionSupportFactor(age, weight, height, avgHealthPoints);
            handler.Handle(actualRequest);

            // Assert
            Assert.Equal(expectedDsfValue, actualRequest.DsfFactor);
        }
    }
}
