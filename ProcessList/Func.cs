using System;
using System.Linq;
using System.Diagnostics;

namespace ProcessList
{
    public class Func : IFunc
    {
        ReadConfig rc = new ReadConfig();

        public string[] GetProcessNames()
        {
            Process[] processes = Process.GetProcesses();
            string[] processNames = new string[processes.Length];
            int i = 0;
            foreach (Process p in processes)
            {
                if (i <= processes.Length)
                {
                    processNames[i] = p.ProcessName.ToLower();
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
            foreach (string pn in rc.ReadAllowedProcessList())
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
            if (GetProcessNames().Contains(rc.GetMinerName().ToLower()))
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
            Process.Start(rc.GetVBSPath());
            
        }

        public void KillMiner()
        {
            string minerName = rc.GetMinerName().ToLower();
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

        public string SHA1file(string filename)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    return BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

    }
}
