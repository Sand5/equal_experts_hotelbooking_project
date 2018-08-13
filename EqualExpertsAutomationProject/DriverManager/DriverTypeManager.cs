using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace EqualExpertsAutomationProject.DriverManager
{
    public abstract class DriverTypeManager
    {


        //The CreateChromeDriver method is used to create a new chrome driver.
        public static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver(GetExcutablePath());
        }

        //This GetExcutablePath method returns the locatio of the chromedriver.
        private static string GetExcutablePath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

    }
}


