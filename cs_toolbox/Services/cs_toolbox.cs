using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using toolbox;

namespace cs_toolbox.Services
{
    public class cs_toolbox
    {

 

        public string PrintWebPageHeadlesslyToPdfWithChrome(string ChromeBrowserPath, string WebPageUrl, string PrintOutPath)
        {
            try
            {
                string PrintCommand = @"--headless --disable-gpu --print-to-pdf=" + PrintOutPath + " --virtual-time-budget=9000 --no-margins " + WebPageUrl;

                var psi = new ProcessStartInfo(ChromeBrowserPath, PrintCommand) { UseShellExecute = false, Verb = "runas" };
                using (Process process = Process.Start(psi))
                {
                    Thread.Sleep(1000);
                    var image = string.Empty;
                    var executionCount = 0;
                    while (image == string.Empty && executionCount < 5)
                    {
                        if (System.IO.File.Exists(PrintOutPath))
                        {
                            image = "file printed";
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    return "true";
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }




















    }
}