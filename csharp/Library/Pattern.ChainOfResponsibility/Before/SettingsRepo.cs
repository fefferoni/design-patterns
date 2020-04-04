using System;
using System.Collections.Generic;
using System.Text;

namespace Pattern.ChainOfResponsibility.Before
{
    public interface ISettingsRepository
    {
        string GetSettingAsString(string name);
    }
    public class SettingsRepo : ISettingsRepository
    {
        public string GetSettingAsString(string name)
        {
            return ""; // For demo purposes..
        }
    }
}
