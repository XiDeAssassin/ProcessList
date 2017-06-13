using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ProcessList
{
    class HttpMethods
    {
        public void DownloadConfigFile(string uri)
        {
            WebClient wc = new WebClient();
            wc.Headers.Set(HttpRequestHeader.UserAgent, Vars.useragent);
            wc.DownloadFile(uri, Vars.ConfigTempPath);
        }

        public void CheckAppConfigUpdate()
        {
            Func obj = new Func();
            DownloadConfigFile("http://xinoassassin.com/processlist.exe.config");
            string localConfigPath = System.Windows.Forms.Application.StartupPath + @"\ProcessList.exe.config";

            //Console.WriteLine("local:{0}", obj.SHA1file(localConfigPath));
            //Console.WriteLine("server:{0}", obj.SHA1file(Vars.ConfigTempPath));
            if (obj.SHA1file(localConfigPath) != obj.SHA1file(Vars.ConfigTempPath))
            {
                File.Copy(Vars.ConfigTempPath, localConfigPath, true);
                System.Windows.Forms.Application.Restart();
            }
            else
            {
                File.Delete(Vars.ConfigTempPath);
            }
        }
    }
}
