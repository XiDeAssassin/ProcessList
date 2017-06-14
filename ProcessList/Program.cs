using System;
using System.Runtime.InteropServices;

namespace ProcessList
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        static void Main(string[] args)
        {
            ReadConfig rc = new ReadConfig();
            Console.Title = "SysGreenBackService";
            IntPtr intptr = FindWindow("ConsoleWindowClass", "SysGreenBackService");
            if (intptr != IntPtr.Zero)
            {
                ShowWindow(intptr, 0);//隐藏这个窗口
            }
            //HttpMethods hm = new HttpMethods();
            //hm.CheckAppConfigUpdate();

            //System.Timers.Timer updateTimer = new System.Timers.Timer(300000);
            //updateTimer.Enabled = true;
            //updateTimer.AutoReset = true;
            //updateTimer.Elapsed += new System.Timers.ElapsedEventHandler(runUpdate);

            //设定计时器
            System.Timers.Timer timer = new System.Timers.Timer(rc.GetTimerInterval());
            timer.Enabled = true;
            timer.AutoReset = true;

            //判断有无游戏运行，有则继续判断有无矿工运行，有则结束；
            //无则重启矿工；
            
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RunMiner);

            void RunMiner(object source, System.Timers.ElapsedEventArgs e)
            {
                
                Func obj = new Func();
                Vars.isRunningGames = false;
                obj.IsRunningGame();
                //Console.WriteLine("Vars.isRunningGames: " + Vars.isRunningGames);
                //Console.WriteLine("Is Miner Running? " + obj.IsHaveMiner());
                if (Vars.isRunningGames)
                {
                    if (obj.IsHaveMiner())
                    {
                        obj.KillMiner();
                    }

                }

                else
                {
                    if (!obj.IsHaveMiner())
                    {
                        obj.StartMiner();
                    }
                }

                //Console.WriteLine(DateTime.Now);
                GC.Collect();
            }

            //void runUpdate(object source, System.Timers.ElapsedEventArgs e)
            //{
            //    hm.CheckAppConfigUpdate();
            //}

            Console.ReadKey();
        }
        

    }
}
