using System;
using System.Configuration;

namespace ProcessList
{
    public class ReadConfig
    {
        public static string[] ReadAllowedProcessList()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string text = ConfigurationManager.AppSettings["allowProcessNames"];
            return text.ToLower().Split(',');
        }

        public static string GetMinerName()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string minerName = ConfigurationManager.AppSettings["minerName"];
            return minerName;
        }

        public static string GetVBSPath()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string path = ConfigurationManager.AppSettings["minerVBSpath"];
            return path;
        }

        public static int GetTimerInterval()
        {
            string interval;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            interval = ConfigurationManager.AppSettings["timerinterval"];
            return int.Parse(interval);
        }

        public static bool IsAllowUpdate()
        {
            string tmp;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            tmp = ConfigurationManager.AppSettings["isAllowUpdateConfig"];
            if (tmp == "true")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
