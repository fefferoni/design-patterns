using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.ChainOfResponsibility.After.Models
{
    /// <summary>
    /// A request used when calculating a decision support factor for a clinical system.
    /// </summary>
    public class DsfRequest
    {
        public int Age { get; }
        public int Weight { get; }
        public int Height { get; }
        public double AverageHealthPoints { get; }
        public string MinAgeSetting { get; }
        public string FactorSetting { get; }
        public string MaxDsfSetting { get; }
        public string MinDsfSetting { get; }
        public double DsfFactor { get; set; }

        public DsfRequest(int age, int weight, int height, double averageHealthPoints, string minAgeSetting, string factorSetting, string maxDsfSetting, string minDsfSetting)
        {
            Age = age;
            Weight = weight;
            Height = height;
            AverageHealthPoints = averageHealthPoints;
            MinAgeSetting = minAgeSetting;
            FactorSetting = factorSetting;
            MaxDsfSetting = maxDsfSetting;
            MinDsfSetting = minDsfSetting;
        }
    }
}
