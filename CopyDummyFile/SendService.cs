
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WindowsService
{
    public sealed class SendService
    {
 
        public void sendFile(Configuration MyConfig, string sendfile)
        {

            string[] testar = sendfile.Split('=');
            testar = testar[testar.Length-1].Split('\\');
            string filename = testar[testar.Length - 1];
            try
            {
                using (var client = new SftpClient(MyConfig["sftpServer"], MyConfig["sftpUser"], MyConfig["sftpPass"]))
                //using (var client = new SftpClient(localServer, localUser, localPass))
               {
                    client.Connect();

                    using (FileStream fs = File.OpenRead(sendfile))
                    {
                        client.UploadFile(fs, MyConfig["sftpdestination"] + @"/" + filename);
                    }

                    client.Disconnect();
                    client.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                System.Environment.Exit(1);
            }
        }
    }
}
