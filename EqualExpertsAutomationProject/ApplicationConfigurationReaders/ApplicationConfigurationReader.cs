using EqualExpertsAutomationProject.ConfigurationKeys;
using EqualExpertsAutomationProject.Enumerations;
using EqualExpertsAutomationProject.Interfaces;
using System;
using System.Configuration;

namespace EqualExpertsAutomationProject.AppConfigurationReader
{

    public class ApplicationConfigurationReader : IConfigManager
    {


        //Returns the browser based on the app config file value compares this to the enum.
        public BrowserType GetBrowser()
        {
            return (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings.Get(AppConfigurationKeys.Browser));
        }


        //Returns the application url based on the value in the app config file.
        public string GetWebSiteAddress()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigurationKeys.Website);
        }

    }
}
