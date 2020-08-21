using Renci.SshNet;
using Renci.SshNet.Common;
using System;

namespace DataMonkey
{
    class SSHConn
    {
        string SFTP_HST = "192.168.1.1";
        int SFTP_PRT = 22; 
        string SFTP_USR = "futcomker";
        string SFTP_PWD = "Suxel32#";

        public void listFiles()
        {

            var connectionInfo = new KeyboardInteractiveConnectionInfo(SFTP_HST, SFTP_USR);
            connectionInfo.AuthenticationPrompt += delegate (object sender, AuthenticationPromptEventArgs e)
            {
                foreach (var prompt in e.Prompts)
                    prompt.Response = SFTP_PWD;
            };
            //ConnectionInfo connectionInfo = new ConnectionInfo(SFTP_HST, SFTP_PRT, SFTP_USR, pauth, kauth);

            SshClient client = new SshClient(connectionInfo);
            client.Connect();

            var cmd = client.CreateCommand("mkdir remoteCreation");
            cmd.Execute();
            Console.WriteLine("Command>" + cmd.CommandText);
            Console.WriteLine("Return Value = {0}", cmd.ExitStatus);

            Console.WriteLine("SSH Connected? " + client.IsConnected);

            client.Disconnect(); 

        }

        private void HandleKeyEvent(object sender, AuthenticationPromptEventArgs e)
        {
            foreach (AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = SFTP_PWD;
                }
            }
        }

    }
}
