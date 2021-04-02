using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NDesk.Options;

namespace kvServer
{
    public class Program
    {

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine ("Usage: kvServer [Options]");
            Console.WriteLine ("Example: kvServer -a ip_address -p port");
            Console.WriteLine ();
            Console.WriteLine ("Options:");
            p.WriteOptionDescriptions (Console.Out);
        }

        public static void Main(string[] args)
        {
            string host = "";
            string port = "";
            bool help = false;

            OptionSet p = new OptionSet()
            {
                {"a=", "{ip_address} to listen", (string h) => host = h},
                {"p=", "{port} to listen", (string p) => port = p},
                {"h|help", "show this message", v => help = (v != null)},
            };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write ("createData: ");
                Console.WriteLine (e.Message);
                Console.WriteLine ("Try `createData --help' for more information.");
                return ;
            }

            if (help || extra.Count > 0 || host == "" || port == "")
            {
                ShowHelp(p);
                return ;
            }

            
            CreateHostBuilder(host, port).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string host, string port) =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls(urls: new string[] {$"http://{host}:{port}"});
                });
    }
}
