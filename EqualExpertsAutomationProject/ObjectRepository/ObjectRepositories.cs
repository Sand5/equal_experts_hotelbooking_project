using EqualExpertsAutomationProject.Interfaces;
using EqualExpertsAutomationProject.PageObjects;
using OpenQA.Selenium;

namespace EqualExpertsAutomationProject.ObjectRepository
{
    public class ObjectRepositories
    {
        //properties used by various classes in the framework this helps for dependency injection and prevent null pointers
        public static IWebDriver Driver { get; set; }
        public static IConfigManager IConfig { get; set; }
        public static BookingFormPage BookingForm { get; set; }

    }
}
