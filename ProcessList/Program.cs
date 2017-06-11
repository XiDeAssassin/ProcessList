using System;
using System.Diagnostics;
using System.IO;

namespace ProcessList
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            string[] processNames = new string[processes.Length];
            int i = 0;
            foreach (Process p in processes)
            {
                if (i<=processes.Length)
                {
                    processNames[i] = p.ProcessName;
                    i++;

                }
                else
                {
                    break;
                }
            }

            foreach(string s in processNames)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
