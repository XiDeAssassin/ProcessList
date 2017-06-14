using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProcessList
{
    public class ReadConfig
    {
        public string[] ReadAllowedProcessList()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string text = ConfigurationManager.AppSettings["allowProcessNames"];
            return text.ToLower().Split(',');
        }

        public string GetMinerName()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string minerName = ConfigurationManager.AppSettings["minerName"];
            return minerName;
        }

        public string GetVBSPath()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string path = ConfigurationManager.AppSettings["minerVBSpath"];
            return path;
        }

        public int GetTimerInterval()
        {
            string interval;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            interval = ConfigurationManager.AppSettings["timerinterval"];
            return int.Parse(interval);
        }

        public bool IsAllowUpdate()
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
