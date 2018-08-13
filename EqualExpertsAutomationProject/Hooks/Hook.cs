using EqualExpertsAutomationProject.AppConfigurationReader;
using EqualExpertsAutomationProject.DriverManager;
using EqualExpertsAutomationProject.Enumerations;
using EqualExpertsAutomationProject.ObjectRepository;
using EqualExpertsAutomationProject.ScreenShotTakerManager;
using EqualExpertsAutomationProject.UserDefinedExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TechTalk.SpecFlow;

namespace EqualExpertsAutomationProject.BasePage
{

    [Binding]
    public abstract class Hook
    {
        [BeforeScenario]

        //InitializeBrowser method is used to create and launch the instance of the chosen browser
        public static void InitializeBrowser()
        {
            //Point the objectrepositories iconfig property to the application  reader class.
            ObjectRepositories.IConfig = new ApplicationConfigurationReader();

            //Use the GetBroswer method to check with broswer to use based on the enum.
            switch (ObjectRepositories.IConfig.GetBrowser())
            {
                case BrowserType.CHROME:

                    ObjectRepositories.Driver = DriverTypeManager.CreateChromeDriver();
                    break;

                default: throw new InvalidDriverException("The driver which has been specified is invalid");
            }

        }

        [AfterScenario]

        //TestCleanUp method checks to see if the browser is alive then closes the browser and the instance.
        public static void TestCleanUp()

        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScreenshotTakerManager.TakeScreenShotOnFailureOfTest(ScenarioContext.Current.ScenarioInfo.Title);
            }
                if (ObjectRepositories.Driver != null)
            {

                ObjectRepositories.Driver.Close();
                ObjectRepositories.Driver.Quit();
            }
        }



    }
}

