using System;

namespace ProcessList
{
    public interface IReadConfig
    {
        string[] ReadAllowedProcessList();
        string GetMinerName();
        string GetVBSPath();
        int GetTimerInterval();
        bool IsAllowUpdate();
    }
}
