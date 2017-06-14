using System;

namespace ProcessList
{
    public class Vars
    {
        static public bool isRunningGames = false;
        static public string ConfigTempPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + @"\tmpPL.app.confg";
        static public string useragent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.86 Safari/537.36";

    }
}
