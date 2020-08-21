using System;
using System.Configuration;

namespace DataMonkey
{
    class Program
    {
        static string[] appConfigValues = new string[3];
        static void Main(string[] args)
        {
            getAppConfig();

            SshAbcFileController sshABCFileController = new SshAbcFileController();
            sshABCFileController.initTransfer(appConfigValues); 


            Console.WriteLine("App Complete!");
            Console.ReadLine(); 

        }


        private static void getAppConfig()
        {
            var appSettings = ConfigurationManager.AppSettings;
            appConfigValues[0] = appSettings[0];
            appConfigValues[1] = appSettings[1];
            appConfigValues[2] = appSettings[2]; 
        }


    } // End Program Class
}
