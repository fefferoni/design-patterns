using Pattern.ChainOfResponsibility.After.Handlers;
using Pattern.ChainOfResponsibility.After.Handlers.ConcreteHandlers;
using Pattern.ChainOfResponsibility.After.Models;
using Pattern.ChainOfResponsibility.Before;
using System;

namespace Pattern.ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            RunOldImplementation();

            RunRefactoredImplementation();

            Console.ReadLine();
        }

        private static void RunOldImplementation()
        {
            Console.WriteLine("Running old implementation.");
            
            var settingsRepo = new SettingsRepo();

            var age = 36;
            var weight = 70;
            var height = 170;
            var avgHealthPoints = 7.4;

            var oldHandler = new OldDsfHandler(settingsRepo);
            var resultFromOldHandler = oldHandler.GetDecisionSupportFactor(age, weight, height, avgHealthPoints);

            Console.WriteLine($"Decision support factor: {resultFromOldHandler}");
        }

        private static void RunRefactoredImplementation()
        {
            Console.WriteLine("Running refactored implementation");

            var settingsRepo = new SettingsRepo();

            var age = 36;
            var weight = 70;
            var height = 170;
            var avgHealthPoints = 7.4;
            var minAgeSetting = settingsRepo.GetSettingAsString("minAge");
            var factorSetting = settingsRepo.GetSettingAsString("factor");
            var maxDsFactorSetting = settingsRepo.GetSettingAsString("maxDsFactor");
            var minDsFactorSetting = settingsRepo.GetSettingAsString("minDsFactor");

            var request = new DsfRequest(age,
                                         weight,
                                         height,
                                         avgHealthPoints,
                                         minAgeSetting,
                                         factorSetting,
                                         maxDsFactorSetting,
                                         minDsFactorSetting);

            var handler = new CheckBmiRule();
            handler.SetNext(new CheckAgeRule())
                .SetNext(new CheckAvgHealthPointsRule())
                .SetNext(new CalculateDsfFactorRule())
                .SetNext(new CheckAgainstMaxDsfFactorRule())
                .SetNext(new CheckAgainstMinDsfFactorRule());

            
            handler.Handle(request);

            Console.WriteLine($"Decision support factor: {request.DsfFactor}");
        }
    }
}
