using EqualExpertsAutomationProject.ObjectRepository;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace EqualExpertsAutomationProject.ScreenShotTakerManager
{
    public class ScreenshotTakerManager : ObjectRepositories
    {

        private static string timestamp = "";
        private static readonly string CurrentDir = Directory.GetCurrentDirectory();
        private const string folderName = "\\ScreenshotsFailedTests";

        //TakeScreenShotOnFailureOfTest takes a screenshot of a failed scenario when the scenerio ends.
        public static void TakeScreenShotOnFailureOfTest(string testcasename)
        {
            try
            {
                //Create the screen object 
                Screenshot screen = Driver.TakeScreenshot();

                //Check if the folder name does not exist if not create the folder if it does take the screenshot saves the file.
                //Screenshot is saved in the path of bin \source\repos\EqualExpertsAutomationProject\EqualExpertsAutomationProject\bin\Debug\ScreenshotsFailedTests.
                if (!Directory.Exists(CurrentDir + folderName))
                {
                   Directory.CreateDirectory(CurrentDir + folderName);
                   SaveScreenShotToDirectory(testcasename, screen);
                }

                else
                {
                    SaveScreenShotToDirectory(testcasename, screen);
                }
            }


            catch (WebDriverException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        //SaveScreenShotToDirectory method used to save the file appending the scenario name timestamp 
        private static void SaveScreenShotToDirectory(string scenario, Screenshot screen)
        {
            timestamp = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss");
            screen.SaveAsFile(CurrentDir + folderName + "\\" + scenario + " - " + timestamp + ".png",
            ScreenshotImageFormat.Jpeg);
        }
    }
}

