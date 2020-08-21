using Renci.SshNet;
using Renci.SshNet.Common;
using System;

namespace DataMonkey
{
    class SSHConn
    {

        public SshClient getSSHClientConn(string host, string user, string pwd) {

            var connectionInfo = new KeyboardInteractiveConnectionInfo(host, user);
            connectionInfo.AuthenticationPrompt += delegate (object sender, AuthenticationPromptEventArgs e)
            {
                foreach (var prompt in e.Prompts)
                    prompt.Response = pwd;
            };

            return new SshClient(connectionInfo);
        }

        public int sendSSHCommand(SshClient client, string command)
        {
            var cmd = client.CreateCommand(command);
            cmd.Execute();
            Console.WriteLine("Command>" + cmd.CommandText);

            return cmd.ExitStatus; 
        }
  


    }
}
