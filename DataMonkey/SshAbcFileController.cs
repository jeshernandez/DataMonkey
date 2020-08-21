using Renci.SshNet;
using System;

namespace DataMonkey
{
    class SshAbcFileController : SSHConn
    {

        public void initTransfer(string[] appConfigValues) {
            SshClient sshClient = getSSHClientConn(appConfigValues[0], appConfigValues[1], appConfigValues[2]);
            sshClient.Connect();
            Console.WriteLine("Connected: " + sshClient.IsConnected);

            int errorsFound = sendSSHCommand(sshClient, "mkdir remote_folder2");

            if (errorsFound == 0) Console.WriteLine("Everything according to plan ;)~ "); 
            sshClient.Disconnect();

            Console.WriteLine("Disconnect: " + sshClient.IsConnected);
        }



    }
}
