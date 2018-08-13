using EqualExpertsAutomationProject.Enumerations;

namespace EqualExpertsAutomationProject.Interfaces
{
    public interface IConfigManager
    {
        //Interface methods used by the application configuration reader class to turn these methods into action.
        BrowserType GetBrowser();
        string GetWebSiteAddress();

    }
}
