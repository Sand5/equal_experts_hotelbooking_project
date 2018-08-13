using EqualExpertsAutomationProject.ObjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualExpertsAutomationProject.UtilityHelper
{
    public class WindowHelper
    {
        //Helper method used to refresh the browser page.
        public static void RefreshThePage()
        {
            ObjectRepositories.Driver.Navigate().Refresh();
        }
    }
}
