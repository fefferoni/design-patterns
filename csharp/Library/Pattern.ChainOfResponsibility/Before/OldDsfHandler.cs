using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Pattern.ChainOfResponsibility.Before
{
    public class OldDsfHandler
    {
        private readonly ISettingsRepository settingsRepo;

        public OldDsfHandler(ISettingsRepository settingsRepo)
        {
            this.settingsRepo = settingsRepo;
        }

        public double GetDecisionSupportFactor(int age, int weight, int height, double averageHealthPoints)
        {
            // Check abnormal BMI
            var bmi = weight / ((height / 100.0) * (height / 100.0));
            if (bmi < 18.5 || bmi > 25)
            {
                return 1;
            }

            int minAge = int.TryParse(settingsRepo.GetSettingAsString("minAge"), out minAge) ? minAge : 3;
            if (age < minAge)
            {
                return 1;
            }


            double factor = double.TryParse(settingsRepo.GetSettingAsString("factor"), out factor) ? factor : 0.75;
            if (averageHealthPoints * factor <= 1)
            {
                return 3;
            }

            var desicionSupportfactor = (weight - age) / (averageHealthPoints * 7);
            desicionSupportfactor = (desicionSupportfactor + 5) / 10;

            // Check that dsf does not exceed allowed value
            double maxDsf = double.TryParse(settingsRepo.GetSettingAsString("maxDsFactor"), out maxDsf) ? maxDsf : 1.5;
            if (desicionSupportfactor > maxDsf)
            {
                return maxDsf;
            }

            double minDsf = double.TryParse(settingsRepo.GetSettingAsString("minDsFactor"), out minDsf) ? minDsf : 0.1;
            if (desicionSupportfactor < minDsf)
            {
                return minDsf;
            }
            else
            {
                return desicionSupportfactor;
            }
        }
    }
}
