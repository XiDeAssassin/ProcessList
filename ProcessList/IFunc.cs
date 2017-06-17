using System;

namespace ProcessList
{
    public interface IFunc
    {
        string[] GetProcessNames();
        void IsRunningGame();
        bool IsHaveMiner();
        void StartMiner();
        void KillMiner();
        string SHA1file(string filename);
    }
}
