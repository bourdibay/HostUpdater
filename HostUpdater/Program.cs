using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HostUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
                using (StreamWriter writetext = new StreamWriter(Path.Combine(systemPath, @"drivers\etc\", "hosts")))
                {
                    writetext.WriteLine("########### BEGIN someonewhocares ###########");
                    writetext.WriteLine(client.DownloadString("http://someonewhocares.org/hosts/hosts"));
                    writetext.WriteLine("########### END someonewhocares ###########");
                    writetext.WriteLine("########### BEGIN malwaredomainlist ###########");
                    writetext.WriteLine(client.DownloadString("http://www.malwaredomainlist.com/hostslist/hosts.txt"));
                    writetext.WriteLine("########### END malwaredomainlist ###########");

                    writetext.WriteLine("########### BEGIN personal Skype ###########");
                    writetext.WriteLine(@"# Skype Ads Blocker
127.0.0.1 rad.msn.com
127.0.0.1 live.rads.msn.com
127.0.0.1 ads1.msn.com
127.0.0.1 static.2mdn.net
127.0.0.1 g.msn.com
127.0.0.1 a.ads2.msads.net
127.0.0.1 b.ads2.msads.net
127.0.0.1 ac3.msn.com
# End Skype Ads Blocker
");
                    writetext.WriteLine("########### END personal Skype ###########");
                }
            }
        }
    }
}
