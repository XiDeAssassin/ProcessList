using System;
using System.Linq;

namespace ProcessList
{
    class Program
    {
        static void Main(string[] args)
        {
            Func obj = new Func();


            //设定计时器
            System.Timers.Timer timer = new System.Timers.Timer(obj.GetTimerInterval());
            timer.Enabled = true;
            timer.AutoReset = true;

            //判断有无游戏运行，有则继续判断有无矿工运行，有则结束；
            //无则重启矿工；
            
            timer.Elapsed += new System.Timers.ElapsedEventHandler(RunMiner);

            void RunMiner(object source, System.Timers.ElapsedEventArgs e)
            {
                Vars.isRunningGames = false;
                obj.IsRunningGame();
                Console.WriteLine("Vars.isRunningGames: " + Vars.isRunningGames);
                Console.WriteLine("Is Miner Running? " + obj.IsHaveMiner());
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

                Console.WriteLine(DateTime.Now);

            }
            
            Console.ReadKey();
        }
        

    }
}
