using System;
using System.Linq;
using System.Configuration;
using System.Diagnostics;

namespace ProcessList
{
    public class Func
    {
        public string[] ReadAllowedProcessList()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;
            string text = ConfigurationManager.AppSettings["allowProcessNames"];
            return text.Split(',');
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

        public string[] GetProcessNames()
        {
            Process[] processes = Process.GetProcesses();
            string[] processNames = new string[processes.Length];
            int i = 0;
            foreach (Process p in processes)
            {
                if (i <= processes.Length)
                {
                    processNames[i] = p.ProcessName;
                    i++;
                }
                else
                {
                    break;
                }
            }
            return processNames;
        }

        public void IsRunningGame()
        {
            foreach (string pn in ReadAllowedProcessList())
            {
                if (GetProcessNames().Contains(pn))
                {
                    Vars.isRunningGames = true;
                }
                else
                {
                    if (Vars.isRunningGames)
                    {
                        break;
                    }
                    else
                    {
                        Vars.isRunningGames = false;
                    }

                }
            }

        }


        public bool IsHaveMiner()
        {
            if (GetProcessNames().Contains(GetMinerName()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartMiner()
        {
            Process.Start(GetVBSPath());
            
        }

        public void KillMiner()
        {
            string minerName = GetMinerName();
            Process[] p = Process.GetProcessesByName(minerName);
            try
            {
                p[0].Kill();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
